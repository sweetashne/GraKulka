using UnityEngine;

namespace Assets.Scripts
{
    public class Hitable : MonoBehaviour
    {
		new Animation animation;

        void Start()
        {
            animation = GetComponent<Animation>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                animation.Play("die");
            }
        }
    }
}
