using UnityEngine;

namespace Assets.Scripts
{
    public class Walls : MonoBehaviour
    {
		bool GUIEnabled = false;

		private void OnMouseOver()
        {
            if (Input.GetMouseButtonDown(1))
            {
                if (this.name == "Wall(Clone)")
                    RotateWall();
                if (this.name == "Ramp(Clone)")
                    RotateRamp();
                if (this.name == "45Wall(Clone)")
                    RotateWallDegree();
                if (this.name == "TrampolineHorizontal(Clone)")
                    TrampolineHorizontal();
            }
        }

        private void TrampolineHorizontal()
        {
            transform.Rotate(Vector3.up, 45, Space.World);
        }

        void RotateWall()
        {
            transform.Rotate(new Vector3(0, 90, 0));
            transform.Translate(new Vector3(-0.5f, 0, -0.5f));
        }

        // TODO: @Piorutko
        void RotateRamp()
        {
            transform.Rotate(Vector3.up, 90, Space.World);
        }

        void RotateWallDegree()
        {
            transform.Rotate(new Vector3(0, 90, 0));
        }

		private void OnMouseDown()
		{
			if(GameState.GameIsPaused == true)
			GUIEnabled = true;
		}

		private void OnGUI()
		{
			if (GUIEnabled)
			{
				if (GUILayout.Button("Remove"))
				{
					DestroyImmediate(this.gameObject);
					GUIEnabled = false;
				}
			}
		}
	}
}