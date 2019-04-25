using UnityEngine;

public class MapGenerator : MonoBehaviour
{

	public void GenerateMap(Vector2 mapSize)
	{
		// Create tile that can be copied to create the map.
		GameObject tile = Instantiate(Resources.Load("Prefabs/Tile", typeof(GameObject))) as GameObject;
		tile.name = "First";
		tile.tag = "Tile";
		tile.AddComponent<Tile>();
		//Material material = Resources.Load<Material>("Tile");
		//tile.GetComponent<Renderer>().material = material;
		tile.AddComponent<BoxCollider>();
		
		string holderName = "Map";

		// If there is a map object already destroy it.
		if (GameObject.Find(holderName))
		{
			DestroyImmediate(GameObject.Find(holderName).gameObject);
		}

		// Create new object that will hold the tiles.
		Transform mapholder = new GameObject(holderName).transform;

		for (int x = 0; x < mapSize.x; x++)
		{
			Transform rowHolder = new GameObject("Row" + x).transform;
			rowHolder.parent = mapholder;
			for (int y = 0; y < mapSize.y; y++)
			{
				Vector3 tilePosition = new Vector3(-mapSize.x / 2 + 0.5f + x, 0, -mapSize.y / 2 + 0.5f + y);
				Transform newTile = Instantiate(tile.transform, tilePosition, Quaternion.identity) as Transform;
				newTile.name = "Tile" + y;
				newTile.parent = rowHolder;
			}
		}

		// Delete the tile that was made to copy.
		DestroyImmediate(GameObject.Find("First").gameObject);
	}
}
