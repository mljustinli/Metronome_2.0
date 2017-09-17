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

	public int knob1Value;
	public int knob2Value;

	private GameObject upLeft;
	private GameObject downLeft;
	private GameObject upRight;
	private GameObject downRight;

	private GameObject[] adjustButtons;

	private int totalMeasures = 200;


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

		knob1Value = 2;
		knob2Value = 80;
		moveLeftKnob (knob1Value);
		moveRightKnob (knob2Value);


		upLeft = transform.GetChild (1).gameObject;
		downLeft = transform.GetChild (2).gameObject;
		upRight = transform.GetChild (3).gameObject;
		downRight = transform.GetChild (4).gameObject;

		adjustButtons = new GameObject[] { upLeft, downLeft, upRight, downRight };
	}
	
	// Update is called once per frame
	void Update () {

//		Debug.Log (knob1.transform.GetComponent<Image>().rectTransform.rect);

//		Mathf.Clamp(Input.mousePosition.x, bgXLeft, bgXRight)


		if (heldOnKnob1 || (Input.GetMouseButton (0) && RectTransformUtility.RectangleContainsScreenPoint (knob1.transform.GetComponent<Image> ().rectTransform, (Vector2)Input.mousePosition))) {
			if (!heldOnKnob2) {
//				Debug.Log ("click is in bounds");
//				heldOnKnob1 = true;
////				knob1.transform.position = new Vector3(Mathf.Clamp(Input.mousePosition.x, bgXLeft, bgXRight), 0, 0);
////				knob1.transform.localPosition = new Vector3 (Mathf.Clamp(knob1.transform.localPosition.x, -bgWidth/2, knob2.transform.localPosition.x - 20), 0, 0);
//				moveLeftKnob(Input.mousePosition.x);

				heldOnKnob1 = true;
				Vector3 pos = knob1.transform.position;
				knob1.transform.position = new Vector3 (Input.mousePosition.x, pos.y, 0);
				int value = Mathf.RoundToInt (((knob1.transform.localPosition.x + bgWidth / 2) / bgWidth) * totalMeasures);
//				knob1Value = value;
//				knob1Value = Mathf.Clamp (knob1Value, 1, knob2Value);
				moveLeftKnob(value);
			}
		}

		if (heldOnKnob2 || (Input.GetMouseButton (0) && RectTransformUtility.RectangleContainsScreenPoint (knob2.transform.GetComponent<Image> ().rectTransform, (Vector2)Input.mousePosition))) {
			if (!heldOnKnob1) {
//				Debug.Log ("click is in bounds");
//				heldOnKnob2 = true;
////				knob2.transform.position = new Vector3(Mathf.Clamp(Input.mousePosition.x, bgXLeft, bgXRight), 0, 0);
////				knob2.transform.localPosition = new Vector3 (Mathf.Clamp(knob2.transform.localPosition.x, knob1.transform.localPosition.x + 20, bgWidth/2), 0, 0);
//				moveRightKnob(Input.mousePosition.x);

				heldOnKnob2 = true;
				Vector3 pos = knob2.transform.position;
				knob2.transform.position = new Vector3 (Input.mousePosition.x, pos.y, 0);
				int value = Mathf.RoundToInt (((knob2.transform.localPosition.x + bgWidth / 2) / bgWidth) * totalMeasures);
//				knob2Value = value;
//				knob2Value = Mathf.Clamp (knob2Value, knob1Value + 1, totalMeasures);
				moveRightKnob(value);
			}
		}


//		knob1Value = Mathf.RoundToInt (((knob1.transform.localPosition.x + bgWidth / 2) / bgWidth) * totalMeasures);
//		knob2Value = Mathf.RoundToInt (((knob2.transform.localPosition.x + bgWidth / 2) / bgWidth) * totalMeasures);

//		float distance = bgWidth / totalMeasures;
//		Debug.Log (distance);

		for (int i = 0; i < adjustButtons.Length; i++) {
			if (Input.GetMouseButtonDown(0) && RectTransformUtility.RectangleContainsScreenPoint(adjustButtons[i].transform.GetComponent<Image>().rectTransform, (Vector2)Input.mousePosition)) {
				switch(i) {
				case 0:
//					knob1Value++;
					moveLeftKnob(++knob1Value);
					break;
				case 1:
//					knob1Value--;
					moveLeftKnob(--knob1Value);
					break;
				case 2:
//					knob2Value++;
					moveRightKnob(++knob2Value);
					break;
				case 3:
					//					knob2Value--;
					moveRightKnob(--knob2Value);
					break;
				}
			}
		}

////		if (heldOnKnob1) {
//			knob1Value = Mathf.Clamp (knob1Value, 1, knob2Value - 1);
//			Vector3 knob1Pos = knob1.transform.localPosition;
//			knob1.transform.localPosition = new Vector3 ((knob1Value / (totalMeasures + 0.0f)) * bgWidth - bgWidth / 2, knob1Pos.y, 0);
////		}
//
////		if (heldOnKnob2) {
//			knob2Value = Mathf.Clamp (knob2Value, knob1Value + 1, totalMeasures);
//			Vector3 knob2Pos = knob2.transform.localPosition;
//			knob2.transform.localPosition = new Vector3 ((knob2Value / (totalMeasures + 0.0f)) * bgWidth - bgWidth / 2, knob2Pos.y, 0);
////		}



		if (Input.GetMouseButtonUp (0)) {
			heldOnKnob1 = false;
			heldOnKnob2 = false;
		}
	}

	void moveLeftKnob (int newVal) {
		knob1Value = Mathf.Clamp (newVal, 1, knob2Value - 1);
		Vector3 knob1Pos = knob1.transform.localPosition;
		knob1.transform.localPosition = new Vector3 ((knob1Value / (totalMeasures + 0.0f)) * bgWidth - bgWidth / 2, knob1Pos.y, 0);
	}

	void moveRightKnob (int newVal) {
		knob2Value = Mathf.Clamp (newVal, knob1Value + 1, totalMeasures);
		Vector3 knob2Pos = knob2.transform.localPosition;
		knob2.transform.localPosition = new Vector3 ((knob2Value / (totalMeasures + 0.0f)) * bgWidth - bgWidth / 2, knob2Pos.y, 0);
	}
}
