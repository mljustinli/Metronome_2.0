using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

//exhibits singletonish behavior
public class DataController : MonoBehaviour {

	public static DataController control;

	/*
	 * ----------------------------------------------------------------
	 */
	//data variables
	public int totalMeasures;

	string saveTo = "/metronome.dat";

	void Awake() {
		if (control == null) {
			DontDestroyOnLoad (gameObject);
			control = this;
		} else if (control != this) {
			Destroy (gameObject);
		}

		Reset ();
		Load ();
	}

	void OnApplicationQuit() {
		Save ();
	}

	void OnApplicationPause() {
		Save();
	}

	void OnApplicationFocus(bool focusStatus) {
		if (focusStatus == false) {
			Debug.Log ("heyya");
			Save ();
		}
	}

	// temporary
	void Update () {
		if (Input.GetKeyDown(KeyCode.U)) {
			Save ();
			Debug.Log ("saved");
		}
		if (Input.GetKeyDown(KeyCode.J)) {
			Load ();
			Debug.Log ("Loaded");
		}
		if (Input.GetKeyDown(KeyCode.H)) {
			Debug.Log (Application.persistentDataPath);
		}
		if (Input.GetKeyDown(KeyCode.R)) {
			Reset ();
			Debug.Log ("destroyed");
			if (File.Exists(Application.persistentDataPath + saveTo)) {
				File.Delete (Application.persistentDataPath + saveTo);
			}
		}
	}

	public void Reset() {
		/*
		 * ----------------------------------------------------------------
		 */
		totalMeasures = 200;
	}

	public void Save() {
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + saveTo);

		PlayerData data = new PlayerData ();

		/*
		 * ----------------------------------------------------------------
		 */
		data.totalMeasures = totalMeasures;

		bf.Serialize (file, data);
		file.Close ();
	}

	public void Load() {
		if (File.Exists(Application.persistentDataPath + saveTo)) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + saveTo, FileMode.Open);
			PlayerData data = (PlayerData)bf.Deserialize (file);
			file.Close ();

			/*
			 * ----------------------------------------------------------------
			 */
			totalMeasures = data.totalMeasures;
		} else {
			Debug.Log ("file doesn't exist");
		}
	}
}

[Serializable]
class PlayerData {
	/*
	 * ----------------------------------------------------------------
	 */
	public int totalMeasures;
}