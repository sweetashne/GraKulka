using System;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Shield : NetworkBehaviour
{
	private float shieldCd = 5.0f;
	private float shieldDuration = 4.0f;
	private float shieldCdTimer = 5.0f;
	private float shieldDurationTimer = 0.0f;
	private bool startshieldDurationTimer = false;
	private bool startshieldCdTimer = false;
	private GameObject shieldBorder;
	private Text shieldBorderText;
	private Image shieldBorderImage;

	private void Start()
	{
		if (isLocalPlayer)
		{
			shieldBorder = GameObject.Find("ShieldBorder");
			shieldBorderText = shieldBorder.transform.Find("CooldownText").GetComponent<Text>();
			shieldBorderImage = shieldBorder.GetComponent<Image>();
		}
	}

	private void Update()
	{
		if (isLocalPlayer)
		{
			if (!startshieldCdTimer && !transform.Find("Bomb"))
			{
				if (Input.GetKeyDown(KeyCode.Alpha4))
				{
					Cmdshield();
					startshieldDurationTimer = true;
					startshieldCdTimer = true;
					shieldBorderImage.color = Color.grey;
				}
			}

			if (startshieldDurationTimer == true)
			{
				shieldDurationTimer += Time.deltaTime;

				if (shieldDurationTimer >= shieldDuration)
				{
					CmdResetshield();
					startshieldDurationTimer = false;
					shieldDurationTimer = 0.0f;
				}
			}

			if (startshieldCdTimer == true)
			{
				shieldBorderText.text = String.Format("{0:0}", shieldCdTimer);
				shieldCdTimer -= Time.deltaTime;

				if (shieldCdTimer <= 0)
				{
					shieldBorderImage.color = Color.white;
					shieldBorderText.text = "";
					startshieldCdTimer = false;
					shieldCdTimer = shieldCd;
				}
			}
		}
	}

	[Command]
	void Cmdshield()
	{
		Rpcshield();
	}

	[ClientRpc]
	void Rpcshield()
	{
		GetComponent<MeshRenderer>().material.color = Color.red;
		GetComponent<PlayerController>().canReceiveBomb = false;
	}

	[Command]
	void CmdResetshield()
	{
		RpcResetshield();
	}

	[ClientRpc]
	void RpcResetshield()
	{
		if (isLocalPlayer)
		{
			GetComponent<MeshRenderer>().material.color = Color.blue;
		}
		else
		{
			GetComponent<MeshRenderer>().material.color = Color.white;
		}

		GetComponent<PlayerController>().canReceiveBomb = true;
	}
}
