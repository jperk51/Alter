using UnityEngine;
using System.Collections;

public class EnergyBarHandler : MonoBehaviour
{
		float energyLevel = 100;
		int counter = 0;
		PhysicsManipulation physMan;

		// Use this for initialization
		void Start ()
		{
				GameObject gmHold = GameObject.Find ("GameManager");
				physMan = gmHold.GetComponent<PhysicsManipulation> ();
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
						gameObject.guiText.text = energyLevel + "%";
				}
		}

		void addPercent ()
		{
				if (energyLevel < 100) {
						energyLevel += 2;
						energyLevel = Mathf.Clamp (energyLevel, 0, 100);
						gameObject.guiText.text = energyLevel + "%";
				}
		}
	


		public bool NoEnergyLeft ()
		{
				return energyLevel == 0;
		}
}
