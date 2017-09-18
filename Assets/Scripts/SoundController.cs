////using System.Collections;
////using System.Collections.Generic;
////using UnityEngine;
////
////public class SoundController : MonoBehaviour {
////
////	private float currentBPM;
////
////	public GameObject Indicator;
////	public AudioClip Woodsound;
////
////	private AudioSource audiosrc;
////
////	private float currTime;
////	private float deltaTime;
////
////	// Use this for initialization
////	void Start () {
////		currentBPM = 100.0f;
////
////		audiosrc = GetComponent<AudioSource> ();
////
////		currTime = Time.time; //Time in seconds, but with floating point stuff
////		deltaTime = (60.0f) / currentBPM; //Seconds in between each beat
////	}
////	
////	// Update is called once per frame
////	void Update () {
////
////		if (Time.time - currTime >= deltaTime) {
////			currTime = Time.time;
////			//play a sound hopefully with no delay because it should be playing now...
////
////			audiosrc.PlayOneShot (Woodsound);
////
////			Indicator.transform.localScale = new Vector3 (7, 7);
////		} else {
////			Indicator.transform.localScale = Vector3.Lerp(Indicator.transform.localScale, new Vector3(2, 2), 0.5f * Time.deltaTime);
////		}
////	}
////}
//
//
//using UnityEngine;
//using System.Collections;
//
//[RequireComponent(typeof(AudioSource))]
//public class SoundController : MonoBehaviour {
//	private float bpm = 280.0F;
//	private int numBeatsPerSegment = 4;
//	public AudioClip[] clips = new AudioClip[2];
//	private double nextEventTime;
//	private int flip = 0;
//	private AudioSource[] audioSources = new AudioSource[2];
//	private bool running = false;
//	void Start() {
//		int i = 0;
//		while (i < 2) {
//			GameObject child = new GameObject("Player");
//			child.transform.parent = gameObject.transform;
//			audioSources[i] = child.AddComponent<AudioSource>();
//			i++;
//		}
//		nextEventTime = AudioSettings.dspTime + 2.0F;
//		running = true;
//	}
//	void Update() {
//		if (!running)
//			return;
//
//		double time = AudioSettings.dspTime;
//		if (time + 1.0F > nextEventTime) {
//			audioSources[flip].clip = clips[flip];
//			audioSources [flip].Stop();
//			audioSources [flip].PlayScheduled (nextEventTime);
//			Debug.Log("Scheduled source " + flip + " to start at time " + nextEventTime);
//			nextEventTime += 60.0F / bpm * numBeatsPerSegment;
//			flip = 1 - flip;
//		}
//	}
//}