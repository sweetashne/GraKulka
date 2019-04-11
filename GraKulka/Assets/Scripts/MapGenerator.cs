using UnityEditor;
using UnityEngine;

public class MapGenerator : EditorWindow
{
	float mapSize = 1f;
	string generateButton = "Generate Map";
	bool generating = false;
	string status = "Idle";

	void OnGUI()
	{
		GUILayout.Label("Base Settings", EditorStyles.boldLabel);
		mapSize = EditorGUILayout.Slider("Map size", mapSize, 0, 50);
		if (GUILayout.Button(generateButton))
		{
			if (generating)
			{
				generateButton = "Generate Map";
				generating = false;
				status = "Idle";
			}
			else
			{
				generateButton = "Stop";
				generating = true;
				status = "Generating";
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
