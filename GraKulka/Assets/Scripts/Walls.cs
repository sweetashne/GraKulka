using UnityEngine;

public class Walls : MonoBehaviour
{
	private void OnMouseOver()
	{
		if (Input.GetMouseButtonDown(1))
		{
			if (this.name == "Wall(Clone)")
				RotateWall();
			if (this.name == "Ramp(Clone)")
				RotateRamp();
			if (this.name == "45Wall(Clone)")
				RotateWallDegree();
		}
	}

	void RotateWall()
	{
		transform.Rotate(new Vector3(0, 90, 0));
		transform.Translate(new Vector3(-0.5f, 0, -0.5f));
	}

	// TODO: @Piorutko
	void RotateRamp()
	{
		transform.Rotate(new Vector3(-45, 0, 0));
		transform.Rotate(new Vector3(0, 90, 0));
		transform.Rotate(new Vector3(45, 0, 0));
	}

	void RotateWallDegree()
	{
		transform.Rotate(new Vector3(0, 90, 0));
	}
}
