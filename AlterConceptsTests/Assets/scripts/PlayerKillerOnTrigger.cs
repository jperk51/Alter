using UnityEngine;
using System.Collections;

public class PlayerKillerOnTrigger : MonoBehaviour
{

		void OnTriggerEnter2D (Collider2D other)
		{
				if (other.gameObject.tag == "Player" || other.gameObject.tag == "Key") {
						Application.LoadLevel (Application.loadedLevelName);
				}
		}
}
