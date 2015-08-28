using UnityEngine;
using System.Collections;

public class ControlHandler : MonoBehaviour
{
		GameObject controlTextToDestroyOnUse;
		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (gameObject.transform.childCount == 0) {
						TutorialGateHandler gateHandler = GameObject.Find ("GoalBlocker").GetComponent<TutorialGateHandler> ();
						gateHandler.OpenGate ();
				}
		}

		public void ControlUsed (string controlIdentifier)
		{
				controlTextToDestroyOnUse = GameObject.Find (controlIdentifier + "Text");
				
				if (controlTextToDestroyOnUse != null) {
						Destroy (controlTextToDestroyOnUse);
						if (controlIdentifier == "Throw") {
								Destroy (GameObject.Find (controlIdentifier + "Image"));
						}
				}
		}
}
