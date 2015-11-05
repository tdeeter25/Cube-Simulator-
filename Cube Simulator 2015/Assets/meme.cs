using UnityEngine;
using System.Collections;

public class meme : MonoBehaviour {

	public float lifetime;
	float timeLeft;

	// Use this for initialization
	void Start () {
		lifetime = 120;

		timeLeft = lifetime;
	}
	
	// Update is called once per frame
	void Update () {
		timeLeft--;
		if (timeLeft <= 0 && this.transform.position.y >= -10) {
			Destroy(this.gameObject);
		}

	}
}
