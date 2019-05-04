using UnityEngine;

namespace Assets.Scripts
{
	public class GameState : MonoBehaviour
	{
		public static bool GameIsPaused = true;
		public GameObject EditUi;
		public GameObject PlayUi;
		public GameObject Hud;
		private GameObject player;
		private StoredObject storedPlayer;
		private GameObject[] npcs;
		public int PlaceableItems = 10;

		// Start is called before the first frame update
		void Start()
		{
			player = GameObject.Find("Player");
			SavePositions();
			if (GameObject.FindGameObjectsWithTag("npc") != null)
			{
				npcs = GameObject.FindGameObjectsWithTag("npc");
			}

			EditUi.SetActive(false);
			Time.timeScale = 0f;
			GameIsPaused = true;
		}

		public void Play()
		{
			Hud.SetActive(false);
			EditUi.SetActive(true);
			PlayUi.SetActive(false);
			Time.timeScale = 1f;
			GameIsPaused = false;
		}

		public void Editor()
		{
			ResetPositions();
			Hud.SetActive(true);
			EditUi.SetActive(false);
			PlayUi.SetActive(true);
			Time.timeScale = 0f;
			GameIsPaused = true;
		}

		void SavePositions()
		{
			storedPlayer = new StoredObject(player.transform.position, player.transform.rotation, player.transform.localEulerAngles);
		}

		void ResetPositions()
		{
			player.GetComponent<Rigidbody>().isKinematic = true;
			player.transform.position = storedPlayer.position;
			player.transform.rotation = storedPlayer.rotation;
			player.transform.localEulerAngles = storedPlayer.localEulerAngles;
			player.GetComponent<Rigidbody>().velocity = Vector3.zero;
			player.GetComponent<Rigidbody>().isKinematic = false;

			if (npcs != null)
			{
				foreach (GameObject npc in npcs)
				{
					npc.GetComponent<Animation>().Play("dance");
				}
			}
		}

		public int GetPlaceableItemsCount()
		{
			return PlaceableItems;
		}
	}
}
