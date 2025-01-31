﻿using UnityEngine;

namespace Assets.Scripts
{
	public class Trampoline : MonoBehaviour
	{
		public float Height = 20;
		public float HeightStrenght = 5;
		public float Strenght = 5;

		private GameObject _player;

		void Start()
		{
			_player = FindObjectOfType<Player>().gameObject;
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.tag == "Player")
			{
				var y = (int)(this.transform.localEulerAngles.y % 360) + 1;
				_player.GetComponent<Rigidbody>().velocity = GetForceVector(y);
				_player.GetComponent<Rigidbody>().AddForce(new Vector3(0, Height * Time.deltaTime, 0));
			}
		}

		private Vector3 GetForceVector(int y)
		{
			if (y >= 0 && y < 45)
			{
				return new Vector3(Strenght, HeightStrenght, 0);
			}

			if (y >= 45 && y < 90)
			{
				return new Vector3(Strenght, HeightStrenght, -Strenght);
			}

			if (y >= 90 && y < 135)
			{
				return new Vector3(0, HeightStrenght, -Strenght);
			}
			if (y >= 135 && y < 180)
			{
				return new Vector3(-Strenght, HeightStrenght, -Strenght);
			}
			if (y >= 180 && y < 225)
			{
				return new Vector3(-Strenght, HeightStrenght, 0);
			}
			if (y >= 225 && y < 270)
			{
				return new Vector3(-Strenght, HeightStrenght, Strenght);
			}

			return new Vector3(0, HeightStrenght, Strenght);
		}
	}
}
