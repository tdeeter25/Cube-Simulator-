using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour {

	public Slider slider;       // Reference to the player's health.
	public Image imag;
	public GameObject cube;
	Text gameover;
	public float timer=6;


	void Start ()
	{
		// Set up the reference.
		gameover = GetComponent<Text> ();
	}
	
	
	void Update ()
	{
		// If the player has run out of health...
		if(slider.value <= 0)
		{

			imag.color= new Color(.7f,0,0,.5f);
			Destroy (cube.gameObject);
			gameover.color= new Color(0,0,0,1);
			gameover.text =  "GAME OVER\tYOUR SCORE: " + score.scores;
			timer-=Time.deltaTime;
			if(timer<=0)
				Application.LoadLevel (0);
		}

	}
}

