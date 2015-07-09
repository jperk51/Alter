using UnityEngine;
using System.Collections;

public class KeyController : MonoBehaviour
{
		SlideAction slideAction;
		bool followPlayer = false;
		GameObject playerHold;
		// Use this for initialization
		void Start ()
		{
				slideAction = gameObject.GetComponent<SlideAction> ();
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (followPlayer) {
						Destroy (gameObject.GetComponent<FadeAction> ());
						
						FollowPlayer ();
				}
		}

		void OnTriggerEnter2D (Collider2D other)
		{
				if (other.tag == "Player") {
						slideAction.DisableSlideAction ();
						ThrowControllerKey throwController = gameObject.AddComponent<ThrowControllerKey> ();
						ThrowAimRotationController throwAimRot = GameObject.Find ("ThrowAimAssist").GetComponent<ThrowAimRotationController> ();
						throwAimRot.keyHasBeenGrabbed ();
						followPlayer = true;
						playerHold = GameObject.Find ("Player");
						gameObject.collider2D.enabled = false;
				}
		}

		void FollowPlayer ()
		{
				//GameObject playerHold = GameObject.Find ("Player");
				gameObject.transform.position = playerHold.transform.position;
				PlatformerCharacter2D pC2D = playerHold.GetComponent<PlatformerCharacter2D> ();
				if (pC2D.IsFacingRight ()) {
						gameObject.transform.position = new Vector2 (gameObject.transform.position.x - Utils.KeyShiftWhenCarried, gameObject.transform.position.y);
				} else {
						gameObject.transform.position = new Vector2 (gameObject.transform.position.x + Utils.KeyShiftWhenCarried, gameObject.transform.position.y);
				}
		}
}
