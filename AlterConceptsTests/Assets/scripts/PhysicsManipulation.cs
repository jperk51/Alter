using UnityEngine;
using System.Collections;

public class PhysicsManipulation : MonoBehaviour
{
		private class PhysicsInfo
		{

				public PhysicsInfo (bool gravitySetting, bool frictionSetting)
				{
						reversedGravitySetting = gravitySetting;
						erasedFrictionSetting = frictionSetting;
				}

				public bool GetGravitySetting ()
				{
						return reversedGravitySetting;
				}

				public bool GetFrictionSetting ()
				{
						return erasedFrictionSetting;
				}
				bool reversedGravitySetting;
				bool erasedFrictionSetting;

		}


		public Stack physicsStack = new Stack ();
		BackgroundMusicManager music;
		private int stackCount = 0;
		private bool alterModeEnabled = false;
		private bool noFriction = false;
		private bool reversedGravity = false;
		private bool reversedTime = false;

		

		// Use this for initialization
		void Start ()
		{
				music = gameObject.GetComponent<BackgroundMusicManager> ();
				music.TurnOnForwardClip ();
		}
	
		// Update is called once per frame
		void Update ()
		{

				if (Input.GetKeyDown (KeyCode.LeftAlt) || Input.GetKeyDown (KeyCode.RightAlt)) {
						alterModeEnabled = !alterModeEnabled;
				}

				if (alterModeEnabled) {
						if (Input.GetKeyDown (KeyCode.G)) {
								reversedGravity = ! reversedGravity;
								reversedTime = false;
						} else if (Input.GetKeyDown (KeyCode.F)) {
								noFriction = !noFriction;
								reversedTime = false;
						} else if (Input.GetKeyDown (KeyCode.T)) {
								reversedTime = true;
								music.TurnOnBackwardClip ();
						} else if (Input.GetKeyUp (KeyCode.T)) {
								reversedTime = false;
								music.TurnOnForwardClip ();
						}
				}
		}

		public void SetPhysics (GameObject gameObject)
		{
				float keyGavityShift = 1f;
				if (gameObject.tag == "Key") {
						keyGavityShift = 0.5f;
				}

				if (reversedTime) {
						gameObject.rigidbody2D.gravityScale = 0;
						gameObject.rigidbody2D.velocity = Utils.ZeroVelocity;
				} else if (reversedGravity) {
						gameObject.rigidbody2D.gravityScale = Utils.GravityScale * Utils.NegativeOneFloat * keyGavityShift;
				} else {
						gameObject.rigidbody2D.gravityScale = Utils.GravityScale * keyGavityShift;
				}
		}

		public void PushPhysics ()
		{
				PhysicsInfo physicsInfoHold = new PhysicsInfo (reversedGravity, noFriction);
				physicsStack.Push (physicsInfoHold);
				stackCount++;
		}

		public void PopAndSetPhysics ()
		{
				PhysicsInfo physicsInfoHold = (PhysicsInfo)physicsStack.Pop ();
				reversedGravity = physicsInfoHold.GetGravitySetting ();
				noFriction = physicsInfoHold.GetFrictionSetting ();
		}

		public bool GetIsTimeReversalOn ()
		{
				return reversedTime;
		}

		public bool GetIsGravityReversalOn ()
		{
				return reversedGravity;
		}

		public bool GetIsNoFrictonOn ()
		{
				return noFriction;
		}
}
