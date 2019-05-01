using UnityEngine;

namespace Assets.Scripts
{
    public class StoredObject
    {
        public Vector3 position;
        public Quaternion rotation;
		public Vector3 localEulerAngles;

		public StoredObject(Vector3 _position, Quaternion _rotation, Vector3 _localEulerAngles)
        {
            position = _position;
            rotation = _rotation;
			localEulerAngles = _localEulerAngles;
		}
    }
}
