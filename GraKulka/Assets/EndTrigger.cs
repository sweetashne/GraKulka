using UnityEngine;

public class EndTrigger : MonoBehaviour
{
	public GameObject LevelComplete;

	private void OnTriggerEnter(Collider other)
	{
		LevelComplete.SetActive(true);
	}
}
