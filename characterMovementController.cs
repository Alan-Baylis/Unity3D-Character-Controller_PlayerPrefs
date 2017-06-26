/*
 * Deals with moving the character.
 * 
 * This script should be attatched to a rigidbody object parented to a camera that has the
 * characterLookController.cs script attatched to it. The following adjustments are not 
 * necessary, but highly reccomended: 
 * In the Rigidbody component, open the constraints menu and freeze the X and Z rotation.
 * In the Rigidbody component, open the constraints menu and freeze the Y position.
 * In the Rigidbody component, select 'Interpolate' from the Interpolate menu.
 * In the Rigidbody component, select 'Continuous' (or 'Continuous Dynamic') from the Collision Detection menu.*
 * 
 * Note: All settings to this script should be done through the setDefaults script.
 * This script does not need to be changed.
 * 
 * Available for free from: https://github.com/B-Roux
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class characterMovementController : MonoBehaviour {
	//PlayerPrefs variables
	float walkSpeed;
	float sprintMultiplier;
	string forwardMove;
	string backwardMove;
	string leftMove;
	string rightMove;
	string sprint;
	string autoSprintToggle;
	string escape;
	//locals
	float speed;
	bool autoSprint = false;
	int vertical = 0;
	int horizontal = 0;
	//initializing the cursor lockstate
	void Start () {
		//innitializes all the PlayerPrefs variables
		walkSpeed = PlayerPrefs.GetFloat("movementSpeed");
		sprintMultiplier = PlayerPrefs.GetFloat("sprintMultiplier");
		forwardMove = PlayerPrefs.GetString("forwardMoveKey");
		backwardMove = PlayerPrefs.GetString("backwardMoveKey");
		leftMove = PlayerPrefs.GetString("leftMoveKey");
		rightMove = PlayerPrefs.GetString("rightMoveKey");
		sprint = PlayerPrefs.GetString("sprintKey");
		autoSprintToggle = PlayerPrefs.GetString("autoSprintToggleKey");
		escape = PlayerPrefs.GetString("escapeKey");
		//sets the cursor lockstate
		Cursor.lockState = CursorLockMode.Locked;
	}
	void Update() {
		//sets the controls
		if (Input.GetKey (forwardMove))
			vertical = 1;
		else if (Input.GetKey (backwardMove))
			vertical = -1;
		else
			vertical = 0;
		if (Input.GetKey (rightMove))
			horizontal = 1;
		else if (Input.GetKey (leftMove))
			horizontal = -1;
		else
			horizontal = 0;
		//toggles capslock (autosprint)
		if (Input.GetKeyDown(autoSprintToggle))
		if (autoSprint) autoSprint = false; else autoSprint = true;
		//makes sure you can only sprint foreward
		if (Input.GetKey (forwardMove) && (Input.GetKey (sprint) || autoSprint)) 
			speed = walkSpeed * sprintMultiplier;
		else speed = walkSpeed;
		//getting the direction 
		float forewardBack = vertical * speed * Time.deltaTime;
		float leftRight = horizontal * speed * Time.deltaTime;
		transform.Translate (leftRight, 0, forewardBack);
		//changing the cursor lockstate upon pressing escape, or update it if it's visible.
		if(Input.anyKeyDown) Cursor.lockState = CursorLockMode.Locked;
		if(Input.GetKeyDown(escape)) Cursor.lockState = CursorLockMode.None;

	}
}
