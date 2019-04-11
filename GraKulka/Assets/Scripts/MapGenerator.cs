using UnityEngine;

public class MapGenerator : MonoBehaviour
{
	public Transform tilePrefab;

	public void GenerateMap(Vector2 mapSize)
	{
		GameObject tile = Instantiate(Resources.Load("Prefabs/Tile", typeof (GameObject))) as GameObject;
		tile.name = "First";
		tile.tag = "Tile";
		tile.AddComponent<BoxCollider>();
		tilePrefab = tile.transform;
		string holderName = "Map";

		if (GameObject.Find("Map"))
		{
			DestroyImmediate(GameObject.Find("Map").gameObject);
		}

		Transform mapholder = new GameObject(holderName).transform;

		for (int x = 0; x < mapSize.x; x++)
		{
			Transform rowHolder = new GameObject("Row" + x).transform;
			rowHolder.parent = mapholder;
			for (int y = 0; y < mapSize.y; y++)
			{	
					Vector3 tilePosition = new Vector3(-mapSize.x / 2 + 0.5f + x, 0, -mapSize.y / 2 + 0.5f + y);
					Transform newTile = Instantiate(tilePrefab, tilePosition, Quaternion.identity) as Transform;
					newTile.name = "Tile" + y;
					newTile.parent = rowHolder;
			}
		}
		DestroyImmediate(GameObject.Find("First").gameObject);
	}
}
