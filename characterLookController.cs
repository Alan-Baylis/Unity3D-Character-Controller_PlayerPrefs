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
	private float sensitivity;
	private float smooth;
	private float maxY;
	private float minY;
	private float invertVertical;
	private float invertHorizontal;
	//locals
	private Vector2 smoothV;
	private Vector2 eulerAnglesVar;
	private GameObject character;
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
	void LateUpdate() {
		// Move and smooth
		Vector2 mouseMove = new Vector2 (Input.GetAxis ("Mouse X"), Input.GetAxis ("Mouse Y"));
		mouseMove *= sensitivity;
		smoothV.x = Mathf.LerpAngle (smoothV.x, mouseMove.x, (Time.smoothDeltaTime * smooth));
		smoothV.y = Mathf.LerpAngle (smoothV.y, mouseMove.y, (Time.smoothDeltaTime * smooth));
		// Euler rotation
		eulerAnglesVar.x = Mathf.Clamp ((eulerAnglesVar.x + smoothV.y * invertVertical), minY, maxY);
		eulerAnglesVar.y += smoothV.x * invertHorizontal;
		//apply Changes
		transform.localRotation = Quaternion.AngleAxis (-eulerAnglesVar.x, Vector3.right);
		character.transform.localRotation = Quaternion.AngleAxis (eulerAnglesVar.y, character.transform.up);
	}
}
