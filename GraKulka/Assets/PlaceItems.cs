using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlaceItems
{
	string Name { get; }
	Sprite Image { get; }

	void onDrop();
}

public class ItemsEventArgs : EventArgs
{
	public ItemsEventArgs(IPlaceItems item)
	{
		Item = item;
	}

	public IPlaceItems Item;
}
