using UnityEngine;

namespace Assets.Scripts
{
    public class MoveCamera : MonoBehaviour
    {
        public GameObject oldCamera;
        public GameObject newCamera;
        private float rSpeed = 2.0f;
        private float mSpeed = 10.0f;
        private float X = 0.0f;
        private float Y = 0.0f;

        void Update()
        {
            if (Input.GetKey(KeyCode.C))
            {
                oldCamera.SetActive(false);
                newCamera.SetActive(true);
                X += Input.GetAxis("Mouse X") * rSpeed;
                Y += Input.GetAxis("Mouse Y") * rSpeed;
                transform.localRotation = Quaternion.AngleAxis(X, Vector3.up);
                transform.localRotation *= Quaternion.AngleAxis(Y, Vector3.left);
                transform.position += transform.forward * mSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
                transform.position += transform.right * mSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
            }
            if (Input.GetKeyUp(KeyCode.C))
            {
                oldCamera.SetActive(true);
                newCamera.SetActive(false);
            }
        }
    }
}
