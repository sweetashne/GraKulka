using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
	public GameObject bombPrefab;
	public Transform bombSpawn;
	[SyncVar]
	public string username = "Player";
	private float cooldown = 0.0f;
	private bool startCooldown = false;
	[SerializeField]
	public int movementboost = 1;
	[SerializeField]
	public bool canReceiveBomb = true;


	private void Start()
	{
		if (isLocalPlayer)
		{
			foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)))
			{
				if (go.name == "GameUi")
				{			
					go.SetActive(true);
				}
			}
			Camera.main.transform.position = this.transform.position - this.transform.forward * 4 + this.transform.up * 2;
			Camera.main.transform.LookAt(this.transform.position);
			Camera.main.transform.parent = this.transform;
		}

		int playerNumber = GameObject.FindGameObjectsWithTag("Player").Length;
		this.name = $"Player" + playerNumber;
	}

	void Update()
	{
		if (!isLocalPlayer)
		{
			if (startCooldown == true)
			{
				if (cooldown <= 0)
				{
					cooldown = 0;
					startCooldown = false;
				}
				else
				{
					cooldown -= Time.deltaTime;
				}
			}
			return;
		}

		float x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
		float z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f * movementboost;

		transform.Rotate(0, x, 0);
		transform.Translate(0, 0, z);
		if (Input.GetKey(KeyCode.LeftControl))
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				CmdSpawnBomb();
			}
		}

		if (startCooldown == true)
		{
			if (cooldown <= 0)
			{
				cooldown = 0;
				startCooldown = false;
			}
			else
			{
				cooldown -= Time.deltaTime;
			}
		}
	}

	[Command]
	void CmdSetPlayerID(string newID)
	{
		username = newID;
	}

	public override void OnStartLocalPlayer()
	{
		GetComponent<MeshRenderer>().material.color = Color.blue;
	}

	[Command]
	void CmdSpawnBomb()
	{
		GameObject bomb = (GameObject)Instantiate(bombPrefab, bombSpawn.position, bombSpawn.rotation);
		bomb.transform.SetParent(this.transform);
		bomb.name = "Bomb";
		NetworkServer.Spawn(bomb);
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.transform.tag == "Player" && this.transform.Find("Bomb"))
		{
			if (cooldown == 0 && collision.transform.GetComponent<PlayerController>().canReceiveBomb == true)
			{
				//collision.transform.GetComponent<CapsuleCollider>().enabled = false;
				GameObject bomb = this.transform.Find("Bomb").gameObject;
				bomb.transform.position = collision.transform.Find("BombSpawn").position;
				bomb.transform.SetParent(collision.transform);
				//collision.transform.GetComponent<CapsuleCollider>().enabled = true;
				collision.transform.GetComponent<PlayerController>().cooldown = 1.0f;
				collision.transform.GetComponent<PlayerController>().startCooldown = true;
				cooldown = 1.0f;
				startCooldown = true;
			}
		}
	}

	public void SetName(string name)
	{
		CmdSetPlayerID(name);
		username = name;
	}
}
