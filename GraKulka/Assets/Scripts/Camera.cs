using UnityEngine;

public class Camera : MonoBehaviour
{
	private Transform cameraPivotObject;
	private Transform parentObject;

	public bool cameraDisabled = true;

	private Vector3 localRotation;
	private float cameraDistance = 10f;

	public float mousesensitivity = 4f;
	public float scrollsensitivity = 2f;
	public float scrollSpeed = 6f;
	public float rotationSpeed = 10f;

	// Start is called before the first frame update
	void Start()
	{
		this.cameraPivotObject = this.transform;
		this.parentObject = this.transform.parent;
	}

	// Late update is called once per frame, after Update() on every game object in the scene
	void LateUpdate()
	{
		if (Input.GetMouseButtonDown(2))
		{
			cameraDisabled = false;
		}
		if (Input.GetMouseButtonUp(2))
		{
			cameraDisabled = true;
		}
		if (!cameraDisabled)
		{
			// Rotation of the camera based on mouse coordinates
			if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
			{
				localRotation.x += Input.GetAxis("Mouse X") * mousesensitivity;
				localRotation.y -= Input.GetAxis("Mouse Y") * mousesensitivity;
				// Clamp the y rotation to horizon and not flipping over at the top
				localRotation.y = Mathf.Clamp(localRotation.y, 0f, 90f);
			}
			// Zooming input from scroll wheel
			
			Quaternion QT = Quaternion.Euler(localRotation.y, localRotation.x, 0);
			this.parentObject.rotation = Quaternion.Lerp(this.parentObject.rotation, QT, Time.deltaTime * rotationSpeed);

		
		}
		if (Input.GetAxis("Mouse ScrollWheel") != 0f)
		{
			float scrollAmout = Input.GetAxis("Mouse ScrollWheel") * scrollsensitivity;
			// Makes camera zoom faster the further away it is from the target
			scrollAmout *= (this.cameraDistance * 0.3f);
			this.cameraDistance += scrollAmout * -1f;
			// This makes camera go no closer than 1.5 meters from target, and no further than 100 meters
			this.cameraDistance = Mathf.Clamp(this.cameraDistance, 1.5f, 100f);
		}
		if (this.cameraPivotObject.localPosition.z != this.cameraDistance * -1f)
		{
			this.cameraPivotObject.localPosition = new Vector3(0, 0, Mathf.Lerp(this.cameraPivotObject.localPosition.z, this.cameraDistance * -1f, Time.deltaTime * scrollSpeed));
		}
	}
}
