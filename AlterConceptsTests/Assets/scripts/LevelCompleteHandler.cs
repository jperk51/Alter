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
				clear.a = 1f;
				visible = levelCompleteTexts [0].color;
				visible.a = 1f;
				levelCompleteTexts [0].color = clear;
				levelCompleteTexts [1].color = clear;
				levelCompleteTexts [2].color = clear;
				levelCompleteTexts [3].color = clear;
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (levelComplete) {
						if (Input.GetKeyDown (KeyCode.R)) {
								Application.LoadLevel (Application.loadedLevelName);
						} else if (Input.GetKeyDown (KeyCode.C)) {
								Application.LoadLevel (GetNextLevel (Application.loadedLevelName));
						} else if (Input.GetKeyDown (KeyCode.Q)) {
								Application.Quit ();
						}
				}
		}

		public void LevelComplete ()
		{
				levelCompleteTexts [0].color = visible;
				levelCompleteTexts [1].color = visible;
				levelCompleteTexts [2].color = visible;
				levelCompleteTexts [3].color = visible;
				levelComplete = true;
		}

		private string GetNextLevel (string currentLevel)
		{
				if (currentLevel.Contains ("Tutorial")) {
						return "AlterPhysicsManipulationImplementation";
				} else if (currentLevel.Contains ("Physics")) {
						return "AlterLevelTwo";
				} else if (currentLevel.Contains ("Two")) {
						return "AlterLevelThree";
				} 
				
				return "TutorialLevel";
		}
}
