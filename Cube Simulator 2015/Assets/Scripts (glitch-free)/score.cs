using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class score : MonoBehaviour {

	public static int walls;
	public static int scores; 
	public Slider slider;
	Text text;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
		scores = 0;
		walls = 5;
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "Score: " + scores;

		if (slider.value <= 0)
			text.color = new Color (0, 0, 0, 0);

	}
}
