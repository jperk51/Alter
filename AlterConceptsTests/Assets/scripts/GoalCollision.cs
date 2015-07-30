using UnityEngine;
using System.Collections;

public class GoalCollision : MonoBehaviour
{
		void OnTriggerEnter2D (Collider2D other)
		{
				if (other.tag == "Key") {
						LevelCompleteHandler levelComplete = GameObject.Find ("LevelCompleteText").GetComponent<LevelCompleteHandler> ();
						levelComplete.LevelComplete ();
				}
		}
}
