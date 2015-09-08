using UnityEngine;
using System.Collections;

public class LaserHandler : MonoBehaviour
{
		float maxLengthOfLaser = 30f;
		float swingShiftForLaser = 0f;
		public float distanceForEndToTravelHoriz = 3.0f;
		float direction = 1.0f;
		Vector2 endOfLaser;
		LineRenderer laser;
		// Use this for initialization
		void Start ()
		{
				laser = gameObject.GetComponent<LineRenderer> ();
				laser.SetPosition (0, gameObject.transform.position);
				laser.SetWidth (0.05f, 0.05f);
		}
	
		// Update is called once per frame
		void Update ()
		{
				DrawLaser ();
		}

		void DrawLaser ()
		{
				Vector3 firingPosition = gameObject.transform.position;
				RaycastHit2D objectHitByLaser = new RaycastHit2D ();
				Vector2 startOfLaser = new Vector2 (firingPosition.x, firingPosition.y);
				endOfLaser = new Vector2 (firingPosition.x + swingShiftForLaser, firingPosition.y - maxLengthOfLaser);
				objectHitByLaser = Physics2D.Linecast (startOfLaser, endOfLaser);
				endOfLaser = objectHitByLaser.point;
				laser.SetPosition (1, endOfLaser);
				ReactToCollision (objectHitByLaser.transform.tag);
				swingShiftForLaser += Utils.AmountToMoveLaserPerFrame * direction;
				direction = FlipDirectionIfLaserHasHitHorizLimit (startOfLaser.x, endOfLaser.x, direction);
		}
		
		float FlipDirectionIfLaserHasHitHorizLimit (float startX, float endX, float direction)
		{
				
				if (startX - endX <= -distanceForEndToTravelHoriz && direction > 0) {
						return -1.0f;
				} else if (startX - endX >= distanceForEndToTravelHoriz && direction < 0) {
						return 1.0f;
				} else {
						return direction;
				}
		}

		void ReactToCollision (string tag)
		{
				if (tag == "Player" || tag == "Key") {
						Application.LoadLevel (Application.loadedLevelName);
				}
		}
	
}
