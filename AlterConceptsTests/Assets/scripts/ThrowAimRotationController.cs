using UnityEngine;
using System.Collections;

public class ThrowAimRotationController : MonoBehaviour
{
		bool playerHasTheKey = false;
		Color aimColor;
		// Use this for initialization
		void Start ()
		{
				aimColor = gameObject.renderer.material.color;
				gameObject.renderer.material.color = new Color (aimColor.r, aimColor.g, aimColor.b, 0f);
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (playerHasTheKey) {
						GameObject key = GameObject.Find ("Key");
						gameObject.renderer.material.color = new Color (aimColor.r, aimColor.g, aimColor.b, 100f);
						SetThrowAimToPointAtMousePosition (key);
				} else {
						gameObject.renderer.material.color = new Color (aimColor.r, aimColor.g, aimColor.b, 0f);
				}
		}

		public void keyHasBeenGrabbed ()
		{
				playerHasTheKey = true;
		}

		private void SetThrowAimToPointAtMousePosition (GameObject key)
		{
				Vector2 keyPos = key.rigidbody2D.position;
				Vector2 mousePos = Input.mousePosition;
		}
}
