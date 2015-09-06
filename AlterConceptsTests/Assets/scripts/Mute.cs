using UnityEngine;
using System.Collections;

public class Mute : MonoBehaviour
{

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (Input.GetKeyDown (KeyCode.P)) {
						GameObject musicHolder = GameObject.Find ("MusicHolder");
						BackgroundMusicManager bgMM = musicHolder.GetComponent<BackgroundMusicManager> ();
						bgMM.Mute ();
				}
		}
}
