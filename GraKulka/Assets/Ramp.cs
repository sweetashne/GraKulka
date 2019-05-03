using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ramp : MonoBehaviour, IPlaceItems
{
	public string Name
	{
		get
		{
			return "Ramp";
		}
	}
	public Sprite _Image = null;

	public Sprite Image
	{
		get
		{
			return _Image;
		}
	}

	public void onDrop()
	{
		
	}
}
