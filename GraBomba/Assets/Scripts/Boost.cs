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
	private PlayerController playerController;
	private Image speedBoostBorderImage;
	private Text speedBoostBorderCooldownText;

	private void Start()
	{
		if (isLocalPlayer)
		{
			speedBoostBorder = GameObject.Find("SpeedBoostBorder");
			playerController = GetComponent<PlayerController>();
			speedBoostBorderImage = speedBoostBorder.GetComponent<Image>();
			speedBoostBorderCooldownText = speedBoostBorder.transform.Find("CooldownText").GetComponent<Text>();
		}
	}

	private void Update()
	{
		if (isLocalPlayer)
		{
			if (startMovementBoostCdTimer == false)
			{
				if (Input.GetKeyDown(KeyCode.Alpha1))
				{
					playerController.movementboost = 5;
					startMovementBoostDurationTimer = true;
					startMovementBoostCdTimer = true;
					speedBoostBorderImage.color = Color.grey;
				}
			}

			if (startMovementBoostDurationTimer == true)
			{
				movementBoostDurationTimer += Time.deltaTime;

				if (movementBoostDurationTimer >= movementBoostDuration)
				{
					playerController.movementboost = 1;
					startMovementBoostDurationTimer = false;
					movementBoostDurationTimer = 0.0f;
				}
			}

			if (startMovementBoostCdTimer == true)
			{
				speedBoostBorderCooldownText.text = String.Format("{0:0}", movementBoostCdTimer);
				movementBoostCdTimer -= Time.deltaTime;

				if (movementBoostCdTimer <= 0)
				{
					speedBoostBorderImage.color = Color.white;
					speedBoostBorderCooldownText.text = "";
					startMovementBoostCdTimer = false;
					movementBoostCdTimer = movementBoostCd;
				}
			}
		}
	}
}
