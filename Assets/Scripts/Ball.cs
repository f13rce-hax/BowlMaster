using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public bool inPlay;
	public Vector3 launchVelocity;

	private Rigidbody rigidBody;
	private AudioSource audioSource;
	private Vector3 startPos;

	// Use this for initialization
	void Start ()
	{
		inPlay = false;
		rigidBody = GetComponent<Rigidbody> ();
		rigidBody.useGravity = false;
		startPos = this.transform.position;
	}

	public void Launch (Vector3 velocity)
	{
		inPlay = true;

		rigidBody.useGravity = true;
		rigidBody.velocity = velocity;

		 audioSource = GetComponent<AudioSource>();
	 	 audioSource.Play(); 
	}

	public void Reset ()
	{
		inPlay = false;
		this.transform.position = startPos;
		rigidBody.velocity = Vector3.zero;
		rigidBody.angularVelocity = Vector3.zero;
		rigidBody.useGravity = false;
	}
}

