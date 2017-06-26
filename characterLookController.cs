/*
 * Deals with rotating the camera.
 * 
 * This script should be attatched to the main camera.
 * 
 * This script is complete and you can copy/ paste as-is.
 * 
 * Note: All settings to this script should be done through the setDefaults script.
 * This script does not need to be changed.
 * 
 * Available for free from: https://github.com/B-Roux
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class characterLookController : MonoBehaviour {
	//PlayerPrefs variables
	float sensitivity;
	float smooth;
	float maxY;
	float minY;
	float invertVertical;
	float invertHorizontal;
	//locals
	Vector2 smoothV;
	Vector2 eulerAnglesVar;
	//Declarations and initializations
	GameObject character;
	void Start () {
		//innitializes the PlayerPrefs variables
		sensitivity = PlayerPrefs.GetFloat ("sensitivity");
		smooth = PlayerPrefs.GetFloat ("smoothLook");
		maxY = PlayerPrefs.GetFloat ("maxYAngle");
		minY = PlayerPrefs.GetFloat ("minYAngle");;
		invertVertical = PlayerPrefs.GetInt ("invertX");
		invertHorizontal = PlayerPrefs.GetInt ("invertX");
		//this innitializes the character as the parent object
		character = this.transform.parent.gameObject;
	}
	//Rotating the mouse
	private void Update() {
		// Move and smooth
		Vector2 mouseMove = new Vector2 (Input.GetAxisRaw ("Mouse X"), Input.GetAxisRaw ("Mouse Y"));
		mouseMove *= sensitivity * smooth;
		smoothV.x = Mathf.Lerp (smoothV.x, mouseMove.x, 1f / smooth);
		smoothV.y = Mathf.Lerp (smoothV.y, mouseMove.y, 1f / smooth);
		// Euler rotation
		eulerAnglesVar.x += smoothV.y * invertVertical;
		eulerAnglesVar.y += smoothV.x * invertHorizontal;
		eulerAnglesVar.x = Mathf.Clamp(eulerAnglesVar.x, minY, maxY);
		//apply Changes
		transform.localRotation = Quaternion.AngleAxis (-eulerAnglesVar.x, Vector3.right);
		character.transform.localRotation = Quaternion.AngleAxis (eulerAnglesVar.y, character.transform.up);
	}
}
