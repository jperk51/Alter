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
				if (Mathf.Abs (startingPos.y - gameObject.transform.position.y) >= Utils.DistaceToMove) {
						direction = 1;
				} else if (Mathf.Abs (startingPos.y - gameObject.transform.position.y) == 0) {
						direction = -1;
				}
				Vector2 currentPos = gameObject.transform.position;
				gameObject.transform.position = new Vector2 (currentPos.x, currentPos.y + (direction * Utils.AmountToMovePerFrame));
		}

		void slideHoriz ()
		{
				if (Mathf.Abs (startingPos.x - gameObject.transform.position.x) >= Utils.DistaceToMove) {
						direction = 1;
				} else if (Mathf.Abs (startingPos.x - gameObject.transform.position.x) == 0) {
						direction = -1;
				}
				Vector2 currentPos = gameObject.transform.position;
				gameObject.transform.position = new Vector2 (currentPos.x + (direction * Utils.AmountToMovePerFrame), currentPos.y);
		}
}
