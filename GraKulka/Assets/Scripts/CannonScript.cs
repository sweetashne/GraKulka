using UnityEngine;

namespace Assets.Scripts
{
    public class CannonScript : MonoBehaviour
    {
        private GameObject _cannonBall;

        private float rateOfFire = 0.5f;
        private float fireDelay = 0.5f;
        private float fireSpeed = 20f;

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetButton("Fire1") && Time.time > fireDelay)
            {
                fireDelay = Time.time + rateOfFire;
                GameObject clone = Instantiate(_cannonBall, transform.position, transform.rotation);
            }
        }
    }
}
