using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragHandler : MonoBehaviour, IDragHandler, IEndDragHandler
{
	public bool IsDragAble;

	private void Start()
	{
		IsDragAble = true;
	}

	public void OnDrag(PointerEventData eventData)
	{
		if (IsDragAble)
			transform.position = Input.mousePosition;
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		transform.localPosition = Vector3.zero;
	}
}
