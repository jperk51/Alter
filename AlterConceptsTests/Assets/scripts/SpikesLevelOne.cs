using UnityEngine;
using System.Collections;

public class SpikesLevelOne : MonoBehaviour
{
		bool firstDeath = true;
		bool allowRealDeath = false;
		int delayCounter = 0;
		PlatformerCharacter2D getStartingPos;

		void OnCollisionEnter2D (Collision2D other)
		{
				if (other.gameObject.tag == "Player" || other.gameObject.tag == "Key") {
						Application.LoadLevel (Application.loadedLevelName);
				}
		}
}
