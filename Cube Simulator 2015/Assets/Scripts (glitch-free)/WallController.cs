using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WallController: MonoBehaviour {

	public int hpin;
	int hp;
	public Slider slider;
	bool damaged= false;
	public Image damageImage;
	public float flashSpeed = 5f;                               
	public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
	public AudioSource hit;


	// Use this for initialization
	void Start () {
		hp = hpin;
	}
	
	// Update is called once per frame
	void Update () {
		if (hp <= 0) {
			Destroy (gameObject);
			score.walls--;
		}
		RenderSettings.haloStrength = hpin - hp;

		if(damaged)
		{
			// ... set the colour of the damageImage to the flash colour.
			damageImage.color = flashColour;
			hit.Play ();
		}
		// Otherwise...
		else
		{
			// ... transition the colour back to clear.
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed *Time.deltaTime);
		}
		
		// Reset the damaged flag.
		damaged = false;
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.name.Contains("Terrorist")) {
			hp--;
			slider.value--;
			Destroy (col.gameObject);
			damaged=true;
		}
	}

	public void RestoreHp(){
		hp = hpin;
		slider.value = score.walls * 3;

	}
}
