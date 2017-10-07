using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropMarkers : MonoBehaviour {

	private float nextActionTime = 0.0f;
	public float period = 1.0f;
	public GameObject soundOrb; 
	public GameObject phone; 
	public bool muteMarkers = true; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Time.time > nextActionTime ) {
			nextActionTime += period;
			if (muteMarkers) {
				soundOrb.audio.mute = true; 
			}
				
			Instantiate(soundOrb, phone.transform.position, phone.transform.rotation);

			// execute block of code here
		}
	}
}
