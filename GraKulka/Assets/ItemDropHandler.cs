using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDropHandler : MonoBehaviour, IDropHandler
{
	public void OnDrop(PointerEventData eventData)
	{
		RectTransform itemPanel = transform as RectTransform;
		if (!RectTransformUtility.RectangleContainsScreenPoint(itemPanel, Input.mousePosition))
		{
			Debug.Log(itemPanel);
			RectTransform theitem = itemPanel.GetChild(0).GetChild(0) as RectTransform;
			RaycastHit hit = new RaycastHit();
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit, 1000) && hit.point.y < 1)
			{
				if (theitem.name == "Ramp")
				{
					Transform newRamp = Instantiate(Resources.Load(theitem.name), new Vector3(hit.collider.bounds.center.x - 0.5f, hit.point.y, hit.collider.bounds.center.z + 0.5f), Quaternion.Euler(0, 90, 0)) as Transform;
				}
				if (theitem.name == "270Ramp")
				{
					Transform newRamp = Instantiate(Resources.Load(theitem.name), new Vector3(hit.collider.bounds.center.x + 0.5f, hit.point.y, hit.collider.bounds.center.z - 0.5f), Quaternion.Euler(0, 270, 0)) as Transform;
				}
			}
		}
	}
}
