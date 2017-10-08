using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class toggleModes : MonoBehaviour {
	public Text buttonText; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void toggleMode() {
		buttonText.text = "changed......"; 
	}
}
