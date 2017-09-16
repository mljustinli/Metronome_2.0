using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomSlider : MonoBehaviour {

	private GameObject background;
	private float localY;
	private float bgWidth;
	private float bgXLeft;
	private float bgXRight;

	private GameObject knob1;
	private GameObject knob2;

	private bool heldOnKnob1;
	private bool heldOnKnob2;

	// Use this for initialization
	void Start () {
		background = transform.GetChild (0).gameObject;
		bgWidth = background.GetComponent<Image> ().rectTransform.rect.width;
		bgXLeft = background.transform.position.x - bgWidth / 2;
		bgXRight = background.transform.position.x + bgWidth / 2;

		Debug.Log (bgWidth);
		Debug.Log (bgXLeft + " " + bgXRight);

		knob1 = transform.GetChild (0).GetChild (0).gameObject;
		knob2 = transform.GetChild (0).GetChild (1).gameObject;

		heldOnKnob1 = false;
		heldOnKnob2 = false;
	}
	
	// Update is called once per frame
	void Update () {

//		Debug.Log (knob1.transform.GetComponent<Image>().rectTransform.rect);

//		Mathf.Clamp(Input.mousePosition.x, bgXLeft, bgXRight)


		if (heldOnKnob1 || (Input.GetMouseButton (0) && RectTransformUtility.RectangleContainsScreenPoint (knob1.transform.GetComponent<Image> ().rectTransform, (Vector2)Input.mousePosition))) {
			if (!heldOnKnob2) {
				Debug.Log ("click is in bounds");
				heldOnKnob1 = true;
				knob1.transform.position = new Vector3(Mathf.Clamp(Input.mousePosition.x, bgXLeft, bgXRight), 0, 0);
				knob1.transform.localPosition = new Vector3 (Mathf.Clamp(knob1.transform.localPosition.x, -bgWidth/2, knob2.transform.localPosition.x - 20), 0, 0);
			}
		}

		if (heldOnKnob2 || (Input.GetMouseButton (0) && RectTransformUtility.RectangleContainsScreenPoint (knob2.transform.GetComponent<Image> ().rectTransform, (Vector2)Input.mousePosition))) {
			if (!heldOnKnob1) {
				Debug.Log ("click is in bounds");
				heldOnKnob2 = true;
				knob2.transform.position = new Vector3(Mathf.Clamp(Input.mousePosition.x, bgXLeft, bgXRight), 0, 0);
				knob2.transform.localPosition = new Vector3 (Mathf.Clamp(knob2.transform.localPosition.x, knob1.transform.localPosition.x + 20, bgWidth/2), 0, 0);
			}
		}

		if (Input.GetMouseButtonUp (0)) {
			heldOnKnob1 = false;
			heldOnKnob2 = false;
		}


	}
}
