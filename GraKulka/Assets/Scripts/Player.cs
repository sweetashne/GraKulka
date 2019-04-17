using UnityEngine;

public class Player : MonoBehaviour
{
	public Rigidbody rb;
	public PhysicMaterial pm;
	float speed;
	//private void Update()
	//{
	//	rb.AddForce(new Vector3(1, 0, 1));
	//}
	void FixedUpdate()
	{
		speed = rb.velocity.magnitude;

		if (speed < 0.02f && !GameState.GameIsPaused)
		{
			FindObjectOfType<GameState>().Editor();
		}

		if (rb.position.y < -2f)
		{
			FindObjectOfType<GameState>().Editor();
		}
	}
}
