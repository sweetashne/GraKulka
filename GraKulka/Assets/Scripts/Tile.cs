using UnityEngine;

public class Tile : MonoBehaviour
{
	public bool selectable = false;
	bool tileSelected = false;
	public Canvas Ui;

	// Update is called every frame, if the MonoBehaviour is enabled.
	private void Update()
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

	// MonoBehaviour method. OnGUI is called for rendering and handling GUI events.
	private void OnGUI()
	{
		if (tileSelected)
		{
			GUILayout.Label("Add some shit");
			RaycastHit hit;
			// If user clicked the button.
			if (GUILayout.Button("Add a wall"))
			{
				// Does the ray intersect any objects excluding the player layer
				if (!Physics.Raycast(this.transform.position, Vector3.up, out hit, 1))
				{
					AddWall(this);
					tileSelected = false;
				}
			}

			if (GUILayout.Button("Add a ramp"))
			{
				if (!Physics.Raycast(this.transform.position, Vector3.up, out hit, 1))
				{
					AddRamp(this);
					tileSelected = false;
				}
			}

			if (GUILayout.Button("Add a 45 degree wall"))
			{
				// Does the ray intersect any objects excluding the player layer
				if (!Physics.Raycast(this.transform.position, Vector3.up, out hit, 1))
				{
					Add45Wall(this);
					tileSelected = false;
				}
			}
		}
	}

	private void AddRamp(Tile tile)
	{
		// Create a new object that's loaded from Resources folder.
		GameObject Ramp = Resources.Load("Prefabs/Wall") as GameObject;
		Ramp.name = "Ramp";
		Ramp.transform.localScale = new Vector3(1, 1, 0.1f);
		Vector3 position = tile.transform.position + new Vector3(0, 0.9f, -0.2f);

		// Make an instance of the object.
		Instantiate(Ramp, position, Quaternion.Euler(new Vector3(45, 0, 0)));
	}

	private void Add45Wall(Tile tile)
	{
		GameObject WallDegree = Resources.Load("Prefabs/Wall") as GameObject;
		WallDegree.name = "45Wall";
		WallDegree.GetComponent<BoxCollider>().size = new Vector3(0.3f, 1, 10);
		WallDegree.GetComponent<BoxCollider>().center = new Vector3(0, 0, 0);
		WallDegree.transform.localScale = new Vector3(1.314f, 1, 0.1f);
		Vector3 position = tile.transform.position + new Vector3(0, 1, 0);
		Instantiate(WallDegree, position, Quaternion.Euler(new Vector3(0, 45, 0)));
	}

	// MonoBehaviour method. Is called when the user has pressed the mouse button while over the GUIElement or Collider.
	private void OnMouseDown()
	{
		// User can only click on a tile if it's selectable.
		if (selectable)
		{
			tileSelected = true;
		}
	}

	protected void AddWall(Tile tile)
	{
		GameObject Wall = Resources.Load("Prefabs/Wall") as GameObject;
		Wall.name = "Wall";
		Wall.GetComponent<BoxCollider>().size = new Vector3(1, 1, 10);
		Wall.GetComponent<BoxCollider>().center = new Vector3(0, 0, 5);
		Wall.transform.localScale = new Vector3(1, 1, 0.1f);
		Vector3 position = tile.transform.position + new Vector3(0, 1, -0.5f);
		Instantiate(Wall, position, Quaternion.identity);
	}

	// Checks if there is a wall already on this tile.
	private void WallCheck(Tile tile)
	{

	}
}
