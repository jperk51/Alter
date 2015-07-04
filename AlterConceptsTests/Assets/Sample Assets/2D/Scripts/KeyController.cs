using UnityEngine;
using System.Collections;

public class KeyController : MonoBehaviour
{
		Vector2 startingPos = new Vector2 ();
		// Use this for initialization
		void Start ()
		{
				startingPos = gameObject.rigidbody2D.position;
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
}
