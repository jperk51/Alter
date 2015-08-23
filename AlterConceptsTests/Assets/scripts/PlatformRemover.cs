using UnityEngine;
using System.Collections;

public class PlatformRemover : MonoBehaviour
{
		bool hasPlayerLandedYet = false;

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		void OnCollisionEnter2D (Collision2D other)
		{
				if (other.transform.tag == "Player") {
						hasPlayerLandedYet = true;
				}
		}

		void OnCollisionExit2D (Collision2D other)
		{
				if (other.transform.tag == "Player" && hasPlayerLandedYet) {
						Destroy (gameObject);
				}
		}
}
