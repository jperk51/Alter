using UnityEngine;
using System.Collections;

public class LevelCompleteHandler : MonoBehaviour
{
		GUIText[] levelCompleteTexts = new GUIText[3];
		Color clear;
		Color visible;
		bool levelComplete = false;
		// Use this for initialization
		void Start ()
		{
				levelCompleteTexts = gameObject.GetComponentsInChildren<GUIText> ();
				clear = levelCompleteTexts [0].color;
				clear.a = 0f;
				visible = levelCompleteTexts [0].color;
				visible.a = 1f;
				for (int i = 0; i < levelCompleteTexts.Length; i++) {
						levelCompleteTexts [i].color = clear;
				}
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (levelComplete) {
						if (Input.GetKeyDown (KeyCode.R)) {
								Application.LoadLevel (Application.loadedLevelName);
						} else if (Input.GetKeyDown (KeyCode.C)) {
								Application.LoadLevel (GetNextLevel (Application.loadedLevel));
						} else if (Input.GetKeyDown (KeyCode.G)) {
								Application.LoadLevel (0);
						} else if (Input.GetKeyDown (KeyCode.L)) {
								Application.LoadLevel (Utils.NumberOfLevels);
						}
				}
		}

		public void LevelComplete ()
		{
				for (int i = 0; i < levelCompleteTexts.Length; i++) {
						levelCompleteTexts [i].color = visible;
				}
				levelComplete = true;
		}

		private int GetNextLevel (int currentLevel)
		{
				if (currentLevel == Utils.NumberOfLevels) {
						return 0;
				} else {
						return currentLevel + 1;
				}
		}
}
