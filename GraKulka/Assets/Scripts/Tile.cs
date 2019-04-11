using UnityEngine;

public class Tile : MonoBehaviour
{
	public bool Selectable = false;
	bool TileSelected = false;
	public Canvas Ui;

	public void Update()
	{
		if (Selectable)
		{
			GetComponent<Renderer>().material.color = Color.magenta;
		}
		else
		{
			GetComponent<Renderer>().material.color = Color.white;
		}
	}

	public void ShowUI()
	{
		Debug.Log("Clicked");
	}

	private void OnMouseDown()
	{
		if (Selectable)
		{
			Debug.Log("Klik");
		}
	}
}
