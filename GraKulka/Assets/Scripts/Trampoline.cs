using UnityEngine;

public class Trampoline : MonoBehaviour
{
	public float height;

	public GameObject Player;


	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			Player.GetComponent<Rigidbody>().velocity = new Vector3(5, 5, 0);
			Player.GetComponent<Rigidbody>().AddForce(new Vector3(0, height * Time.deltaTime, 0));
			
		}
	}
}
