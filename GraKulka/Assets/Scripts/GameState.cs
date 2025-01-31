﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
	public class GameState : MonoBehaviour
	{
		public static bool GameIsPaused = true;
		public GameObject EditUi;
		public GameObject PlayUi;
		public GameObject Hud;
		public GameObject UndoUI;
		public GameObject RedoUI;
		private GameObject player;
		private StoredObject storedPlayer = new StoredObject(string.Empty, Vector3.zero, Quaternion.identity, Vector3.zero);
		private GameObject[] npcs;
		public int PlaceableItems = 10;
		List<GameObject> undoList = new List<GameObject>();
		List<StoredObject> redoList = new List<StoredObject>();

		// Start is called before the first frame update
		void Start()
		{
			Time.timeScale = 0.0f;
			player = GameObject.Find("Player");
			SavePositions();

			if (GameObject.FindGameObjectsWithTag("npc") != null)
			{
				npcs = GameObject.FindGameObjectsWithTag("npc");
			}

			Editor();
			GameIsPaused = true;
			DisableUndoButton();
			DisableRedoButton();
		}

		public void Play()
		{
			EditUi.SetActive(true);
			PlayUi.SetActive(false);
			Hud.SetActive(false);
			UndoUI.SetActive(false);
			RedoUI.SetActive(false);
			Time.timeScale = 1.0f;
			GameIsPaused = false;
		}

		public void Editor()
		{
			Hud.SetActive(true);
			UndoUI.SetActive(true);
			RedoUI.SetActive(true);
			EditUi.SetActive(false);
			PlayUi.SetActive(true);
			Time.timeScale = 0.0f;
			ResetPositions();
			GameIsPaused = true;
		}

		void SavePositions()
		{
			storedPlayer = new StoredObject(player.name, player.transform.position, player.transform.rotation, player.transform.localEulerAngles);
		}

		void ResetPositions()
		{
			player.GetComponent<Rigidbody>().isKinematic = true;
			player.transform.position = storedPlayer.position;
			player.transform.rotation = storedPlayer.rotation;
			player.transform.localEulerAngles = storedPlayer.localEulerAngles;
			player.GetComponent<Rigidbody>().velocity = Vector3.zero;
			player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
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

		public void Undo()
		{
			GameObject theLastOne = undoList[undoList.Count - 1];
			GameObject ojb = GameObject.Find("Border/" + theLastOne.name);
			ojb.GetComponent<ItemDragHandler>().IsDragAble = true;
			ojb.GetComponentInParent<Button>().interactable = true;
			redoList.Add(new StoredObject(theLastOne.name, theLastOne.transform.position, theLastOne.transform.rotation, theLastOne.transform.localEulerAngles));
			undoList.Remove(theLastOne);
			DestroyImmediate(theLastOne);

			if (redoList.Count == 1)
				EnableRedoButton();

			if (undoList.Count == 0)
				DisableUndoButton();
		}

		public void SavePlaceableItem(GameObject placeAbleItem)
		{
			undoList.Add(placeAbleItem);
		}

		private void DisableUndoButton()
		{
			GameObject undoUI = GameObject.Find("UndoButton");
			Button undoButton = undoUI.GetComponent<Button>();
			undoButton.interactable = false;
		}

		public void EnableUndoButton()
		{
			GameObject undoUI = GameObject.Find("UndoButton");
			Button undoButton = undoUI.GetComponent<Button>();
			undoButton.interactable = true;
		}

		// @Sweetashne: Make some restrictions on how many times u can redo actions.
		// Maybe restrictions on how many items can be placed is enough.
		// Look into the order of undo/redo actions and disable enable buttons/drag.
		// @Bug After some combination undo/redo works on two elements at the same time or it's my broken mouse double clicking
		public void Redo()
		{
			GameObject newPlaceAbleItem;
			StoredObject theLastOne = redoList[redoList.Count - 1];
			GameObject ojb = GameObject.Find(theLastOne.name);
			Ray checkZ = new Ray(theLastOne.position - new Vector3(-0.5f, -0.5f, 1), Vector3.forward);

			if (!Physics.Raycast(checkZ, 1))
			{
				newPlaceAbleItem = Instantiate(Resources.Load("Prefabs/" + theLastOne.name), theLastOne.position, theLastOne.rotation) as GameObject;
				newPlaceAbleItem.name = theLastOne.name;
				undoList.Add(newPlaceAbleItem);
				EnableUndoButton();
				ojb.GetComponent<ItemDragHandler>().IsDragAble = false;
				ojb.GetComponentInParent<Button>().interactable = false;
			}
			redoList.Remove(theLastOne);

			if (redoList.Count == 0)
				DisableRedoButton();
		}

		private void DisableRedoButton()
		{
			GameObject redoUI = GameObject.Find("RedoButton");
			Button redoButton = redoUI.GetComponent<Button>();
			redoButton.interactable = false;
		}

		private void EnableRedoButton()
		{
			GameObject redoUI = GameObject.Find("RedoButton");
			Button redoButton = redoUI.GetComponent<Button>();
			redoButton.interactable = true;
		}
	}
}
