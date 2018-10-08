using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	public GameObject ball;

	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = this.transform.position - ball.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (ball.transform.position.z <= 1829 && ball.transform.position.y >= 0) {
			this.transform.position = ball.transform.position + offset;
		}
	}
}

