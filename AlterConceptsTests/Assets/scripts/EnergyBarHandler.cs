using UnityEngine;
using System.Collections;

public class EnergyBarHandler : MonoBehaviour
{
		float energyLevel = 100;
		int counter = 0;
		PhysicsManipulation physMan;
		GUIStyle textStyle = new GUIStyle ();

		// Use this for initialization
		void Start ()
		{
				GameObject gmHold = GameObject.Find ("GameManager");
				physMan = gmHold.GetComponent<PhysicsManipulation> ();
				textStyle.normal.textColor = Color.black;
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (counter == Utils.NumberOfFramesPerPercentEnergy) {
						if (physMan.GetIsInAlterState ()) {
								subtractPercent ();
						} else {
								addPercent ();
						}
						counter = 0;
				}
				counter++;
		}

		void subtractPercent ()
		{
				if (energyLevel >= 0) {
						energyLevel--;
				}
		}

		void addPercent ()
		{
				if (energyLevel < 100) {
						energyLevel += 2;
						energyLevel = Mathf.Clamp (energyLevel, 0, 100);
				}
		}


		public bool NoEnergyLeft ()
		{
				return energyLevel == 0;
		}

		void OnGUI ()
		{
				Vector2 offsets = GetOffsets ();
				Vector2 playerPosAsScreenPoint = GameObject.Find ("Main Camera").GetComponent<Camera> ().WorldToScreenPoint (gameObject.transform.position);
				GUI.Label (new Rect (playerPosAsScreenPoint.x + offsets.x, Screen.height - playerPosAsScreenPoint.y + offsets.y, 50, 20), energyLevel + "%", textStyle);
		}

		private Vector2 GetOffsets ()
		{
				if (physMan.GetIsGravityReversalOn ()) {
						return new Vector2 (Utils.EnergyXOffset, Utils.EnergyYOffsetRG);
				} else {
						return new Vector2 (Utils.EnergyXOffset, Utils.EnergyYOffset);
				}
		}
}
