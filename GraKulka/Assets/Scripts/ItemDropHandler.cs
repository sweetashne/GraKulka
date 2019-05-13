using Assets.Scripts;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemDropHandler : MonoBehaviour, IDropHandler
{
	GameState gamestate;

	private void Start()
	{
		gamestate = FindObjectOfType<GameState>();
	}

	public void OnDrop(PointerEventData eventData)
	{
		RectTransform itemPanel = transform as RectTransform;
		if (!RectTransformUtility.RectangleContainsScreenPoint(itemPanel, Input.mousePosition))
		{
			RectTransform theitem = itemPanel.GetChild(0).GetChild(0) as RectTransform;
			RaycastHit hit = new RaycastHit();
			Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit, 1000) && hit.point.y < 0.6f)
			{
				Ray checkZ = new Ray(hit.collider.transform.position + new Vector3(0, 0.51f, -0.5f), new Vector3(0, 0, 0.9f));
				if (!Physics.Raycast(checkZ, 0.9f))
				{

					if (theitem.name == "rampUp")
					{
						GameObject newPlaceAbleItem = Instantiate(Resources.Load("Prefabs/" + theitem.name), new Vector3(hit.collider.bounds.center.x + 0.5f, hit.point.y + 1, hit.collider.bounds.center.z - 0.5f), Quaternion.Euler(180, 180, 0)) as GameObject;
						newPlaceAbleItem.name = theitem.name;
						gamestate.SavePlaceableItem(newPlaceAbleItem);
						gamestate.EnableUndoButton();
						theitem.parent.GetComponent<Button>().interactable = false;
						theitem.GetComponent<ItemDragHandler>().IsDragAble = false;
					}
					if (theitem.name == "rampRight")
					{
						GameObject newPlaceAbleItem = Instantiate(Resources.Load("Prefabs/" + theitem.name), new Vector3(hit.collider.bounds.center.x -0.5f, hit.point.y, hit.collider.bounds.center.z + 0.5f), Quaternion.Euler(0, 90, 0)) as GameObject;
						newPlaceAbleItem.name = theitem.name;
						gamestate.SavePlaceableItem(newPlaceAbleItem);
						gamestate.EnableUndoButton();
						theitem.parent.GetComponent<Button>().interactable = false;
						theitem.GetComponent<ItemDragHandler>().IsDragAble = false;
					}
					
				}
			}
			EventSystem.current.SetSelectedGameObject(null);
		}
	}
}
