/*
 * Deals with setting/ resetting the default values in the PlayerPrefs file.
 * 
 * This script should be attatched to a game object which is loaded upon scene creation.
 * 
 * This script is complete and you can copy/ paste as-is.
 * 
 * Note: This script resets all the variables to their default values upon 
 * Awake() being called. I reccomend using this script only for testing purposes, 
 * or when the control scheme does not need to be changed by the end user. For full
 * games, setting these variables from within the game would be better.
 * 
 * Remember: All scripts using PlayerPrefs from this bundle call only during the Start()
 * method - this means your game will have to restart before changes are applied.
 * 
 * Available for free from: https://github.com/B-Roux
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class setDefaults : MonoBehaviour {
	void Awake(){
		//movement controls
		PlayerPrefs.SetFloat ("movementSpeed", 2.5f);
		PlayerPrefs.SetFloat ("sprintMultiplier", 2.0f);
		//control preferences
		PlayerPrefs.SetString ("attackKey", "mouse 0");
		PlayerPrefs.SetString ("forwardMoveKey", "w");
		PlayerPrefs.SetString ("backwardMoveKey", "s");
		PlayerPrefs.SetString ("rightMoveKey", "d");
		PlayerPrefs.SetString ("leftMoveKey", "a");
		PlayerPrefs.SetString ("sprintKey","left shift");
		PlayerPrefs.SetString ("autoSprintToggleKey", "caps lock");
		PlayerPrefs.SetString ("escapeKey", "escape");
		//control inversion (set to -1 to invert or 0 to lock)
		PlayerPrefs.SetInt ("invertX", 1);
		PlayerPrefs.SetInt ("invertY", 1);
		//camera controls
		PlayerPrefs.SetFloat ("sensitivity", 3.0f);
		PlayerPrefs.SetFloat ("smoothLook", 2.0f);
		PlayerPrefs.SetFloat ("maxYAngle", 45.0f);
		PlayerPrefs.SetFloat ("minYAngle", -45.0f);
	}
}
