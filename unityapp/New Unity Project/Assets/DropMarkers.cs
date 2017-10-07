using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropMarkers : MonoBehaviour {

	private float nextActionTime = 0.0f;
	public float period = 1.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Time.time > nextActionTime ) {
			nextActionTime += period;

			// execute block of code here
		}
	}
}
