using UnityEngine;

public class Player : MonoBehaviour
{
	public Rigidbody rb;
	float speed;

	void FixedUpdate()
	{
		speed = rb.velocity.magnitude;

		if (speed < 0f && !GameState.GameIsPaused)
		{
			Debug.Log(speed);
			FindObjectOfType<GameState>().Editor();
		}

		if (rb.position.y < -2f)
		{
			FindObjectOfType<GameState>().Editor();
		}
	}
}
