using UnityEngine;
using UnityEngine.Networking;

public class Blink : NetworkBehaviour
{
	private float blinkCd = 2.0f;
	private int blinkRange = 5;
	private float blinkCdTimer = 0.0f;
	private bool startBlinkCdTimer = false;

	private void Update()
	{
		if (startBlinkCdTimer == false)
		{
			if (Input.GetKeyDown(KeyCode.Alpha2))
			{
				transform.position += transform.forward * blinkRange;
				startBlinkCdTimer = true;
			}
		}

		if (startBlinkCdTimer == true)
		{
			blinkCdTimer += Time.deltaTime;

			if (blinkCdTimer >= blinkCd)
			{
				startBlinkCdTimer = false;
				blinkCdTimer = 0.0f;
			}
		}
	}
}
