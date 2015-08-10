using UnityEngine;
using System.Collections;

public class SlideAction : MonoBehaviour
{

		int direction = -1;
		public bool isVert;
		Vector2 startingPos;
		bool slideAction = true;
		// Use this for initialization
		void Start ()
		{
				startingPos = gameObject.transform.position;
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (slideAction) {
						if (isVert) {
								slideVert ();
						} else {
								slideHoriz ();
						}
				}

		}

		public void DisableSlideAction ()
		{
				slideAction = false;
		}

		void slideVert ()
		{
				if (startingPos.y - gameObject.transform.position.y >= Utils.DistanceToMove) {
						direction = 1;
				} else if (startingPos.y - gameObject.transform.position.y <= 0) {
						direction = -1;
				}
				Vector2 currentPos = gameObject.transform.position;
				gameObject.transform.position = new Vector2 (currentPos.x, currentPos.y + (direction * Utils.AmountToMovePerFrame));
		}

		void slideHoriz ()
		{
				if (startingPos.x - gameObject.transform.position.x >= Utils.DistanceToMove) {
						direction = 1;
				} else if (startingPos.x - gameObject.transform.position.x <= 0) {
						direction = -1;
				}
				Vector2 currentPos = gameObject.transform.position;
				gameObject.transform.position = new Vector2 (currentPos.x + (direction * Utils.AmountToMovePerFrame), currentPos.y);
		}
}
