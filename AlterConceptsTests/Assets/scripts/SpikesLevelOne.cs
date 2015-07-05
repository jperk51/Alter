using UnityEngine;
using System.Collections;

public class SpikesLevelOne : MonoBehaviour
{
		bool firstDeath = true;
		bool allowRealDeath = false;
		int delayCounter = 0;
		PlatformerCharacter2D getStartingPos;

	
		// Update is called once per frame
		void Update ()
		{
			
		}

		void OnTriggerEnter2D (Collider2D other)
		{		
				/*Add this logic
				if (firstDeath) {
						
				} else
				if (allowRealDeath) {*/
				Application.LoadLevel (Application.loadedLevelName);
				//}
		}
}
