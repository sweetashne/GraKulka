using UnityEngine;

public class AnimateCharacter : MonoBehaviour
{
	public float movespeed = 0.5f;
	CharacterController controller;
	Animation animation;

	// Start is called before the first frame update
	void Start()
	{
		controller = GetComponent<CharacterController>();
		animation = GetComponent<Animation>();
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKey(KeyCode.W))
		{
			animation.Play("walk");
			transform.Translate(Vector3.forward * movespeed * Time.deltaTime);
		}
		if (Input.GetMouseButton(0))
		{
			animation.Play("attack");
		}
		if (Input.GetKeyUp(KeyCode.W))
		{
			animation.Play("idle");
		}
		if (Input.GetKeyDown(KeyCode.S))
		{
			transform.Rotate(new Vector3(0, 180, 0), Space.Self);
		}
		if (Input.GetKeyDown(KeyCode.A))
		{
			transform.Rotate(new Vector3(0, -90, 0), Space.Self);
		}
		if (Input.GetKeyDown(KeyCode.D))
		{
			transform.Rotate(new Vector3(0, 90, 0), Space.Self);
		}	
	}

	public void Idle()
	{
		animation.Play("idle");
	}
}
