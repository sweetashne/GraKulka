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
			if (other.name == "Player")
			{
				GetComponentInParent<Animator>().SetTrigger("IsTriggered");

				if (other.GetComponent<Rigidbody>().velocity.z > 0.5f)
				{
					other.GetComponent<Rigidbody>().velocity = other.GetComponent<Rigidbody>().velocity - new Vector3(0, 0, 0.5f);
					other.GetComponent<Rigidbody>().angularVelocity = other.GetComponent<Rigidbody>().angularVelocity - new Vector3(0, 0, 0.5f);
					Invoke("LevelCompleted", 2);
				}

				if (other.GetComponent<Rigidbody>().velocity.x > 0.5f)
				{
					other.GetComponent<Rigidbody>().velocity = other.GetComponent<Rigidbody>().velocity - new Vector3(0.5f, 0, 0);
					other.GetComponent<Rigidbody>().angularVelocity = other.GetComponent<Rigidbody>().angularVelocity - new Vector3(0.5f, 0, 0);
					Invoke("LevelCompleted", 2);
				}

				
				Invoke("NextScene", 2);
			}
		}

		private void NextScene()
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}

		private void LevelCompleted()
		{
			LevelComplete.SetActive(true);
		}
	}
}
