using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class NameChange : NetworkBehaviour
{
	[SerializeField]
	private Text usernameText;

	[SerializeField]
	private PlayerController player;

	private GameObject nameChangeCanvas;

	private InputField nameChange;

	private PlayerController player1;

	private void Start()
	{
		player1 = GameObject.Find("Player1").GetComponent<PlayerController>();
		usernameText = transform.Find("NameBar").GetComponent<Text>();

		foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)))
		{
			if (go.name == "NameChangeCanvas")
			{
				nameChangeCanvas = go;
				nameChange = go.transform.Find("NameChange").GetComponent<InputField>();
				var se = new InputField.SubmitEvent();
				se.AddListener(SubmitName);
				nameChange.onEndEdit = se;
			}
		}
	}

	private void Update()
	{
		usernameText.transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);
		usernameText.text = player.username;

		if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.N))
		{
			nameChangeCanvas.SetActive(true);
		}
	}

	void SubmitName(string name)
	{
		if (!player.isLocalPlayer)
		{
			player = player1;
			player.SetName(name);
			player.username = name;
			usernameText.text = name;
			nameChange.text = "";
			nameChangeCanvas.SetActive(false);
			player = GameObject.FindGameObjectsWithTag("Player")[GameObject.FindGameObjectsWithTag("Player").Length - 1].GetComponent<PlayerController>();
			return;
		}
		else
		{
			player.SetName(name);
			player.username = name;
			usernameText.text = name;
			nameChange.text = "";
			nameChangeCanvas.SetActive(false);
		}
	}
}
