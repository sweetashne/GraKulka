using UnityEngine;

public class Tile : MonoBehaviour
{
	public bool selectable = false;
	bool tileSelected = false;

	// Update is called every frame, if the MonoBehaviour is enabled.
	private void Update()
	{
		if (selectable && GameState.GameIsPaused)
		{
			GetComponent<Renderer>().material.color = Color.magenta;
		}
		else
		{
			GetComponent<Renderer>().material.color = Color.white;
		}
	}

	// TODO: @Piorutko Add a cancel button that hides the GUI.
	// MonoBehaviour method. OnGUI is called for rendering and handling GUI events.
	private void OnGUI()
	{
		// Checks if there is object above the tile and the tile is selected
		// TODO: Tweak numbers so you can use the tile next to the tile u press but to still see the wall above
		if (tileSelected && !Physics.CheckBox(this.transform.position + Vector3.up, new Vector3(0.44f, 0.44f, 0.44f)) && GameState.GameIsPaused)
		{
			GUILayout.Label("Add some shit");

			// If user clicked the button.
			if (GUILayout.Button("Add a wall"))
			{
				AddWall(this);
				tileSelected = false;
			}

			if (GUILayout.Button("Add a ramp"))
			{
				AddRamp(this);
				tileSelected = false;
			}

			if (GUILayout.Button("Add a 45 degree wall"))
			{
				Add45Wall(this);
				tileSelected = false;
			}
		}
	}

	private void AddRamp(Tile tile)
	{
		// Create a new object that's loaded from Resources folder.
		GameObject Ramp = Resources.Load("Prefabs/Ramp") as GameObject;
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
		WallDegree.transform.localScale = new Vector3(1.314f, 1, 0.1f);
		Vector3 position = tile.transform.position + new Vector3(0, 1, 0);
		Instantiate(WallDegree, position, Quaternion.Euler(new Vector3(0, 45, 0)));
	}

	// MonoBehaviour method. Is called when the user has pressed the mouse button while over the GUIElement or Collider.
	private void OnMouseDown()
	{
		// User can only click on a tile if it's selectable.
		if (selectable && GameState.GameIsPaused)
		{
			tileSelected = true;
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
