using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropMarkers : MonoBehaviour {

	private float nextActionTime = 0.0f;
	public float period = 1.0f;
	public GameObject button; 
	public GameObject soundOrb; 
	public GameObject phone; 
	public bool muteMarkers = true; 
	public GameObject parentOrb; 
	public List<GameObject> orbs; 

	// Use this for initialization
	void Start () {
		orbs = new List<GameObject> (); 
	}
	
	// Update is called once per frame
	void Update () {
		
		muteMarkers = button.GetComponent<loadButton>().muteMarkers;

		if (Time.time > nextActionTime ) {
			nextActionTime += period;
			if (! muteMarkers) {
				foreach (GameObject orb in orbs) {
					orb.GetComponent<AudioSource> ().mute = false; 
				}
				GameObject newOrb = Instantiate(soundOrb, phone.transform.position, phone.transform.rotation);
				orbs.Add (newOrb); 

			} else {
				foreach (GameObject orb in orbs) {
					orb.GetComponent<AudioSource> ().mute = true; 
				}
			}
		}
	}
}

