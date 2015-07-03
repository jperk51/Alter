using UnityEngine;
using System.Collections;

public class GoalCollision : MonoBehaviour
{
		private bool lessOpaque = true;
		private float opacity = 100f;

		// Use this for initialization
		void Start ()
		{
				Color colorHold = gameObject.renderer.material.color;
				gameObject.renderer.material.color = new Color (colorHold.r, colorHold.g, colorHold.b, opacity / Utils.OneHundredFloat);
		}
		// Update is called once per frame
		void Update ()
		{
				if (opacity > Utils.AmountToFadeTotal && lessOpaque) {
						opacity -= Utils.AmountToFadePerFrame;
				} else {
						opacity += Utils.AmountToFadePerFrame;
						lessOpaque = isOneHundredPercentOpaque ();
				}

				Color colorHold = gameObject.renderer.material.color;
				gameObject.renderer.material.color = new Color (colorHold.r, colorHold.g, colorHold.b, opacity / Utils.OneHundredFloat);
		}

		private bool isOneHundredPercentOpaque ()
		{
				return opacity == Utils.OneHundredFloat;
		} 

		void OnTriggerEnter2D (Collider2D other)
		{		
				//Add win screen for now. Add scene switch when 2+ levels are completed
		}
}
