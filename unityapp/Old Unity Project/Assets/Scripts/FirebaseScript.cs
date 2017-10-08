//using System.Collections;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using UnityEngine;
//
//using Firebase;
//using Firebase.Database;
//using Firebase.Unity.Editor;
//
//using Firebase.Storage;
//
//
//
//[System.Serializable]
//public class DataClass {
//	public float lat;
//	public float lng;
//	public string fileName;
//	public bool isPlaying; 
//
//	// Constructor
//	public DataClass(float lat, float lng, string fileName)
//	{
//		this.lat = lat;
//		this.lng = lng;
//		this.fileName = fileName;
//		this.isPlaying = false; 
//	}
//}
//
//public class FirebaseScript : MonoBehaviour {
//
//	public ArrayList storedList = new ArrayList(); // or an ArrayList will be much better
//	public DataClass data;
//
//	// TODO get current position co-ordinates
//
//
//	// Use this for initialization
//	void Start () {
//		Debug.Log ("I am alive");
//
//		signInAnonymous ();
//
//		fetchAllEntries ();
//
//
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		// check the euclidean Euclidean distance
//		// increase decrease the sound of the on-going clip
//		// change the clip if the minimum distance requirement is fulfilled with another existing marker data
//
//	}
//
//	void signInAnonymous() {
//
//		Debug.Log ("In signInAnonymous function");
//
//		// Initialize firebase auth
//		Firebase.Auth.FirebaseAuth auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
//
//		auth.SignInAnonymouslyAsync ().ContinueWith (task => {
//			if (task.IsCanceled) {
//				Debug.LogError("SignInAnonymouslyAsync was cancelled.");
//			}
//			if (task.IsFaulted) {
//				Debug.LogError("SignInAnonymouslyAsync encountered an error: " + task.Exception);
//			}
//
//			Firebase.Auth.FirebaseUser newUser = task.Result;
//			Debug.LogFormat("User signed in successfully: {0} ({1})", newUser.DisplayName, newUser.UserId);
//		});
//
//	}
//
//	void fetchAllEntries() {
//
//		Debug.Log ("In fetchAllEntries function");
//
//		// Set up the Editor before calling into the realtime database.
//		FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://getting-around-4803a.firebaseio.com/");
//
//		// Get the root reference location of the database.
//		DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
//
//		reference.ChildChanged += HandleChildAdded;
//		// fetch all enteries from Realtime database
//		// latitude and longitude
//
//	}
//
//	void HandleChildAdded(object sender, ChildChangedEventArgs args) {
//		if (args.DatabaseError != null) {
//			Debug.LogError(args.DatabaseError.Message);
//			return;
//		}
//			
//		float lat, lng; 
//		string file = System.String.Empty;
//		string[] tempList;
//
//		// Do something with the data in args.Snapshot
//		if (args.Snapshot != null && args.Snapshot.ChildrenCount > 0) {
//			foreach (var childSnapshot in args.Snapshot.Children) {
//				if (childSnapshot.Child("audio") == null
//					|| childSnapshot.Child("audio").Value == null) {
//					Debug.LogError("Bad data in sample.");
//					break;
//				} else {
//					Debug.Log("entry : " +
//						childSnapshot.Value.ToString() + " - " +
//						childSnapshot.Child("audio").Value.ToString());
//					
//					// generate a data list
//
//					tempList = childSnapshot.Value.ToString ().Split (' ');
//					lat = float.Parse (tempList [0].Replace ('_', '.')); 
//					lng = float.Parse(tempList[1].Replace('_', '.'));	
//					file = childSnapshot.Child("audio").Value.ToString();
//
//					data = new DataClass (lat, lng, file);
//					storedList.Add (data);
//
//					//leaderBoard.Insert(1, childSnapshot.Child("audio").Value.ToString()
//					// 	+ "  " + childSnapshot.Child("email").Value.ToString());
//				}
//			}
//		}
//
//	}
//
//	void calcNearestMarker() {
//
//		Debug.Log ("In calcNearestMarker function");
//
//		// calculate the Euclidean distance between the current position and all the fetched marker positions
//
//	}
//
//	void getAudio(string lat, string lng) {
//
//		Debug.Log ("In getAudio function");
//
//		// Get a reference to the storage service, using the default Firebase App
//		FirebaseStorage storage = FirebaseStorage.DefaultInstance;
//
//		// fetch the audio file with the lowest euclidean distance {{ some calculated distance value..... }}
//
//		// (latitude + + longitude + /) vals -> replace . with _
//		string path = lat.Replace(".", "_") + " " + lng.Replace(".", "_") + "/"; 
//		Debug.Log ("path = " + path);
//
//		string fileName = ""; // TODO
//		foreach (DataClass marker in storedList) {
//			if (marker.lat == float.Parse(lat) && marker.lng == float.Parse(lng)) {
//				fileName = marker.fileName; 
//			}
//		}
//
//		// Create a reference with an initial file path and name
//		Firebase.Storage.StorageReference path_reference = storage.GetReference(path + fileName);
//
//		// Fetch the download URL
//		path_reference.GetDownloadUrlAsync().ContinueWith((Task task) => {
//			if (!task.IsFaulted && !task.IsCanceled) {
//				Debug.Log(task.ToString()); 
//
//				//Debug.Log("Download URL: " + task.Result());
//				// ... now download the file via WWW or UnityWebRequest.
//			}
//		});
//
//	}
//}
