using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
	public class Tile : MonoBehaviour
	{
		public bool selectable = false;
		bool tileSelected = false;
		bool GUIEnabled = false;
		GameState gameState;
		int placeableItems;
		Vector3 renderersize;

		private void Start()
		{

			gameState = FindObjectOfType<GameState>();
			if (gameState != null)
				placeableItems = gameState.GetPlaceableItemsCount();
			renderersize = GetComponent<Renderer>().bounds.size;
		}

		// Update is called every frame, if the MonoBehaviour is enabled.
		private void Update()
		{
			if (tileSelected && !Physics.CheckBox(this.transform.position + Vector3.up, new Vector3(0.25f, 0.44f, 0.25f)))
			{
				GetComponent<Renderer>().material.color = Configuration.HighlightedTileColor;
			}
			else if (selectable && GameState.GameIsPaused)
			{
				GetComponent<Renderer>().material.color = Configuration.SelectableColor;
			}
			else
			{
				GetComponent<Renderer>().material.color = Configuration.DefaultTileColor;
			}
		}

		// MonoBehaviour method. OnGUI is called for rendering and handling GUI events.
		private void OnGUI()
		{
			if (GUIEnabled)
			{
				// Checks if there is object above the tile and the tile is selected
				// TODO: Tweak numbers so you can use the tile next to the tile u press but to still see the wall above
				if (tileSelected && !Physics.CheckBox(this.transform.position + Vector3.up, new Vector3(0.25f, 0.44f, 0.25f)) && GameState.GameIsPaused)
				{
					GUILayout.Label("Choose an item to place:");

					// If user clicked the button.
					if (GUILayout.Button("Add a wall"))
					{
						AddWall(this);
						AfterMenuAction();
					}

					if (GUILayout.Button("Add a ramp"))
					{
						AddRamp(this);
						AfterMenuAction();
					}

					if (GUILayout.Button("Add a 45 degree wall"))
					{
						Add45Wall(this);
						AfterMenuAction();
					}

					if (GUILayout.Button("Add a trampoline"))
					{
						AddTrampoline(this);
						AfterMenuAction();
					}
					if (GUILayout.Button("Cancel"))
					{
						GUIEnabled = false;
						tileSelected = false;
					}
				}
			}
		}

		private void AfterMenuAction()
		{
			tileSelected = false;
		}

		private void AddRamp(Tile tile)
		{
			// Create a new object that's loaded from Resources folder.
			GameObject Ramp = Resources.Load("Prefabs/Ramp") as GameObject;
			Ramp.name = "Ramp";
			Ramp.transform.localScale = new Vector3(1, 1, 0.1f);
			Vector3 position = tile.transform.position + new Vector3(0, renderersize.y + tile.transform.localPosition.y - 0.05f, -0.2f);

			// Make an instance of the object.
			Instantiate(Ramp, position, Quaternion.Euler(new Vector3(45, 0, 0)));
		}

		private void Add45Wall(Tile tile)
		{
			GameObject WallDegree = Resources.Load("Prefabs/Wall") as GameObject;
			WallDegree.name = "45Wall";
			WallDegree.transform.localScale = new Vector3(1.314f, 1, 0.01f);
			Vector3 position = tile.transform.position + new Vector3(0, renderersize.y + tile.transform.localPosition.y, 0);
			Instantiate(WallDegree, position, Quaternion.Euler(new Vector3(0, 45, 0)));
		}

		// MonoBehaviour method. Is called when the user has pressed the mouse button while over the GUIElement or Collider.
		private void OnMouseDown()
		{

			// User can only click on a tile if it's selectable.
			if (selectable && GameState.GameIsPaused && GameObject.FindGameObjectsWithTag("PlaceableItem").Count() < placeableItems)
			{
				GUIEnabled = true;
				tileSelected = true;
			}
		}

		protected void AddWall(Tile tile)
		{
			GameObject Wall = Resources.Load("Prefabs/Wall") as GameObject;
			Wall.name = "Wall";
			Wall.transform.localScale = new Vector3(1, 1, 0.1f);
			Vector3 position = tile.transform.position + new Vector3(0, renderersize.y + tile.transform.localPosition.y, -0.5f);
			Instantiate(Wall, position, Quaternion.identity);
		}

		protected void AddTrampoline(Tile tile)
		{
			Vector3 position = new Vector3();
			GameObject Wall = Resources.Load("Prefabs/TrampolineHorizontal") as GameObject;
			Wall.name = "TrampolineHorizontal";
			Wall.transform.localScale = new Vector3(1, 0.1f, 1f);

			if (transform.position.y == 0)
			{
				position = tile.transform.position + new Vector3(0, tile.transform.localPosition.y + 0.55f, 0);
			}
			else
			{
				position = tile.transform.position + new Vector3(0, renderersize.y, 0);
			}

			Instantiate(Wall, position, Quaternion.identity);
		}
	}
}
