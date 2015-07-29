using UnityEngine;
using System.Collections;

public class FrictionChanger : MonoBehaviour
{
		PhysicsManipulation physMan;
		Vector2 startingPos;
		PhysicsMaterial2D friction;
		PhysicsMaterial2D noFriction;
		

		void Start ()
		{
				GameObject gmHold = GameObject.Find ("GameManager");
				physMan = gmHold.GetComponent<PhysicsManipulation> ();
				friction = gmHold.GetComponent<BoxCollider2D> ().sharedMaterial;
				noFriction = gmHold.GetComponent<CircleCollider2D> ().sharedMaterial;
				startingPos = gameObject.transform.position;
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (physMan.GetIsNoFrictonOn ()) {
						gameObject.collider2D.sharedMaterial = noFriction;
						gameObject.rigidbody2D.AddForce (new Vector2 (-1f, -1f));
				} else {
						gameObject.collider2D.sharedMaterial = friction;
						;
				}
		}
}
