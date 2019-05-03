using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDropHandler : MonoBehaviour, IDropHandler
{
	public void OnDrop(PointerEventData eventData)
	{
		RectTransform itemPanel = transform as RectTransform;
		

		if (!RectTransformUtility.RectangleContainsScreenPoint(itemPanel, Input.mousePosition))
		{
			RaycastHit hit = new RaycastHit();
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit, 1000))
			{
				Debug.Log(hit.point);
				Debug.Log(hit.collider.bounds);
				Transform newRamp = Instantiate(Resources.Load("Ramp"),new Vector3(hit.collider.bounds.center.x -0.5f ,hit.point.y,hit.collider.bounds.center.z + 0.5f ), Quaternion.Euler(0,90,0)) as Transform;
			}
		}
	}
}
