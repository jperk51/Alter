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
				Application.LoadLevel (Application.loadedLevelName);
		}
}
