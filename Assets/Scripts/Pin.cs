using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

	public float standingThreshold = 10f;
	public float distToRaise = 40f;

	private Rigidbody myRigidBody;

	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody>();

		IsStanding ();
	}

	public void RaiseIfStanding ()
	{
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
			if (IsStanding ()) {
				myRigidBody.useGravity = false;
				transform.Translate (new Vector3 (0, distToRaise, 0), Space.World);
			}
		}
	}

	public void Lower ()
	{
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
			transform.Translate (new Vector3 (0, -distToRaise, 0), Space.World);
			myRigidBody.useGravity = true;
		}
	}


	
	public bool IsStanding ()
	{
		Vector3 rotationInEuler = transform.rotation.eulerAngles;

		float tiltInX = Mathf.Abs (270 - rotationInEuler.x);
		float tiltInZ = Mathf.Abs (rotationInEuler.z);

		if (tiltInX < standingThreshold && tiltInZ < standingThreshold){
			return true;
		} else {
			return false;
		}
	}
}
