using UnityEngine;

namespace Assets.Scripts
{
	public class Player : MonoBehaviour
	{
		void Update()
		{
			Debug.DrawRay(transform.position, Vector3.forward, Color.red, 2302302030);
			if (GetComponent<Rigidbody>().position.y < -1)
			{
				FindObjectOfType<GameState>().Editor();
			}
		}
	}
}
