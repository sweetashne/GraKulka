using System;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Boost : NetworkBehaviour
{
	private float movementBoostCd = 5.0f;
	private float movementBoostDuration = 6.0f;
	private float movementBoostCdTimer = 5.0f;
	private float movementBoostDurationTimer = 0.0f;
	private bool startMovementBoostDurationTimer = false;
	private bool startMovementBoostCdTimer = false;
	private GameObject speedBoostBorder;

	private void Start()
	{
		speedBoostBorder = GameObject.Find("SpeedBoostBorder");
	}

	private void Update()
	{
		if (startMovementBoostCdTimer == false)
		{
			if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				GetComponent<PlayerController>().movementboost = 5;
				startMovementBoostDurationTimer = true;
				startMovementBoostCdTimer = true;
				speedBoostBorder.GetComponent<Image>().color = Color.grey;
			}
		}

		if (startMovementBoostDurationTimer == true)
		{
			movementBoostDurationTimer += Time.deltaTime;

			if (movementBoostDurationTimer >= movementBoostDuration)
			{
				GetComponent<PlayerController>().movementboost = 1;
				startMovementBoostDurationTimer = false;
				movementBoostDurationTimer = 0.0f;
			}
		}

		if (startMovementBoostCdTimer == true)
		{
			speedBoostBorder.transform.Find("CooldownText").GetComponent<Text>().text = String.Format("{0:0}", movementBoostCdTimer);
			movementBoostCdTimer -= Time.deltaTime;

			if (movementBoostCdTimer <= 0)
			{
				speedBoostBorder.GetComponent<Image>().color = Color.white;
				speedBoostBorder.transform.Find("CooldownText").GetComponent<Text>().text = ""	;
				startMovementBoostCdTimer = false;
				movementBoostCdTimer = movementBoostCd;
			}
		}
	}
}
