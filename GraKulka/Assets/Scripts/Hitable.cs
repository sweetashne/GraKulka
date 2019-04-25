using UnityEngine;

public class Hitable : MonoBehaviour
{
	Animation animation;

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
