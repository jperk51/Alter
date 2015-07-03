using UnityEngine;
using System.Collections;

public class BackGroundChangeBasedOnPhysics : MonoBehaviour
{
		Color originalBackgroundColor = new Color ();
		PhysicsManipulation physMan;
		// Use this for initialization
		void Start ()
		{
				GameObject gmHold = GameObject.Find ("GameManager");
				physMan = gmHold.GetComponent<PhysicsManipulation> ();
				originalBackgroundColor = camera.backgroundColor;
		}
	
		// Update is called once per frame
		void Update ()
		{
				// 0 = Gravity :: 1 = Friction :: 2 = Time
				bool[] whichPhysicsMansAreOn = new bool[3];
				getWhichPhysicsMansAreOn (whichPhysicsMansAreOn);
				
				//Gravity: Blue :: Friction: Red :: Time: Green :: Gravity+Friction: Violet
				if (whichPhysicsMansAreOn [2]) {
						//All on
						camera.backgroundColor = Utils.Green;
				} else if (whichPhysicsMansAreOn [0] && whichPhysicsMansAreOn [1]) {
						//G and F
						camera.backgroundColor = Utils.Violet;
				} else if (whichPhysicsMansAreOn [0]) {
						//G
						camera.backgroundColor = Utils.Blue;
				} else if (whichPhysicsMansAreOn [1]) {
						//F
						camera.backgroundColor = Utils.Red;
				} else {
						//None
						camera.backgroundColor = originalBackgroundColor;
				}
		}

		public void getWhichPhysicsMansAreOn (bool[] physicsMans)
		{
				physicsMans [0] = physMan.GetIsGravityReversalOn ();
				physicsMans [1] = physMan.GetIsNoFrictonOn ();
				physicsMans [2] = physMan.GetIsTimeReversalOn ();
		}
}
