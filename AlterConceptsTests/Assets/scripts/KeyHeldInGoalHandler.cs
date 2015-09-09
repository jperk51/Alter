using UnityEngine;
using System.Collections;

public class KeyHeldInGoalHandler : MonoBehaviour
{

		KeyController keyCont;
		// Use this for initialization
		void Start ()
		{
				keyCont = GameObject.Find ("Key").GetComponent<KeyController> ();
		}

		void OnTriggerEnter2D (Collider2D other)
		{
				if (other.tag == "Player" && keyCont.PlayerHasKey ()) {
						LevelCompleteHandler levelComplete = GameObject.Find ("LevelCompleteText").GetComponent<LevelCompleteHandler> ();
						levelComplete.LevelComplete ();
				}
		}
}
