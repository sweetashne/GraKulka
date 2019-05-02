using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
	public class EndTrigger : MonoBehaviour
	{
		public GameObject LevelComplete;
		public int delay = 5;

		private void OnTriggerEnter(Collider other)
		{
			LevelComplete.SetActive(true);
			Invoke("NextScene", delay);
		}

		private void NextScene()
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
	}
}
