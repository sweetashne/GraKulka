using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class EndTrigger : MonoBehaviour
    {
        public GameObject LevelComplete;

        private void OnTriggerEnter(Collider other)
        {
            LevelComplete.SetActive(true);
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
    }
}
