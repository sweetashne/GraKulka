using UnityEngine;

public class Player : MonoBehaviour
{
	public Rigidbody rb;
	float speed;

	void FixedUpdate()
	{
		speed = rb.velocity.magnitude;

		if (speed < 0.16f && !GameState.GameIsPaused)
		{
			FindObjectOfType<GameState>().Editor();
		}

		if (rb.position.y < -1f)
		{
			FindObjectOfType<GameState>().Editor();
		}
	}
}
