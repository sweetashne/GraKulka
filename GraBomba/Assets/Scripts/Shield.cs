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

	private void Start()
	{
		shieldBorder = GameObject.Find("ShieldBorder");
	}

	private void Update()
	{
		if (isLocalPlayer)
		{
			if (startshieldCdTimer == false && !transform.Find("Bomb"))
			{
				if (Input.GetKeyDown(KeyCode.Alpha4))
				{
					Cmdshield();
					startshieldDurationTimer = true;
					startshieldCdTimer = true;
					shieldBorder.GetComponent<Image>().color = Color.grey;
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
				shieldBorder.transform.Find("CooldownText").GetComponent<Text>().text = String.Format("{0:0}", shieldCdTimer); 
				shieldCdTimer -= Time.deltaTime;

				if (shieldCdTimer <= 0)
				{
					shieldBorder.GetComponent<Image>().color = Color.white;
					shieldBorder.transform.Find("CooldownText").GetComponent<Text>().text = "";
					startshieldCdTimer = false;
					shieldCdTimer = shieldCd;
				}
			}
		}
	}

	[Command]
	void Cmdshield()
	{
		GetComponent<PlayerController>().canReceiveBomb = false;
		GetComponent<MeshRenderer>().material.color = Color.red;
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
		GetComponent<CapsuleCollider>().enabled = true;
		GetComponent<MeshRenderer>().material.color = Color.white;
		GetComponent<PlayerController>().canReceiveBomb = true;
		RpcResetshield();
	}

	[ClientRpc]
	void RpcResetshield()
	{
		if (isLocalPlayer)
		{
			GetComponent<MeshRenderer>().material.color = Color.blue;
			GetComponent<PlayerController>().canReceiveBomb = true;
		} 
		else
		{
			GetComponent<MeshRenderer>().material.color = Color.white;
			GetComponent<PlayerController>().canReceiveBomb = true;
		}	
	}
}
