using UnityEngine;

[RequireComponent(typeof(PlatformerCharacter2DCube))]
public class Platformer2DUserControlCube : MonoBehaviour
{
		private PlatformerCharacter2DCube character;
		private bool jump;
		PhysicsManipulation physMan; 
	
	
		void Awake ()
		{
				GameObject gmHold = GameObject.Find ("GameManager");
				physMan = gmHold.GetComponent<PhysicsManipulation> ();
				character = GetComponent<PlatformerCharacter2DCube> ();
		}
	
		void Update ()
		{
				// Read the jump input in Update so button presses aren't missed.
				#if CROSS_PLATFORM_INPUT
		if (CrossPlatformInput.GetButtonDown("Jump")) jump = true;
				#else
				if (Input.GetButtonDown ("Jump"))
						jump = true;
				#endif
				physMan.SetPhysics (this.gameObject);
		
		}
	
		void FixedUpdate ()
		{
				float h = Input.GetAxis ("Horizontal");
		
				// Pass all parameters to the character control script.
				character.Move (h, jump);
		
				// Reset the jump input once it has been used.
				jump = false;
		}
	
	
}
