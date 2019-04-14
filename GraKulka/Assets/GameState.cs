using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
	public static bool GameIsPaused = true;
	public GameObject EditUi;
	public GameObject PlayUi;
	private GameObject player;
	private GameObject[] walls;
	Rigidbody rb;
	Vector3 playerPosition;
	private Quaternion playerRotation;
	private List<Quaternion> wallsRotations;
	private List<Vector3> wallPositions;

	// Start is called before the first frame update
	void Start()
	{
		rb = new Rigidbody();
		wallPositions = new List<Vector3>();
		wallsRotations = new List<Quaternion>();
		EditUi.SetActive(false);
		Time.timeScale = 0f;
		GameIsPaused = true;
	}


	public void Play()
	{
		SavePositions();
		EditUi.SetActive(true);
		PlayUi.SetActive(false);
		Time.timeScale = 1f;
		GameIsPaused = false;
	}

	public void Editor()
	{
		ResetPositions();
		EditUi.SetActive(false);
		PlayUi.SetActive(true);
		Time.timeScale = 0f;
		GameIsPaused = true;
	}

	void SavePositions()
	{

		player = GameObject.Find("Player");
		walls = GameObject.FindGameObjectsWithTag("Wall");

		foreach (GameObject wall in walls)
		{
			wallPositions.Insert(0, wall.transform.position);
			wallsRotations.Insert(0, wall.transform.rotation);
		}

		playerRotation = player.transform.rotation;
		playerPosition = player.transform.position;
	}

	void ResetPositions()
	{
		player.transform.position = playerPosition;
		player.transform.rotation = playerRotation;
		player.GetComponent<Rigidbody>().isKinematic = true;

		foreach (GameObject wall in walls)
		{
			if (wallPositions.Count > 0)
			{
				wall.transform.position = wallPositions[0];
				wallPositions.RemoveAt(0);
			}
			if (wallsRotations.Count > 0)
			{
				wall.transform.rotation = wallsRotations[0];
				wallsRotations.RemoveAt(0);
			}
		}
		player.GetComponent<Rigidbody>().isKinematic = false;
	}
}
