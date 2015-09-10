using UnityEngine;
using System.Collections;

public class KeyController : MonoBehaviour
{
		SlideAction slideAction;
		bool followPlayer = false;
		GameObject playerHold;
		PhysicsManipulation physMan;
		bool PlayerFacingRight = false;
		// Use this for initialization
		void Start ()
		{
				slideAction = gameObject.GetComponent<SlideAction> ();
				GameObject gmHold = GameObject.Find ("GameManager");
				physMan = gmHold.GetComponent<PhysicsManipulation> ();
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (followPlayer) {
						FollowPlayer ();
				} else if (!followPlayer && !gameObject.collider2D.enabled) {
			
						gameObject.collider2D.enabled = true;
				}


				physMan.SetPhysics (gameObject);

		}

		void OnCollisionEnter2D (Collision2D other)
		{
				if (other.collider.tag == "Player") {
						slideAction.DisableSlideAction ();
						ThrowAimRotationController throwAimRot = GameObject.Find ("ThrowAimAssist").GetComponent<ThrowAimRotationController> ();
						followPlayer = true;
						playerHold = GameObject.Find ("Player");
						gameObject.collider2D.enabled = false;
						gameObject.rigidbody2D.isKinematic = true;
				}
		}

		void OnCollisionExit2D (Collision2D other)
		{
				if (other.collider.tag == "Player") {
						gameObject.rigidbody2D.isKinematic = false;
				}
		}

		void FollowPlayer ()
		{
				gameObject.transform.position = playerHold.transform.position;
				PlatformerCharacter2DCube pC2D = playerHold.GetComponent<PlatformerCharacter2DCube> ();
				if (pC2D.IsFacingRight ()) {
						gameObject.transform.position = new Vector2 (gameObject.transform.position.x + Utils.KeyShiftWhenCarried, gameObject.transform.position.y);
				} else {
						gameObject.transform.position = new Vector2 (gameObject.transform.position.x - Utils.KeyShiftWhenCarried, gameObject.transform.position.y);
				}
				PlayerFacingRight = pC2D.IsFacingRight ();
		}


		public void ThrowKey ()
		{
				followPlayer = false;
		}

		public bool PlayerHasKey ()
		{
				return followPlayer;
		}

		public bool IsPlayerFacingRight ()
		{
				return PlayerFacingRight;
		}

		public void SetPlayerHasKey (bool valueForFollowPlayer)
		{
				followPlayer = valueForFollowPlayer;
		}
}
