using UnityEngine;
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
				sounds = GetComponents<AudioSource> ();
				forward = sounds [0];
				backward = sounds [1];
				physMan = gameObject.GetComponent<PhysicsManipulation> ();
				lengthOfClip = forward.clip.length;
		}
	
		// Update is called once per frame
		void Update ()
		{
				
		}

		public void TurnOnBackwardClip ()
		{
				float currentTimeForward = forward.time;
				float getTimeToStartBackwardClip = lengthOfClip - currentTimeForward;
				backward.time = getTimeToStartBackwardClip;
				forward.Stop ();
				backward.Play ();
		}

		public void TurnOnForwardClip ()
		{
				float currectTimeBackward = backward.time;
				float getTimeToStartForwardClip = lengthOfClip - currectTimeBackward;
				forward.time = getTimeToStartForwardClip;
				backward.Stop ();
				forward.Play ();
		}
}
