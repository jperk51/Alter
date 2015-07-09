using UnityEngine;
using System.Collections;

public class FadeAction : MonoBehaviour
{

		private bool lessOpaque = true;
		private float opacity = 100f;
		Color colorHold;
	
		// Use this for initialization
		void Start ()
		{
				colorHold = gameObject.renderer.material.color;
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

				gameObject.renderer.material.color = new Color (colorHold.r, colorHold.g, colorHold.b, opacity / Utils.OneHundredFloat);
		}
	
		private bool isOneHundredPercentOpaque ()
		{
				return opacity == Utils.OneHundredFloat;
		}

		void OnDestroy ()
		{
				gameObject.renderer.material.color = new Color (colorHold.r, colorHold.g, colorHold.b, 1f);
		}

}
