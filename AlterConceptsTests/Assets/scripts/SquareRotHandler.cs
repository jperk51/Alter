using UnityEngine;
using System.Collections;

public class SquareRotHandler : MonoBehaviour
{

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				rigidbody2D.angularVelocity = 30f;
		}
}
