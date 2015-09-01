using UnityEngine;
using System.Collections;

public class TutorialGateHandler : MonoBehaviour
{

		bool openGate = false;
		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{  
				if (openGate) {
						Color colorHold = gameObject.renderer.material.color;
						gameObject.renderer.material.color = new Color (colorHold.r, colorHold.g, colorHold.b, colorHold.a - Utils.AmountToFadeGatePerFrame);
						
						if (gameObject.renderer.material.color.a <= 0) {
								Destroy (gameObject);
						}
				}
				
		}

		public void OpenGate ()
		{
				openGate = true;
		}
}
