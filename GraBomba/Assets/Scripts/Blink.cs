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
	private Image blinkBorderImage;
	private Text blinkborderCooldownText;

	private void Start()
	{
		if (isLocalPlayer)
		{
			blinkBorder = GameObject.Find("BlinkBorder");
			blinkBorderImage = blinkBorder.GetComponent<Image>();
			blinkborderCooldownText = blinkBorder.transform.Find("CooldownText").GetComponent<Text>();
		}
	}

	private void Update()
	{
		if (isLocalPlayer)
		{
			if (startBlinkCdTimer == false)
			{
				if (Input.GetKeyDown(KeyCode.Alpha2))
				{
					transform.position += transform.forward * blinkRange;
					startBlinkCdTimer = true;
					blinkBorderImage.color = Color.grey;
				}
			}
			if (startBlinkCdTimer == true)
			{
				blinkborderCooldownText.text = String.Format("{0:0}", blinkCdTimer);
				blinkCdTimer -= Time.deltaTime;

				if (blinkCdTimer <= 0)
				{
					blinkBorderImage.color = Color.white;
					blinkborderCooldownText.text = "";
					startBlinkCdTimer = false;
					blinkCdTimer = blinkCd;
				}
			}
		}
	}
}
