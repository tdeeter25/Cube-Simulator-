using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

	public Rigidbody terrorist;

	public float initial;
	float rate;

	public float dt;
	float t = 1;

	// Use this for initialization
	void Start () {
		rate = initial;
	}
	
	// Update is called once per frame
	void Update () {
		t += dt;

		float dx = Random.Range (-20, 20);

		if (t > rate) {
			Rigidbody Terrorist = (Rigidbody)Instantiate (terrorist, transform.position + new Vector3(dx,0,-5), transform.rotation);
			Terrorist.name = "Terrorist";
			t-= rate;
			rate = rate * .999f;
		}
	}
}
