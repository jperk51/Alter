using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ControlHandler : MonoBehaviour
{
		GameObject controlTextToFadeOnUse;
		List<string> controlsUsed = new List<string> ();
		int numberOfControlsUsed = 0;
		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (numberOfControlsUsed == 8) {
						GameObject goalBlocker = GameObject.Find ("GoalBlocker");
						if (goalBlocker != null) {
								TutorialGateHandler gateHandler = goalBlocker.GetComponent<TutorialGateHandler> ();
								gateHandler.OpenGate ();
						}
				}
		}

		public void ControlUsed (string controlIdentifier)
		{
				if (!controlsUsed.Contains (controlIdentifier)) {
						controlTextToFadeOnUse = GameObject.Find (controlIdentifier + "Text");
				
						if (controlTextToFadeOnUse != null) {
								Color colorHold = controlTextToFadeOnUse.renderer.material.color;
								controlTextToFadeOnUse.renderer.material.color = new Color (colorHold.r, colorHold.g, colorHold.b, colorHold.a / 2.0f);
						
								if (controlIdentifier == "Throw") {
										controlTextToFadeOnUse = GameObject.Find (controlIdentifier + "Image");
										colorHold = controlTextToFadeOnUse.renderer.material.color;
										controlTextToFadeOnUse.renderer.material.color = new Color (colorHold.r, colorHold.g, colorHold.b, colorHold.a / 2.0f);
								}
						}
						controlsUsed.Add (controlIdentifier);
						numberOfControlsUsed++;
				}
		}
}
