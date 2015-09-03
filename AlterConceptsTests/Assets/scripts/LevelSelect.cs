using UnityEngine;
using System.Collections;

public class LevelSelect : MonoBehaviour
{

		// Use this for initialization
		void OnMouseDown ()
		{
				int loadedLevelNumber = int.Parse (gameObject.name.Substring (5));
				Application.LoadLevel (loadedLevelNumber);
		}
}
