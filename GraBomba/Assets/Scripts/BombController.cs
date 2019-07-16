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

	private void Start()
	{
		bombCountDownCanvas.transform.Find("BombTimer").GetComponent<Text>().text = countdown.ToString();
	}

	private void Update()
	{
		if (countdownStop == false)
		{
			bombCountDownCanvas.transform.Find("BombTimer").GetComponent<Text>().text = countdown.ToString();
			countdown -= Time.deltaTime;
			bombCountDownCanvas.transform.Find("BombTimer").transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);
			if (countdown <= 0)
			{
				CmdSendExplodedMessage(transform.parent.GetComponent<PlayerController>().username);
			}
		}

		if (Input.GetKey(KeyCode.LeftControl))
		{
			if (Input.GetKeyDown(KeyCode.R))
			{
				CmdRestart();
			}
		}
	}

	[Command]
	void CmdSendExplodedMessage(string name)
	{
		foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)))
		{
			if (go.name == "Annoucer")
			{
				go.transform.Find("AnnoucerText").GetComponent<Text>().text = name + " exploded";
				go.SetActive(true);
				countdownStop = true;
				RpcSendExplodedMessage(name);
			}
		}
	}

	[ClientRpc]
	void RpcSendExplodedMessage(string name)
	{
		foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)))
		{
			if (go.name == "Annoucer")
			{
				go.transform.Find("AnnoucerText").GetComponent<Text>().text = name + " exploded";
				go.SetActive(true);
				countdownStop = true;
			}
		}
	}

	[Command]
	void CmdRestart()
	{
		foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)))
		{
			if (go.name == "Annoucer")
			{
				go.transform.Find("AnnoucerText").GetComponent<Text>().text = name + " exploded";
				go.SetActive(false);
				countdownStop = false;
				countdown = 30.0f;
				RpcRestart();
			}
		}
	}

	[ClientRpc]
	void RpcRestart()
	{
		foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)))
		{
			if (go.name == "Annoucer")
			{
				go.transform.Find("AnnoucerText").GetComponent<Text>().text = name + " exploded";
				go.SetActive(false);
				countdownStop = false;
				countdown = 30.0f;
			}
		}
	}
}
