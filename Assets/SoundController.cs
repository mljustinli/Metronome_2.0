using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {

	public float currentBPM;

	public GameObject Indicator;
	public AudioClip Woodsound;

	private AudioSource audiosrc;

	private float currTime;
	private float deltaTime;

	// Use this for initialization
	void Start () {
		currentBPM = 200.0f;

		audiosrc = GetComponent<AudioSource> ();

		currTime = Time.time; //Time in seconds, but with floating point stuff
		deltaTime = (60.0f) / currentBPM; //Seconds in between each beat
	}
	
	// Update is called once per frame
	void Update () {

		if (Time.time - currTime >= deltaTime) {
			currTime = Time.time;
			//play a sound hopefully with no delay because it should be playing now...

			audiosrc.PlayOneShot (Woodsound);

			Indicator.transform.localScale = new Vector3 (7, 7);
		} else {
			Indicator.transform.localScale = Vector3.Lerp(Indicator.transform.localScale, new Vector3(2, 2), 0.5f * Time.deltaTime);
		}
	}
}
