using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
	private List<IPlaceItems> mItems = new List<IPlaceItems>();
	public event EventHandler<ItemsEventArgs> ItemSpawned;

	public void RemoveItem(IPlaceItems item)
	{
		item.onDrop();
	}
}
