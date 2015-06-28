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
		private int stackCount = 0;
		private bool gravityManipulationSelected = false;
		private bool frictionManipulationSelected = false;
		private bool timeManipulationSelected = false;
		private bool erasedFriction = false;
		private bool reversedGravity = false;
		private bool reversedTime = false;
		private float gravityScaleNormal = 3f;
		private float gravityScaleReversed = -3f;
		//private float frictionScaleNormal = 1f;
		//private float frictionScaleOff = 0f;

		// Use this for initialization
		void Start ()
		{
					
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (Input.GetKeyDown (KeyCode.G)) {
						gravityManipulationSelected = !gravityManipulationSelected;
						frictionManipulationSelected = false;
						timeManipulationSelected = false;
						reversedTime = false;
				} else if (Input.GetKeyDown (KeyCode.F)) {
						frictionManipulationSelected = !frictionManipulationSelected;
						gravityManipulationSelected = false;
						timeManipulationSelected = false;
						reversedTime = false;
				} else if (Input.GetKeyDown (KeyCode.T)) {
						timeManipulationSelected = !timeManipulationSelected;
						frictionManipulationSelected = false;
						gravityManipulationSelected = false;
						reversedTime = false;
				} else {
						if (gravityManipulationSelected) {
								if (Input.GetKeyDown (KeyCode.LeftAlt)) {
										reversedGravity = !reversedGravity;
										reversedTime = false;
								}
						} else if (timeManipulationSelected) {
								if (Input.GetKey (KeyCode.LeftAlt)) {
										reversedTime = true;
								} else {
										reversedTime = false;
								}
						} else if (frictionManipulationSelected) {
								if (Input.GetKeyDown (KeyCode.LeftAlt)) {
										erasedFriction = !erasedFriction;
										reversedTime = false;
								}
						}
				}
		}

		public void SetPhysics (GameObject gameObject)
		{
				if (reversedGravity) {
						gameObject.rigidbody2D.gravityScale = gravityScaleReversed;
				} else {
						gameObject.rigidbody2D.gravityScale = gravityScaleNormal;
				}

				if (reversedTime) {
						gameObject.rigidbody2D.gravityScale = 0;
				} 
		}

		public void PushPhysics ()
		{
				PhysicsInfo physicsInfoHold = new PhysicsInfo (reversedGravity, erasedFriction);
				physicsStack.Push (physicsInfoHold);
				stackCount++;
		}

		public void PopAndSetPhysics ()
		{
				PhysicsInfo physicsInfoHold = (PhysicsInfo)physicsStack.Pop ();
				reversedGravity = physicsInfoHold.GetGravitySetting ();
				erasedFriction = physicsInfoHold.GetFrictionSetting ();
		}

		public bool GetIsTimeReversalOn ()
		{
				return reversedTime;
		}

		public bool GetIsGravityReversalOn ()
		{
				return reversedGravity;
		}
}
