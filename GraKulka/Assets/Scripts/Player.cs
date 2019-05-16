using UnityEngine;

namespace Assets.Scripts
{
	public class Player : MonoBehaviour
	{
		void Update()
		{
			if (GetComponent<Rigidbody>().position.y < -1)
			{
				FindObjectOfType<GameState>().Editor();
			}
		}
	}
}
