using System;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Blink : NetworkBehaviour
{
	private float blinkCd = 2.0f;
	private int blinkRange = 5;
	private float blinkCdTimer = 2.0f;
	private bool startBlinkCdTimer = false;
	private GameObject blinkBorder;

	private void Start()
	{
		blinkBorder = GameObject.Find("BlinkBorder");
	}

	private void Update()
	{
		if (startBlinkCdTimer == false)
		{
			if (Input.GetKeyDown(KeyCode.Alpha2))
			{
				transform.position += transform.forward * blinkRange;
				startBlinkCdTimer = true;
				blinkBorder.GetComponent<Image>().color = Color.grey;
			}
		}

		if (startBlinkCdTimer == true)
		{
			blinkBorder.transform.Find("CooldownText").GetComponent<Text>().text = String.Format("{0:0}", blinkCdTimer);
			blinkCdTimer -= Time.deltaTime;

			if (blinkCdTimer <= 0)
			{
				blinkBorder.GetComponent<Image>().color = Color.white;
				blinkBorder.transform.Find("CooldownText").GetComponent<Text>().text = "";
				startBlinkCdTimer = false;
				blinkCdTimer = blinkCd;
			}
		}
	}
}
