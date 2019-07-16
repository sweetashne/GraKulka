using UnityEngine;
using UnityEngine.Networking;

public class Shield : NetworkBehaviour
{
	private float shieldCd = 5.0f;
	private float shieldDuration = 6.0f;
	private float shieldCdTimer = 0.0f;
	private float shieldDurationTimer = 0.0f;
	private bool startshieldDurationTimer = false;
	private bool startshieldCdTimer = false;

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
				shieldCdTimer += Time.deltaTime;

				if (shieldCdTimer >= shieldCd)
				{
					startshieldCdTimer = false;
					shieldCdTimer = 0.0f;
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
