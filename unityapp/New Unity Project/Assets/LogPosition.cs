using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class LogPosition : MonoBehaviour {
	public Text posLog; 
	public GameObject phone; 
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
		posLog.text = "(" + phone.transform.position.x + "," + phone.transform.position.y + "," + phone.transform.position.z + ")"; 
		
	}
}
