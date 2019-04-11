using UnityEditor;
using UnityEngine;

public class MapGenerator : EditorWindow
{
	float mapSize = 1f;
	string generateButton = "Generate map";
	bool generating = false;
	string status = "Idle";

	void OnGUI()
	{
		GUILayout.Label("Base Settings", EditorStyles.boldLabel);
		mapSize = EditorGUILayout.Slider("Map size", mapSize, 0, 50);
		if (GUILayout.Button(generateButton))
		{
			if (generating)  //recording
			{
				status = "Generating";
				generateButton = "Generate map";
				generating = false;
			}
			else     // idle
			{
				generateButton = "Stop";
				generating = true;
			}
		}
		EditorGUILayout.LabelField("Status: ", status);
	}

	void Update()
	{
		if (generating)
		{
			GenerateMap();
		}
	}

	void GenerateMap()
	{

	}
}
