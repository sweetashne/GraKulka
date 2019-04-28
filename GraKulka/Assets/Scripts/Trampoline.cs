using UnityEngine;

public class Trampoline : MonoBehaviour
{
	public float height;

	GameObject Player;

	private void Start()
	{
		Player = FindObjectOfType<Player>().gameObject;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			if(this.transform.localEulerAngles.y == 0)
			{
				Player.GetComponent<Rigidbody>().velocity = new Vector3(5, 5, 0);
				Player.GetComponent<Rigidbody>().AddForce(new Vector3(0, height * Time.deltaTime, 0));
			}
			 if (this.transform.localEulerAngles.y == 90)
			{
				Player.GetComponent<Rigidbody>().velocity = new Vector3(0, 5, 5);
				Player.GetComponent<Rigidbody>().AddForce(new Vector3(0, height * Time.deltaTime, 0));
			}
			 if (this.transform.localEulerAngles.y == 180)
			{
				Player.GetComponent<Rigidbody>().velocity = new Vector3(-5, 5, 0);
				Player.GetComponent<Rigidbody>().AddForce(new Vector3(0, height * Time.deltaTime, 0));
			}
			if (this.transform.localEulerAngles.y == 270)
			{
				Player.GetComponent<Rigidbody>().velocity = new Vector3(0, 5, -5);
				Player.GetComponent<Rigidbody>().AddForce(new Vector3(0, height * Time.deltaTime, 0));
			}
		}
	}
}
