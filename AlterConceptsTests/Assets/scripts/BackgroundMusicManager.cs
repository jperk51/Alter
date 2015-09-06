﻿using UnityEngine;
using System.Collections;

public class BackgroundMusicManager : MonoBehaviour
{

		PhysicsManipulation physMan;
		public AudioSource[] sounds;
		public AudioSource forward;
		public AudioSource backward;
		float lengthOfClip;

		// Use this for initialization
		void Start ()
		{

		}
	
		// Update is called once per frame
		void Update ()
		{
				
		}

		public void TurnOnBackwardClip ()
		{
				sounds = GetComponents<AudioSource> ();
				forward = sounds [0];
				backward = sounds [1];
				physMan = GameObject.Find ("GameManager").GetComponent<PhysicsManipulation> ();
				lengthOfClip = forward.clip.length;
				float currentTimeForward = forward.time;
				float getTimeToStartBackwardClip = lengthOfClip - currentTimeForward;
				backward.time = getTimeToStartBackwardClip;
				forward.Stop ();
				backward.Play ();
		}

		public void TurnOnForwardClip ()
		{
				sounds = GetComponents<AudioSource> ();
				forward = sounds [0];
				backward = sounds [1];
				physMan = GameObject.Find ("GameManager").GetComponent<PhysicsManipulation> ();
				lengthOfClip = forward.clip.length;
				float currectTimeBackward = backward.time;
				float getTimeToStartForwardClip = lengthOfClip - currectTimeBackward;
				forward.time = getTimeToStartForwardClip;
				backward.Stop ();
				forward.Play ();
		}

		public void Toggle ()
		{
				sounds = GetComponents<AudioSource> ();
				for (int i = 0; i < sounds.Length; i++) {
						if (sounds [i].volume != 0) {
								sounds [i].volume = 0;
						} else {
								sounds [i].volume = 1;
						}
				}
		}

		public void Mute ()
		{
				sounds = GetComponents<AudioSource> ();
				for (int i = 0; i < sounds.Length; i++) {
						sounds [i].volume = 0;
						
				}
		}
}
