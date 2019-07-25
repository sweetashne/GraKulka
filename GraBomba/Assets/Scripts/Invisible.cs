using System;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Invisible : NetworkBehaviour
{
	private float invisCd = 5.0f;
	private float invisDuration = 3.0f;
	private float invisCdTimer = 5.0f;
	private float invisDurationTimer = 0.0f;
	private bool startinvisDurationTimer = false;
	private bool startinvisCdTimer = false;
	private GameObject invisBorder;
	private Image invisBorderImage;
	private Text invisBorderCoolDownText;

	private void Start()
	{
		if (isLocalPlayer)
		{
			invisBorder = GameObject.Find("InvisBorder");
			invisBorderImage = invisBorder.GetComponent<Image>();
			invisBorderCoolDownText = invisBorder.transform.Find("CooldownText").GetComponent<Text>();
		}
	}

	private void Update()
	{
		if (isLocalPlayer)
		{
			if (startinvisCdTimer == false)
			{
				if (Input.GetKeyDown(KeyCode.Alpha3))
				{
					CmdInvis();
					startinvisDurationTimer = true;
					startinvisCdTimer = true;
					invisBorderImage.color = Color.grey;
				}
			}

			if (startinvisDurationTimer == true)
			{
				invisDurationTimer += Time.deltaTime;

				if (invisDurationTimer >= invisDuration)
				{
					CmdResetInvis();
					startinvisDurationTimer = false;
					invisDurationTimer = 0.0f;
				}
			}

			if (startinvisCdTimer == true)
			{
				invisBorderCoolDownText.text = String.Format("{0:0}", invisCdTimer);
				invisCdTimer -= Time.deltaTime;

				if (invisCdTimer <= 0)
				{
					invisBorderImage.color = Color.white;
					invisBorderCoolDownText.text = "";
					startinvisCdTimer = false;
					invisCdTimer = invisCd;
				}
			}
		}
	}

	[Command]
	void CmdInvis()
	{
		RpcInvis();
	}

	[ClientRpc]
	void RpcInvis()
	{
		if (isLocalPlayer)
		{
			GetComponent<MeshRenderer>().material.color = Color.grey;
		}
		else
		{
			GetComponent<MeshRenderer>().enabled = false;
			transform.Find("Visor").GetComponent<MeshRenderer>().enabled = false;
			transform.Find("NameBarCanvas").GetComponent<Canvas>().enabled = false;
		}
	}

	[Command]
	void CmdResetInvis()
	{
		RpcResetInvis();
	}

	[ClientRpc]
	void RpcResetInvis()
	{
		if (isLocalPlayer)
		{
			GetComponent<MeshRenderer>().material.color = Color.blue;
		}
		else
		{
			GetComponent<MeshRenderer>().enabled = true;
			transform.Find("Visor").GetComponent<MeshRenderer>().enabled = true;
			transform.Find("NameBarCanvas").GetComponent<Canvas>().enabled = true;
		}
	}
}
