using UnityEngine;
using System.Collections;

public class SquareRotHandler : MonoBehaviour
{

		// Use this for initialization
		void Start ()
		{
				rigidbody2D.angularVelocity = Utils.SquareAngularVelocity;
		}
	
		// Update is called once per frame
		void Update ()
		{
				
		}
}
