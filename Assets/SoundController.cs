﻿//using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {

	private float currentBPM;

	public GameObject Indicator;
	public AudioClip Woodsound;

	private AudioSource audiosrc;

	private float currTime;
	private float deltaTime;

	// Use this for initialization
	void Start () {
		currentBPM = 100.0f;

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


//using UnityEngine;
//using System.Collections;
//
//// The code example shows how to implement a metronome that procedurally generates the click sounds via the OnAudioFilterRead callback.
//// While the game is paused or the suspended, this time will not be updated and sounds playing will be paused. Therefore developers of music scheduling routines do not have to do any rescheduling after the app is unpaused
//
//[RequireComponent(typeof(AudioSource))]
//public class SoundController : MonoBehaviour
//{
//	private double bpm = 200.0F;
//	public float gain = 0.5F;
//	public int signatureHi = 4;
//	public int signatureLo = 4;
//	private double nextTick = 0.0F;
//	private float amp = 0.0F;
//	private float phase = 0.0F;
//	private double sampleRate = 0.0F;
//	private int accent;
//	private bool running = false;
//	void Start()
//	{
//		accent = signatureHi;
//		double startTick = AudioSettings.dspTime;
//		sampleRate = AudioSettings.outputSampleRate;
//		nextTick = startTick * sampleRate;
//		running = true;
//	}
//
//	void OnAudioFilterRead(float[] data, int channels)
//	{
//		if (!running)
//			return;
//
//		double samplesPerTick = sampleRate * 60.0F / bpm * 4.0F / signatureLo;
//		double sample = AudioSettings.dspTime * sampleRate;
//		int dataLen = data.Length / channels;
//		int n = 0;
//		while (n < dataLen)
//		{
//			float x = gain * amp * Mathf.Sin(phase);
//			int i = 0;
//			while (i < channels)
//			{
//				data[n * channels + i] += x;
//				i++;
//			}
//			while (sample + n >= nextTick)
//			{
//				nextTick += samplesPerTick;
//				amp = 1.0F;
//				if (++accent > signatureHi)
//				{
//					accent = 1;
//					amp *= 2.0F;
//				}
//				Debug.Log("Tick: " + accent + "/" + signatureHi);
//			}
//			phase += amp * 0.3F;
//			amp *= 0.993F;
//			n++;
//		}
//	}
//}