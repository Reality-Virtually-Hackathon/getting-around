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
	public AudioSource audio; 


	private bool mode = true; //mode 0 is sound on path, 1 is off path. 

	private float OffThePathThreshold = 0.1f; //half a meter. 

	// Use this for initialization
	void Start () {
		orbs = new List<GameObject> (); 
	}
	
	// Update is called once per frame
	void Update () {
		
		
		muteMarkers = button.GetComponent<loadButton>().muteMarkers;

		if (Time.time > nextActionTime) {
			nextActionTime += period;
			if (mode) { //sound on path. 
				
				if (!muteMarkers) {
					foreach (GameObject orb in orbs) {
						orb.GetComponent<AudioSource> ().mute = true; 
					}
					GameObject newOrb = Instantiate (soundOrb, phone.transform.position, phone.transform.rotation);
					orbs.Add (newOrb); 

				} else {
					foreach (GameObject orb in orbs) {
						orb.GetComponent<AudioSource> ().mute = false; 
					}
				}
			} else { //sound off path. 

				if (!muteMarkers) {
					GameObject newOrb = Instantiate (soundOrb, phone.transform.position, phone.transform.rotation);
					orbs.Add (newOrb); 

				} else {
					GameObject closestOrb;
					float closestDist = int.MaxValue; 
					foreach (GameObject orb in orbs) {
						float dist = Vector3.Distance (phone.transform.position, orb.transform.position); 
						if (dist < closestDist) {
							closestDist = dist; 
							closestOrb = orb; 
						}
						if (closestDist >= OffThePathThreshold) {
							audio.Play (); 
						}
					}

				}
			}
		}
	}
}
