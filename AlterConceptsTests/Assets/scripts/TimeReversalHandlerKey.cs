using UnityEngine;
using System.Collections;

public class TimeReversalHandlerKey : MonoBehaviour
{

		KeyController keyCon;
		private Stack keyInfoStack = new Stack ();
		private int stackCount = 0;
		private int frameNumberSinceLastPush = 0;
		private int frameNumberSinceLastPop = 0;

		private class KeyReversalInfo
		{
		
				public KeyReversalInfo (bool playerHasKeyIn, Vector3 keyPosIn)
				{
						keyPos = keyPosIn;
						followPlayer = playerHasKeyIn;
				}
		
				public Vector3 GetStoredKeyPos ()
				{
						return keyPos;
				}
		
				public bool GetDoesPlayerHaveKey ()
				{
						return followPlayer;
				}
				Vector3 keyPos;
				bool followPlayer;
		
		}
		// Use this for initialization
		void Start ()
		{
				keyCon = gameObject.GetComponent<KeyController> ();
		}
	
		// Update is called once per frame
		void Update ()
		{		
		}


		public void PushKeyInfo ()
		{
				KeyReversalInfo keyInfoHold = new KeyReversalInfo (keyCon.PlayerHasKey (), gameObject.transform.position);
				keyInfoStack.Push (keyInfoHold);
		}

		public void PopKeyInfo ()
		{
				KeyReversalInfo keyInfoHold = (KeyReversalInfo)keyInfoStack.Pop ();
				gameObject.transform.position = keyInfoHold.GetStoredKeyPos ();
				keyCon.SetPlayerHasKey (keyInfoHold.GetDoesPlayerHaveKey ());
		}
}
