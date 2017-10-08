//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//
//public class LocationService : MonoBehaviour
//{
//
//    public float markerRadius = 10; 
//	public List<DataClass> markersInRadius; 
//	public DataClass[] data; 
//
//
//     public float Calc(float lat1, float lon1, float lat2, float lon2)
//     {
//           
//         float R = 6378.137f; // Radius of earth in KM
//         float dLat = lat2 * Mathf.PI / 180 - lat1 * Mathf.PI / 180;
//         float dLon = lon2 * Mathf.PI / 180 - lon1 * Mathf.PI / 180;
//         float a = Mathf.Sin(dLat / 2) * Mathf.Sin(dLat / 2) +
//         Mathf.Cos(lat1 * Mathf.PI / 180) * Mathf.Cos(lat2 * Mathf.PI / 180) *
//         Mathf.Sin(dLon / 2) * Mathf.Sin(dLon / 2);
//         float c = 2 * Mathf.Atan2(Mathf.Sqrt(a), Mathf.Sqrt(1 - a));
//         float  d = R * c;
//         return d * 1000f; // meters
//     }
//
//	public List<DataClass> getMarkersInRadius(float myLat, float myLng) {
//		List<DataClass> markersInRadius = new List<DataClass> (); 
//        foreach (DataClass marker in data) {
//			float distToMarker = Calc (myLat, myLng, marker.lat, marker.lng); 
//			if (distToMarker >= markerRadius) {
//				markersInRadius.Add (marker);
//			}
//        }
//		return markersInRadius; 
//     }
//     
//
//
//    IEnumerator Start()
//    {
//        // First, check if user has location service enabled
//        if (!Input.location.isEnabledByUser)
//            yield break;
//
//        // Start service before querying location
//        Input.location.Start();
//
//        // Wait until service initializes
//        int maxWait = 20;
//        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
//        {
//            yield return new WaitForSeconds(1);
//            maxWait--;
//        }
//
//        // Service didn't initialize in 20 seconds
//        if (maxWait < 1)
//        {
//            print("Timed out");
//            yield break;
//        }
//
//        // Connection has failed
//        if (Input.location.status == LocationServiceStatus.Failed)
//        {
//            print("Unable to determine device location");
//            yield break;
//        }
//        else
//        {
//            // Access granted and location value could be retrieved
//            print("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
//			//List<DataClass> markers = getMarkersInRadius (); 
////			foreach (DataClass marker in  markers) {
////				play audio 
////
////
////				WWW www = new WWW(marker.fileName);
////				yield return www;
////				AudioSource audio = GetComponent<AudioSource>();
////				audio.clip = www.GetAudioClip(false, true,AudioType.MPEG);
////				audio.Play();
////
////			}
//
//        }
//
//        // Stop service if there is no need to query location updates continuously
//        Input.location.Stop();
//    }
//}
