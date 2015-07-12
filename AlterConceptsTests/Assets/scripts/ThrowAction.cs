using UnityEngine;
using System.Collections;

public class ThrowAction : MonoBehaviour
{
		
		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				ThrowAimRotationController throwAimRot = GameObject.Find ("ThrowAimAssist").GetComponent<ThrowAimRotationController> ();
				KeyController keyController = gameObject.GetComponent<KeyController> ();

<<<<<<< HEAD
				if (Input.GetMouseButtonDown (0) && keyController.PlayerHasKey ()) {
						SetThrowPropertiesForKey (throwAimRot);
						keyController.ThrowKey ();
=======
				if (Input.GetMouseButtonDown (1)) {
						gameObject.rigidbody2D.isKinematic = false;
						keyController.throwKey ();
>>>>>>> origin/master
						throwAimRot.throwKey ();
				}
		}

		private void SetThrowPropertiesForKey (ThrowAimRotationController throwAimRot)
		{
				gameObject.rigidbody2D.isKinematic = false;
				gameObject.collider2D.isTrigger = false;
				float angle = throwAimRot.getAngleOfAim ();
				Debug.Log (angle);
				float cos = Mathf.Cos (angle * Mathf.Deg2Rad);
				float sin = Mathf.Sin (angle * Mathf.Deg2Rad);
				Vector2 angledForce = new Vector2 (Utils.ThrowForce * cos, Utils.ThrowForce * sin);
				gameObject.rigidbody2D.AddForce (angledForce);
		}
}
