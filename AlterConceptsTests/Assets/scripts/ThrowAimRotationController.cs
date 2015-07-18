using UnityEngine;
using System.Collections;

public class ThrowAimRotationController : MonoBehaviour
{
		bool playerHasTheKey = false;
		Color aimColor;
		float lastAngle = 0f;
		KeyController keyCon;
		// Use this for initialization
		void Start ()
		{
				aimColor = gameObject.renderer.material.color;
				gameObject.renderer.material.color = new Color (aimColor.r, aimColor.g, aimColor.b, 0f);
				keyCon = gameObject.GetComponentInParent<KeyController> ();
		}
	
		// Update is called once per frame
		void Update ()
		{
				playerHasTheKey = keyCon.PlayerHasKey ();
				if (playerHasTheKey) {
						GameObject key = GameObject.Find ("Key");
						gameObject.renderer.material.color = new Color (aimColor.r, aimColor.g, aimColor.b, 0.8f);
						SetThrowAimToPointAtMousePosition (key);
				} else {
						gameObject.renderer.material.color = new Color (aimColor.r, aimColor.g, aimColor.b, 0f);
				}
		}

		private void SetThrowAimToPointAtMousePosition (GameObject key)
		{
				Vector3 mousePos = Input.mousePosition;
				mousePos.z = 10.0f;
				mousePos = Camera.main.ScreenToWorldPoint (mousePos);
				Vector3 difference = mousePos - key.transform.position;

				float rot = Mathf.Atan2 (difference.y, difference.x) * Mathf.Rad2Deg;
				rot = LimitRotationBasedOnPlayerFacingDirection (rot);
				//Debug.Log (rot);
				lastAngle = rot;
				gameObject.transform.rotation = Quaternion.Euler (0f, 0f, rot);
		} 

		public void throwKey ()
		{
				playerHasTheKey = false;
		}

		public float getAngleOfAim ()
		{
				return lastAngle;
		}

		private float LimitRotationBasedOnPlayerFacingDirection (float rot)
		{
				if (gameObject.GetComponentInParent<KeyController> ().IsPlayerFacingRight ()) {
						rot = IsRotBetweenAngles (rot, -180f, -85f, true, -1f);
						rot = IsRotBetweenAngles (rot, 85f, 180f, true, 1f);
				} else {
						rot = IsRotBetweenAngles (rot, -95f, -1f, false, -1f);
						rot = IsRotBetweenAngles (rot, 0f, 95f, false, 1f);
				}
				return rot;
		}

		private float IsRotBetweenAngles (float rot, float minAngle, float maxAngle, bool isPlayerFacingRight, float multiplier)
		{
				
				int rotInt = Mathf.RoundToInt (rot);
				if (rotInt <= maxAngle && rotInt >= minAngle) {
						if (isPlayerFacingRight) {
								rot = Mathf.Min (Mathf.Abs (minAngle), Mathf.Abs (maxAngle)) * multiplier;
						} else {
								rot = Mathf.Max (Mathf.Abs (minAngle), Mathf.Abs (maxAngle)) * multiplier;
						}
				}
				return rot;
		}
}
