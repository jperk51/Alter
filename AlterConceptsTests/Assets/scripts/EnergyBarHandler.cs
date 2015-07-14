using UnityEngine;
using System.Collections;

public class EnergyBarHandler : MonoBehaviour
{
		string currentBarName = "BlueEnergyBarCover";
		float energyLevel = 240;
		PhysicsManipulation physMan;
		GameObject hundred;
		GameObject fifty;
		GameObject twoFive;

		// Use this for initialization
		void Start ()
		{
				GameObject gmHold = GameObject.Find ("GameManager");
				physMan = gmHold.GetComponent<PhysicsManipulation> ();
				hundred = GameObject.Find ("100%");
				fifty = GameObject.Find ("50%");
				twoFive = GameObject.Find ("25%");
				fifty.guiText.enabled = false;
				twoFive.guiText.enabled = false;
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (physMan.GetIsInAlterState ()) {
						moveBarDownAndShowText ();
				} else {
						moveBarUpAndHideText ();
				}
		}

		void moveBarDownAndShowText ()
		{
				if (energyLevel >= 0) {
						Vector3 posHold = gameObject.transform.position;
						gameObject.transform.position = new Vector3 (posHold.x, posHold.y - Utils.AmountToSlidePerFrame / 2.0f, posHold.z);
						energyLevel -= 0.5f;
						showText ();
				}
		}

		void moveBarUpAndHideText ()
		{
				if (energyLevel <= 240) {
						Vector3 posHold = gameObject.transform.position;
						gameObject.transform.position = new Vector3 (posHold.x, posHold.y + Utils.AmountToSlidePerFrame, posHold.z);
						energyLevel++;
						showText ();
				}
		}

		void showText ()
		{
				if (energyLevel > 120) {
						fifty.guiText.enabled = false;
						twoFive.guiText.enabled = false;
				} else if (energyLevel <= 120 && energyLevel > 60) {
						fifty.guiText.enabled = true;
						twoFive.guiText.enabled = false;
				} else {
						fifty.guiText.enabled = true;
						twoFive.guiText.enabled = true;
				}
		}
		public bool NoEnergyLeft ()
		{
				return energyLevel == 0;
		}
}
