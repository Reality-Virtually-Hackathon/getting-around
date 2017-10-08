using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeoLocate : MonoBehaviour {


	private float nextActionTime = 0.0f;
	private float period = 1.0f;

	float RADIUS = 10f;
	private bool first = true; 
	private Dictionary<string, AudioClip> data = new Dictionary<string, AudioClip>(); 
	private Dictionary<string, bool> visited = new Dictionary<string, bool>(); 
	public GameObject person; 
	private AudioSource speaker; 
	public GameObject btn; 

	// Use this for initialization
	void Start () {
		Input.location.Start();


		//default sounds 
		speaker = person.GetComponent<AudioSource> (); 
		AudioClip atm  = Resources.Load("atm") as AudioClip;
		AudioClip aero  = Resources.Load("aero") as AudioClip;
		AudioClip bar  = Resources.Load("bar") as AudioClip;
		AudioClip bells  = Resources.Load("bells") as AudioClip;
		AudioClip birds  = Resources.Load("birds") as AudioClip;
		AudioClip birds_stereo  = Resources.Load("birds_stereo") as AudioClip;
		AudioClip bus  = Resources.Load("bus") as AudioClip;
		AudioClip coffee  = Resources.Load("coffee") as AudioClip;
		AudioClip coop  = Resources.Load("coop") as AudioClip;
		AudioClip frog  = Resources.Load("frog") as AudioClip;
		AudioClip google  = Resources.Load("google") as AudioClip;
		AudioClip paper  = Resources.Load("paper") as AudioClip;
		AudioClip post  = Resources.Load("post") as AudioClip;
		AudioClip students  = Resources.Load("students") as AudioClip;
		AudioClip student_entrance  = Resources.Load("student_entrance") as AudioClip;
		AudioClip subway  = Resources.Load("subway") as AudioClip;
		AudioClip walkway  = Resources.Load("walkway") as AudioClip;


		//test 
//		speaker.clip = bells; 
//		speaker.Play(); 


		//load audio files 


		//load default routes
		data ["42_360851727921535 -71_08802855014801"] = bells;
		data ["42_361338, -71_088244  "]	= birds_stereo; //old = 42_36118072692198 -71_08821630477905
		data ["42_361522 -71_088255"] = post; //old =    	42_36148990513537 -71_0882431268692
		data ["42_361606 -71_088166"] = student_entrance; 
		data ["42_361913 -71_088145"] = atm; 

		data ["42_362120, -71_088144 "] = frog; //old - 42_361699986899495 -71_08853280544281"

		data ["42_362462 -71_087767"] = aero; //old = 42_36176300509831 -71_08808755874634

		data ["42_36249432125361 -71_0858291387558"] = bus;
		data ["42_36249808371944 -71_08513176441193"] = subway;
		data ["42_362379 -71_088210"] = walkway; //old = ??? 
		data ["42_362626905458896 -71_08663111925125"] = coop; 
		data ["42_36266545128742 -71_0870911180973"] = google; 
		data ["42_36267139689614 -71_08754508197308"] = coffee; 
		data ["42_36270439965933 -71_08797490596771"] = bar; 
		data ["42_36283995621765 -71_0861349105835"] = paper; 
		data ["42_361927, -71_088143"] = students; 

 


		//load bools
		visited ["42_360851727921535 -71_08802855014801"] = false;
		visited ["42_361338, -71_088244  "]	= false
		visited ["42_361522 -71_088255"] = false; 
		visited ["42_361606 -71_088166"] = false; 
		visited ["42_361913 -71_088145"] = false; 

		visited ["42_362120, -71_088144 "] = false; 

		visited ["42_362462 -71_087767"] = false; 

		visited ["42_36249432125361 -71_0858291387558"] = false;
		visited ["42_36249808371944 -71_08513176441193"] = false;
		visited ["42_362379 -71_088210"] = false; 
		visited ["42_362626905458896 -71_08663111925125"] = false; 
		visited ["42_36266545128742 -71_0870911180973"] = false; 
		visited ["42_36267139689614 -71_08754508197308"] = false; 
		visited ["42_36270439965933 -71_08797490596771"] = false; 
		visited ["42_36283995621765 -71_0861349105835"] = false; 
		visited ["42_361927, -71_088143"] = false; 
/*

		visited ["42_360851727921535 -71_08802855014801"] = false; 
		visited ["42_36118072692198 -71_08821630477905"]	= false; 
		visited ["42_36148990513537 -71_0882431268692"] = false; 
		visited ["42_36157155035019 -71_08815461397171"] = false; 
		visited ["42_36158900039465 -71_08806073665619"] = false; 
		visited ["42_361699986899495 -71_08853280544281"] = false; 
		visited ["42_36176300509831 -71_08808755874634"] = false; 
		visited ["42_36249432125361 -71_0858291387558"] = false; 
		visited ["42_36249808371944 -71_08513176441193"] = false; 
		visited ["42_362507002156065 -71_08812913298607"] = false; 
		visited ["42_362626905458896 -71_08663111925125"] = false; 
		visited ["42_36266545128742 -71_0870911180973"] = false; 
		visited ["42_36267139689614 -71_08754508197308"] = false; 
		visited ["42_36270439965933 -71_08797490596771"] = false; 
		visited ["42_36283995621765 -71_0861349105835"] = false; 
 */ 
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (Time.time.ToString() + "," +  nextActionTime.ToString()); 
		if (Time.time >= nextActionTime) {
			nextActionTime += period;	
			Debug.Log ("hi");


			// First, check if user has location service enabled
			if (!Input.location.isEnabledByUser) {
				Debug.Log ("exiting"); 
			}
				
			Debug.Log("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
			Debug.Log (data); 
			foreach (KeyValuePair<string, AudioClip> marker in data) {

				string[] latlong = marker.Key.Split(' '); 
				float lat = float.Parse (latlong [0].Replace ('_', '.')); 
				float lng = float.Parse(latlong[1].Replace('_', '.'));	
				float dist = Calc (lat, lng, Input.location.lastData.latitude, Input.location.lastData.longitude); 
				//Debug.Log (lat.ToString (), lng.ToString ()); 
				Debug.Log (dist.ToString ()); 
//				string s = (lat + "  "+ lng + "  " + Input.location.lastData.latitude + "  " + Input.location.lastData.longitude); 

				if (dist <= RADIUS) {
					if (! visited [marker.Key]) {
						AudioClip audioclip = marker.Value; 
						//play audio 
						speaker.clip = audioclip; 
						speaker.Play(); 	
						visited [marker.Key] = true; 
					}
					visited [marker.Key] = false; 

				}

			}

		}

	}


     public float Calc(float lat1, float lon1, float lat2, float lon2)
     {
           
         float R = 6378.137f; // Radius of earth in KM
         float dLat = lat2 * Mathf.PI / 180 - lat1 * Mathf.PI / 180;
         float dLon = lon2 * Mathf.PI / 180 - lon1 * Mathf.PI / 180;
         float a = Mathf.Sin(dLat / 2) * Mathf.Sin(dLat / 2) +
         Mathf.Cos(lat1 * Mathf.PI / 180) * Mathf.Cos(lat2 * Mathf.PI / 180) *
         Mathf.Sin(dLon / 2) * Mathf.Sin(dLon / 2);
         float c = 2 * Mathf.Atan2(Mathf.Sqrt(a), Mathf.Sqrt(1 - a));
         float  d = R * c;
         return d * 1000f; // meters
     }

//	IEnumerator Start()
//	{
//
//		if (first) {
//			loadData (); 
//			first = false; 
//		}
//		// First, check if user has location service enabled
//		if (!Input.location.isEnabledByUser)
//			Debug.Log ("heyy!"); 
//			yield break;
//
//		// Start service before querying location
//		Input.location.Start();
//
//		// Wait until service initializes
//		int maxWait = 20;
//		while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
//		{
//			yield return new WaitForSeconds(1);
//			maxWait--;
//		}
//
//		// Service didn't initialize in 20 seconds
//		if (maxWait < 1)
//		{
//			Debug.Log("Timed out");
//			yield break;
//		}
//
//		// Connection has failed
//		if (Input.location.status == LocationServiceStatus.Failed)
//		{
//			Debug.Log("Unable to determine device location");
//			yield break;
//		}
//		else
//		{
//			Debug.Log ("hi"); 
//			// Access granted and location value could be retrieved
//			Debug.Log("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
//
//			foreach (KeyValuePair<string, AudioClip> marker in data) {
//
//				string[] latlong = marker.Key.Split(' '); 
//				float lat = float.Parse (latlong [0].Replace ('_', '.')); 
//				float lng = float.Parse(latlong[1].Replace('_', '.'));	
//				float dist = Calc (lat, lng, Input.location.lastData.latitude, Input.location.lastData.longitude); 
//				//Debug.Log (lat.ToString (), lng.ToString ()); 
//				Debug.Log (dist.ToString ()); 
//
//				if (dist <= RADIUS) {
//					AudioClip audioclip = marker.Value; 
//					//play audio 
//					speaker.clip = audioclip; 
//					speaker.Play(); 
//				}
//					
//			}
//
//		}

//	}
		

}
