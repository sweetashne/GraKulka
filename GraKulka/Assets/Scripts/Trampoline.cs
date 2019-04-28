using UnityEngine;

public class Trampoline : MonoBehaviour
{
	public float Height = 20;
    public float Strenght = 5;

    private GameObject _player;

    void Start()
    {
        _player = FindObjectOfType<Player>().gameObject;
    }

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
        {
            var y = this.transform.localEulerAngles.y;
            _player.GetComponent<Rigidbody>().velocity = GetForceVector(y);
            _player.GetComponent<Rigidbody>().AddForce(new Vector3(0, Height * Time.deltaTime, 0));
        }
	}

    private Vector3 GetForceVector(float y)
    {
        if (y >= 0 && y <= 44)
        {
            Debug.Log("y >= 0 && y < 45 y: " + y);
            return new Vector3(Strenght, 5, 0);
        }

        if (y >= 45 && y <= 89)
        {
            Debug.Log("y >= 45 && y < 90 y: " + y);
            return new Vector3(Strenght, 5, Strenght);
        }

        if (y >= 90 && y <= 134)
        {
            Debug.Log("y >= 90 && y < 135 y: " + y);
            return new Vector3(0, 5, Strenght);
        }
        if (y >= 135 && y <= 179)
        {
            Debug.Log("y >= 135 && y < 180 y: " + y);
            return new Vector3(-Strenght, 5, Strenght);
        }
        if (y >= 180 && y <= 224)
        {
            Debug.Log("y >= 180 && y < 225 y: " + y);
            return new Vector3(-Strenght, 5, 0);
        }
        if (y >= 225 && y <= 269)
        {
            Debug.Log("y >= 225 && y < 270 y: " + y);
            return new Vector3(-Strenght, 5, -Strenght);
        }
        if (y >= 270 && y < 315)
        {
            Debug.Log("y >= 270 && y < 315 y: " + y);
            return new Vector3(Strenght, 5, -Strenght);
        }

        Debug.Log("y >= 270 y: " + y);
        return new Vector3(0, 5, -Strenght);
    }
}
