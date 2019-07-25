using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class BombController : NetworkBehaviour
{
	public const float countdowntime = 30.0f;

	[SyncVar]
	public float countdown = countdowntime;
	private bool countdownStop = false;
	public GameObject bombCountDownCanvas;
	private Text bombTimerText;
	private Transform bombtimer;
	private GameObject annoucer;
	private Text annoucerText;

	private void Start()
	{
		bombTimerText = bombCountDownCanvas.transform.Find("BombTimer").GetComponent<Text>();
		bombTimerText.text = countdown.ToString();
		bombtimer = bombCountDownCanvas.transform.Find("BombTimer");

		foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)))
		{
			if (go.name == "Annoucer")
			{
				annoucer = go;
				annoucerText = go.transform.Find("AnnoucerText").GetComponent<Text>();
			}
		}
	}

	private void Update()
	{
		if (countdownStop == false)
		{
			bombTimerText.text = countdown.ToString();
			countdown -= Time.deltaTime;
			bombtimer.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);

			if (countdown <= 0)
			{
				CmdSendExplodedMessage(transform.parent.GetComponent<PlayerController>().username);
			}
		}

		if (isServer && Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.R))
		{
			CmdRestart();
		}
	}

	[Command]
	void CmdSendExplodedMessage(string name)
	{
		RpcSendExplodedMessage(name);
	}

	[ClientRpc]
	void RpcSendExplodedMessage(string name)
	{
		annoucerText.text = name + " exploded";
		annoucer.SetActive(true);
		countdownStop = true;
	}

	[Command]
	void CmdRestart()
	{
		RpcRestart();
	}

	[ClientRpc]
	void RpcRestart()
	{
		annoucerText.text = "";
		annoucer.SetActive(false);
		countdownStop = false;
		countdown = countdowntime;
	}
}
