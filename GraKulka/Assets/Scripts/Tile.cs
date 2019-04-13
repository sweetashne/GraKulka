using UnityEngine;

public class Tile : MonoBehaviour
{
	public bool selectable = false;
	bool tileSelected = false;
	public Canvas Ui;

	public void Update()
	{
		if (selectable)
		{
			GetComponent<Renderer>().material.color = Color.magenta;
		}
		else
		{
			GetComponent<Renderer>().material.color = Color.white;
		}
	}

	private void OnGUI()
	{
		if (tileSelected)
		{
			GUILayout.Label("Add some shit");

			if (GUILayout.Button("Add a wall"))
			{
				AddWall(this);
				tileSelected = false;
				Debug.Log("Wall added");
			}

			if (GUILayout.Button("Add a ramp"))
			{
				AddRamp(this);
				tileSelected = false;
				Debug.Log("Ramp Added");
			}

			if (GUILayout.Button("Add a 45 degree wall"))
			{
				Add45Wall(this);
				tileSelected = false;
				Debug.Log("45wall added");
			}
		}
	}

	// TODO: You can only place one wall on a tile. @Sweetashne
	private void AddRamp(Tile tile)
	{
		GameObject Ramp = Resources.Load("Prefabs/Wall") as GameObject;
		Ramp.name = "Ramp";
		Ramp.transform.localScale = new Vector3(1, 1, 0.1f);
		Vector3 position = tile.transform.position + new Vector3(0, 0.9f, -0.2f);
		Instantiate(Ramp, position, Quaternion.Euler(new Vector3(45, 0, 0)));
	}

	private void Add45Wall(Tile tile)
	{
		GameObject WallDegree = Resources.Load("Prefabs/Wall") as GameObject;
		WallDegree.name = "45Wall";
		WallDegree.transform.localScale = new Vector3(1.314f, 1, 0.1f);
		Vector3 position = tile.transform.position + new Vector3(0, 1, 0);
		Instantiate(WallDegree, position, Quaternion.Euler(new Vector3(0, 45, 0)));
	}

	void OnMouseDown()
	{
		if (selectable)
		{
			tileSelected = true;
			Debug.Log("Klik");
		}
	}

	protected void AddWall(Tile tile)
	{
		GameObject Wall = Resources.Load("Prefabs/Wall") as GameObject;
		Wall.name = "Wall";
		Wall.transform.localScale = new Vector3(1, 1, 0.1f);
		Vector3 position = tile.transform.position + new Vector3(0, 1, -0.5f);
		Instantiate(Wall, position, Quaternion.identity);
	}
}
