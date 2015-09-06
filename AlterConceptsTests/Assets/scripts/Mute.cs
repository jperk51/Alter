using UnityEngine;
using System.Collections;

public class Mute : MonoBehaviour
{
		bool isMusicOn = true;
		BackgroundMusicManager bgMM; 
		void Awake ()
		{
				DontDestroyOnLoad (transform.gameObject);
		}

		// Use this for initialization
		void Start ()
		{
				GameObject musicHolder = GameObject.Find ("MusicHolder");
				bgMM = musicHolder.GetComponent<BackgroundMusicManager> ();
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (Input.GetKeyDown (KeyCode.P)) {
						
						bgMM.Toggle ();
						isMusicOn = !isMusicOn;
				}
		}

		void OnLevelWasLoaded ()
		{
				GameObject musicHolder = GameObject.Find ("MusicHolder");
				bgMM = musicHolder.GetComponent<BackgroundMusicManager> ();
				if (!isMusicOn) {
						bgMM.Mute ();
				}
		}
}
