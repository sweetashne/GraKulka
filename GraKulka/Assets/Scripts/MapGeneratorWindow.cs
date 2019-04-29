#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts
{
    public class MapGeneratorWindow : EditorWindow
    {
        float mapSize = 1f;
        string generateButton = "Generate Map";
        MapGenerator map = new MapGenerator();

        void OnGUI()
        {
            GUILayout.Label("Base Settings", EditorStyles.boldLabel);
            mapSize = EditorGUILayout.Slider("Map size", mapSize, 0, 50);

            if (GUILayout.Button(generateButton))
            {
                Vector2 sizeOfMap = new Vector2(mapSize, mapSize);
                map.GenerateMap(sizeOfMap);
            }
        }
    }
}
#endif
