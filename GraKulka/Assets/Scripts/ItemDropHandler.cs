using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDropHandler : MonoBehaviour, IDropHandler
{
	public void OnDrop(PointerEventData eventData)
	{
		RectTransform itemPanel = transform as RectTransform;
		if (!RectTransformUtility.RectangleContainsScreenPoint(itemPanel, Input.mousePosition))
		{
			RectTransform theitem = itemPanel.GetChild(0).GetChild(0) as RectTransform;
			RaycastHit hit = new RaycastHit();
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit, 1000) && hit.point.y < 0.6f)
			{
				Ray checkZ = new Ray(hit.collider.transform.position + new Vector3(0, 0.51f, -0.5f), new Vector3(0, 0, 0.9f));
				Debug.DrawRay(hit.collider.transform.position + new Vector3(0, 0.51f, -0.5f), new Vector3(0, 0, 0.9f), Color.red, 320320320);
				if (!Physics.Raycast(checkZ, 0.9f))
				{

					if (theitem.name == "Ramp")
					{
						Instantiate(Resources.Load(theitem.name), new Vector3(hit.collider.bounds.center.x - 0.5f, hit.point.y, hit.collider.bounds.center.z + 0.5f), Quaternion.Euler(0, 90, 0));
					}
					if (theitem.name == "270Ramp")
					{
						Instantiate(Resources.Load(theitem.name), new Vector3(hit.collider.bounds.center.x + 0.5f, hit.point.y, hit.collider.bounds.center.z - 0.5f), Quaternion.Euler(0, 270, 0));
					}
					EventSystem.current.SetSelectedGameObject(null);
				}
			}
		}
	}
}
