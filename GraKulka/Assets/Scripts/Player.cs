using UnityEngine;

public class Player : MonoBehaviour
{
	public Rigidbody rb;
	float speed;

	void FixedUpdate()
	{
		speed = rb.velocity.magnitude;

		Debug.Log(speed);
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
