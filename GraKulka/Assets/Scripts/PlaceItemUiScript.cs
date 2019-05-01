using UnityEngine;

public class PlaceItemUiScript : MonoBehaviour
{
	public void show()
	{
		this.gameObject.SetActive(true);
	}

	public void hide()
	{
		this.gameObject.SetActive(false);
	}
}
