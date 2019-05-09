using UnityEngine;

namespace Assets.Scripts
{
	public class StoredObject
	{
		public string name;
		public Vector3 position;
		public Quaternion rotation;
		public Vector3 localEulerAngles;

		public StoredObject(string _name, Vector3 _position, Quaternion _rotation, Vector3 _localEulerAngles)
		{
			name = _name;
			position = _position;
			rotation = _rotation;
			localEulerAngles = _localEulerAngles;
		}
	}
}
