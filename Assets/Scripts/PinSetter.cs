using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

	public Text standingDisplay;
	public int lastStandingCount = -1;
	public GameObject pinSet;

	private Ball ball;
	private bool ballEnteredBox = false;
	private float lastChangeTime;

	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
	}

	void Update ()
	{
		standingDisplay.text = CountStanding ().ToString ();

		if (ballEnteredBox) {
			CheckStanding ();
		}
	}

	public void RaisePins ()
	{
		Debug.Log ("Raising Pins");
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
			pin.RaiseIfStanding ();
		}
	}

	public void LowerPins ()
	{
		Debug.Log ("Lowering Pins");
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
			pin.Lower ();
		}
	}

	public void RenewPins ()
	{
		Debug.Log ("Renewing Pins");
		Instantiate (pinSet, new Vector3 (0, 30, 1829), Quaternion.identity);
	}

	void CheckStanding ()
	{
		// Update the lastStandingCount
		// call PinsHaveSettled () when they have

		int currentStanding = CountStanding ();

		if (currentStanding != lastStandingCount) {
			lastChangeTime = Time.time;
			lastStandingCount = currentStanding;
			return;
		}

		float settleTime = 3f; // time before considering pins have settled
		if ((Time.time - lastChangeTime) > settleTime) { // if last change > 3s ago
			PinsHaveSettled ();
		} 
	}

	void PinsHaveSettled ()
	{
		ball.Reset ();
		lastStandingCount = -1; // indicates pins have settled and ball not back in box
		ballEnteredBox = false;
		standingDisplay.color = Color.green;
	}

	int CountStanding () {
		int standing = 0;

		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()){
			if (pin.IsStanding()){
				standing++;
			}
		}

		return standing;
	}

	void OnTriggerEnter (Collider collider) {
		GameObject thingHit = collider.gameObject;

		if (thingHit.GetComponent<Ball> ()) {
			print ("Ball entered box");
			ballEnteredBox = true;
			standingDisplay.color = Color.red;
		}
	}

	void OnTriggerExit (Collider collider)
	{
		GameObject thingLeft = collider.gameObject;

		if (thingLeft.GetComponent<Pin> ()) {
			Destroy (thingLeft);
		}
	}
}
