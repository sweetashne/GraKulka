﻿#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts
{
    public class Tools
    {
        // Add a menu item to unity menu.
        [MenuItem("Tools/Assign Tile Material")]
        public static void AssignTileMaterial()
        {
            GameObject[] tiles = GameObject.FindGameObjectsWithTag("Tile");
            Material material = Resources.Load<Material>("Materials/Ground07");

            foreach (GameObject tile in tiles)
            {
                tile.GetComponent<Renderer>().material = material;
            }
        }

        [MenuItem("Tools/Assign Tile Script")]
        public static void AssignTileScript()
        {
            GameObject[] tiles = GameObject.FindGameObjectsWithTag("Tile");

            foreach (GameObject tile in tiles)
            {
                tile.AddComponent<Tile>();
            }
        }

        [MenuItem("Tools/Map Generator")]
        public static void MapGenerator()
        {
            EditorWindow.GetWindow(typeof(MapGeneratorWindow));
        }
    }
}
#endif