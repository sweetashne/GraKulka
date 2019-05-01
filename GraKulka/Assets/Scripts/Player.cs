using UnityEngine;

namespace Assets.Scripts
{
    public class Player : MonoBehaviour
    {
		//float speed;

        void FixedUpdate()
        {
            //speed = GetComponent<Rigidbody>().velocity.magnitude;

            //if (speed < 0.02f && !GameState.GameIsPaused)
            //{
            //    FindObjectOfType<GameState>().Editor();
            //}

            if (GetComponent<Rigidbody>().position.y < -2f)
            {
                FindObjectOfType<GameState>().Editor();
            }
        }
    }
}
