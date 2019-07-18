using UnityEngine;
using UnityEngine.Networking;

public class MinimapScript : MonoBehaviour
{
	public Transform player;

	void LateUpdate()
	{
		Vector3 newPosition = player.position;
		newPosition.y = transform.position.y;
		transform.position = newPosition;
	}
}
