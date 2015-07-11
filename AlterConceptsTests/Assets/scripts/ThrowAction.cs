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

				if (Input.GetMouseButtonDown (1)) {
						gameObject.rigidbody2D.isKinematic = false;
						keyController.throwKey ();
						throwAimRot.throwKey ();
				}
		}
}
