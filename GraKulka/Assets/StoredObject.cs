using UnityEngine;

public class StoredObject
{
	public Vector3 position;
	public Quaternion rotation;

	public StoredObject(Vector3 _position, Quaternion _rotation)
	{
		 position = _position;
		rotation = _rotation;
	}
}
