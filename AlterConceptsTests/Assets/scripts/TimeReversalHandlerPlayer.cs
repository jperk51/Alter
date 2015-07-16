﻿using UnityEngine;
using System.Collections;

public class TimeReversalHandlerPlayer : MonoBehaviour
{
		PhysicsManipulation physMan;
		TimeReversalHandlerKey timeKey;
		private Stack transformStack = new Stack ();
		private int stackCount = 0;
		private int frameNumberSinceLastPush = 0;
		private int frameNumberSinceLastPop = 0;
		// Use this for initialization
		void Start ()
		{
				GameObject gmHold = GameObject.Find ("GameManager");
				physMan = gmHold.GetComponent<PhysicsManipulation> ();
				timeKey = GameObject.Find ("Key").GetComponent<TimeReversalHandlerKey> ();
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (frameNumberSinceLastPush % Utils.FramesPerPush == 0) {
						if (transformStack.Count < Utils.MaxStackCount && WasThereAChange ()) {
								transformStack.Push (gameObject.transform.position);
								physMan.PushPhysics ();
								timeKey.PushKeyInfo ();
								stackCount++;
						}
						frameNumberSinceLastPush = 1;
				}
				frameNumberSinceLastPush++;

				if (physMan.GetIsTimeReversalOn ()) {
						if (transformStack.Count > 0 && frameNumberSinceLastPop % Utils.FramesPerPop == 0) {
								gameObject.transform.position = (Vector3)transformStack.Pop ();
								physMan.PopAndSetPhysics ();
								timeKey.PopKeyInfo ();
								stackCount--;
								frameNumberSinceLastPush = 1;
								frameNumberSinceLastPop = 1;
						} else {
								frameNumberSinceLastPush = 1;
								frameNumberSinceLastPop++;
						}
				}
		}

		bool WasThereAChange ()
		{
				if (transformStack.Count > 0) {
						Vector3 posToCheck = (Vector3)transformStack.Pop ();
						bool change = (posToCheck != gameObject.transform.position);
						transformStack.Push (posToCheck);
						return change;
				}

				return true;
		}
}
