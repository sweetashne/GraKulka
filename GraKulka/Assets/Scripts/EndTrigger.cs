using UnityEngine;

namespace Assets.Scripts
{
    public class EndTrigger : MonoBehaviour
    {
        public GameObject LevelComplete;

        private void OnTriggerEnter(Collider other)
        {
            LevelComplete.SetActive(true);
        }
    }
}
