using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiecePlayer : MonoBehaviour {

	struct Meter {
		public int top;
		public int bottom;
	}

	struct Measure {
		public int BPM;
		public Meter meter;
	}

//	private int BPM = 200;
	private Meter[] lists = new Meter[] {new Meter(3, 4), new Meter(4, 4)};

	private Meter m;

	// Use this for initialization
	void Start () {
		m = new Meter (3, 4);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
