using UnityEngine;

public class PlatformerCharacter2DCube : MonoBehaviour
{
		bool facingRight = false;							// For determining which way the player is currently facing.
		float maxSpeed = 5f;				// The fastest the player can travel in the x axis.
		float jumpForce = 300f;			// Amount of force added when the player jumps.	
		float crouchSpeed = .36f;			// Amount of maxSpeed applied to crouching movement. 1 = 100%
	
		bool airControl = true;			// Whether or not a player can steer while jumping;
		LayerMask whatIsGround;			// A mask determining what is ground to the character
	
	
		Transform groundCheck;								// A position marking where to check if the player is grounded.
		float groundedRadius = .2f;							// Radius of the overlap circle to determine if grounded
		bool grounded = false;								// Whether or not the player is grounded.
		Transform ceilingCheck;								// A position marking where to check for ceilings
		float ceilingRadius = .01f;							// Radius of the overlap circle to determine if the player can stand up
		bool upright = true;								// Is the sprite being drawn upright
		float jumpFlip = 1.0f;								// Flip jump when player is on the ceiling
		PhysicsManipulation physMan;						// Stores the PhysicsManipulation script
	
		void Start ()
		{
		}
	
		void Awake ()
		{
				// Setting up references.
				groundCheck = transform.Find ("GroundCheck");
				ceilingCheck = transform.Find ("CeilingCheck");
				GameObject gmHold = GameObject.Find ("GameManager");
				physMan = gmHold.GetComponent<PhysicsManipulation> ();
				whatIsGround = LayerMask.GetMask ("Ground");
		}
	
	
		void FixedUpdate ()
		{
				// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
				grounded = Physics2D.OverlapCircle (groundCheck.position, groundedRadius, whatIsGround);

		}
	
	
		public void Move (float move, bool jump)
		{
				//only control the player if grounded or airControl is turned on
				if (grounded || airControl) {
						// Move the character
						rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);
			
						// If the input is moving the player left and the player is facing right...
						if (move < 0) {
								TutorialControlsCheck ("MoveLeft");
								if (facingRight) {
										// ... flip the player.
										Flip ();
								}
						} else if (move > 0) {
								TutorialControlsCheck ("MoveRight");
								if (!facingRight) {
										// ... flip the player.
										Flip ();
								}
						}
			
				}

				if (physMan.GetIsGravityReversalOn () && upright) {
						FlipVertically ();
						jumpFlip = -1.0f;
				} else if (!physMan.GetIsGravityReversalOn () && !upright) {
						FlipVertically ();
						jumpFlip = 1.0f;
				}
		
				// If the player should jump...
				if (grounded && jump) {
						// Add a vertical force to the player.
						rigidbody2D.AddForce (new Vector2 (0f, jumpForce * jumpFlip));
				}
		
		}
	
	
		void Flip ()
		{
				// Switch the way the player is labelled as facing.
				facingRight = !facingRight;
		
				// Multiply the player's x local scale by -1.
				Vector3 theScale = transform.localScale;
				theScale.x *= -1;
				transform.localScale = theScale;
		}
	
		void FlipVertically ()
		{
				// Switch the way the player is labelled as facing.
				upright = !upright;
		
				// Multiply the player's x local scale by -1.
				Vector3 theScale = transform.localScale;
				theScale.y *= -1;
				transform.localScale = theScale;
		}
	
		public bool IsFacingRight ()
		{
				return facingRight;
		}

		private void TutorialControlsCheck (string direction)
		{
				if (Application.loadedLevelName == "TutorialLevel") {
						ControlHandler controlHandler = GameObject.Find ("ControlChecks").GetComponent<ControlHandler> ();
						controlHandler.ControlUsed (direction);
				}
		}
	
}
