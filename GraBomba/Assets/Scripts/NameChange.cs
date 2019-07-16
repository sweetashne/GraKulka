using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class NameChange : NetworkBehaviour
{
	[SerializeField]
	private Text usernameText;

	[SerializeField]
	private PlayerController player;

	private GameObject hmm;

	private InputField nameChange;

	private void Update()
	{
		usernameText.transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);
		usernameText.text = player.username;
		if (Input.GetKey(KeyCode.LeftControl))
		{
			if (Input.GetKeyDown(KeyCode.N))
			{
				foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)))
				{
					if (go.name == "NameChangeCanvas")
					{
						hmm = go;
						go.SetActive(true);
						nameChange = go.transform.Find("NameChange").GetComponent<InputField>();
						var se = new InputField.SubmitEvent();
						se.AddListener(SubmitName);
						nameChange.onEndEdit = se;
					}
				}
			}
		}
	}

	void SubmitName(string name)
	{
		if (!player.isLocalPlayer)
		{
			player = GameObject.Find("Player1").GetComponent<PlayerController>();
			player.SetName(name);
			player.username = name;
			usernameText.text = name;
			hmm.SetActive(false);
			player = GameObject.FindGameObjectsWithTag("Player")[GameObject.FindGameObjectsWithTag("Player").Length - 1].GetComponent<PlayerController>();
			return;
		}
		else
		{
			player.SetName(name);
			player.username = name;
			usernameText.text = name;
			hmm.SetActive(false);
		}
	}
}
