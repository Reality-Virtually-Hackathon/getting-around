using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loadButton : MonoBehaviour {
	public Text t; 
	public bool muteMarkers; 
	// Use this for initialization
	void Start () {
		Button btn = this.GetComponent<Button>();
		btn.onClick.AddListener(ToggleMode);
	}
	
	// Update is called once per frame
	void ToggleMode () {
		muteMarkers = ! muteMarkers; 
		if (!muteMarkers) {
			t.text = "Dropping breadcrumbs..."; 
		} else {
			t.text = "Retracing breadcrumbs..."; 
		}
		
	}
}
