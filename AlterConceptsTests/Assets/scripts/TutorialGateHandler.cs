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
						Vector2 gatePos = gameObject.transform.position;
						gameObject.transform.position = new Vector2 (gatePos.x, gatePos.y + Utils.AmountToMoveGatePerFrame);
				}
		}

		public void OpenGate ()
		{
				openGate = true;
		}
}
