using UnityEngine;
using System.Collections;

public class TutorialInfo : MonoBehaviour
{
		GUIText[] tutorialInfoTexts = new GUIText[3];
		Color clear;
		bool tutialOpen = true;
		// Use this for initialization
		void Start ()
		{
				Time.timeScale = 0f;
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (Input.GetKeyDown (KeyCode.Return)) {
						Destroy (gameObject);
						Time.timeScale = 1f;
				}
		}
}
