using UnityEngine;
using System.Collections;

public class PlayPauseCarryOver : MonoBehaviour
{

		bool isMusicPlaying = true;
		// Use this for initialization
		void Awake ()
		{
				DontDestroyOnLoad (transform.gameObject);
		}
}
