using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameState : MonoBehaviour
    {
        public static bool GameIsPaused = true;
        public GameObject EditUi;
        public GameObject PlayUi;
        private GameObject player;
        private GameObject[] walls;
        StoredObject storedPlayer;
        List<StoredObject> storedWalls;
        GameObject npc;
        Animation animation;

        // Start is called before the first frame update
        void Start()
        {
			player = GameObject.Find("Player");
			if (GameObject.FindGameObjectWithTag("npc"))
            {
                npc = GameObject.FindGameObjectWithTag("npc");
                animation = npc.GetComponent<Animation>();
            }

            storedWalls = new List<StoredObject>();
            EditUi.SetActive(false);
            Time.timeScale = 0f;
            GameIsPaused = true;
        }

        public void Play()
        {
            SavePositions();
            EditUi.SetActive(true);
            PlayUi.SetActive(false);
            Time.timeScale = 1f;
            GameIsPaused = false;
        }

        public void Editor()
        {
            ResetPositions();
            EditUi.SetActive(false);
            PlayUi.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
        }

        void SavePositions()
        {
            //walls = GameObject.FindGameObjectsWithTag("Wall");

            //foreach (GameObject wall in walls)
            //{
            //    storedWalls.Insert(0, new StoredObject(wall.transform.position, wall.transform.rotation));
            //}
            storedPlayer = new StoredObject(player.transform.position, player.transform.rotation);
        }

        // Todo: @Bug if u reset position the walls swap components (ramp has rigidbody and falls)
        void ResetPositions()
        {
			player.GetComponent<Rigidbody>().isKinematic = true;
			player.transform.position = storedPlayer.position;
            player.transform.rotation = storedPlayer.rotation;
			player.GetComponent<Rigidbody>().isKinematic = false;
			player.GetComponent<Rigidbody>().velocity = Vector3.zero;

            //foreach (GameObject wall in walls)
            //{
            //    if (storedWalls.Count > 0)
            //    {
            //        StoredObject oldWall = storedWalls[0];
            //        wall.transform.position = oldWall.position;
            //        wall.transform.rotation = oldWall.rotation;
            //        storedWalls.RemoveAt(0);
            //    }
            //}

            if (animation != null)
            {
                animation.Play("dance");
            }
        }
    }
}
