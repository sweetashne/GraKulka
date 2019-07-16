using UnityEngine;
using UnityEngine.Networking;

public class Boost : NetworkBehaviour
{
	private float movementBoostCd = 5.0f;
	private float movementBoostDuration = 6.0f;
	private float movementBoostCdTimer = 0.0f;
	private float movementBoostDurationTimer = 0.0f;
	private bool startMovementBoostDurationTimer = false;
	private bool startMovementBoostCdTimer = false;

	private void Update()
	{
		if (startMovementBoostCdTimer == false)
		{
			if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				GetComponent<PlayerController>().movementboost = 5;
				startMovementBoostDurationTimer = true;
				startMovementBoostCdTimer = true;
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
			movementBoostCdTimer += Time.deltaTime;

			if (movementBoostCdTimer >= movementBoostCd)
			{
				startMovementBoostCdTimer = false;
				movementBoostCdTimer = 0.0f;
			}
		}
	}
}
