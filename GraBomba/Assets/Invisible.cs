using UnityEngine;
using UnityEngine.Networking;

public class Invisible : NetworkBehaviour
{
	private float invisCd = 5.0f;
	private float invisDuration = 3.0f;
	private float invisCdTimer = 0.0f;
	private float invisDurationTimer = 0.0f;
	private bool startinvisDurationTimer = false;
	private bool startinvisCdTimer = false;

	private void Update()
	{
		if (isLocalPlayer)
		{

			if (startinvisCdTimer == false)
			{
				if (Input.GetKeyDown(KeyCode.Alpha3))
				{
					CmdInvis();
					//Camera.main.cullingMask = 2;
					//GetComponent<MeshRenderer>().enabled = false;
					startinvisDurationTimer = true;
					startinvisCdTimer = true;
				}
			}

			if (startinvisDurationTimer == true)
			{
				invisDurationTimer += Time.deltaTime;

				if (invisDurationTimer >= invisDuration)
				{
					CmdResetInvis();
					//Camera.main.cullingMask = 1;
					//GetComponent<MeshRenderer>().enabled = true;
					startinvisDurationTimer = false;
					invisDurationTimer = 0.0f;
				}
			}

			if (startinvisCdTimer == true)
			{
				invisCdTimer += Time.deltaTime;

				if (invisCdTimer >= invisCd)
				{
					startinvisCdTimer = false;
					invisCdTimer = 0.0f;
				}
			}
		}
	}

	[Command]
	void CmdInvis()
	{
		GetComponent<MeshRenderer>().enabled = false;
		transform.Find("Visor").GetComponent<MeshRenderer>().enabled = false;
		transform.Find("NameBarCanvas").GetComponent<Canvas>().enabled = false;
		RpcInvis();
	}

	[ClientRpc]
	void RpcInvis()
	{
		GetComponent<MeshRenderer>().enabled = false;
		transform.Find("Visor").GetComponent<MeshRenderer>().enabled = false;
		transform.Find("NameBarCanvas").GetComponent<Canvas>().enabled = false;
	}

	[Command]
	void CmdResetInvis()
	{
		GetComponent<MeshRenderer>().enabled = true;
		transform.Find("Visor").GetComponent<MeshRenderer>().enabled = true;
		transform.Find("NameBarCanvas").GetComponent<Canvas>().enabled = true;
		RpcResetInvis();
	}

	[ClientRpc]
	void RpcResetInvis()
	{
		GetComponent<MeshRenderer>().enabled = true;
		transform.Find("Visor").GetComponent<MeshRenderer>().enabled = true;
		transform.Find("NameBarCanvas").GetComponent<Canvas>().enabled = true;

	}
}
