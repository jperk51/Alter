﻿using UnityEngine;
using System.Collections;

public class ThrowAimRotationController : MonoBehaviour
{
		bool playerHasTheKey = false;
		Color aimColor;
		float lastAngle = 0f;
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
						gameObject.renderer.material.color = new Color (aimColor.r, aimColor.g, aimColor.b, 0.8f);
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
				Vector3 mousePos = Input.mousePosition;
				mousePos.z = 10.0f;
				mousePos = Camera.main.ScreenToWorldPoint (mousePos);
				Vector3 difference = mousePos - key.transform.position;

				float rot = Mathf.Atan2 (difference.y, difference.x) * Mathf.Rad2Deg;
				gameObject.transform.rotation = Quaternion.Euler (0f, 0f, rot);
		} 
}
