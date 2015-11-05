using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {

	public int lifespan;
	int life;

	// Use this for initialization
	void Start () {
		life = lifespan;

	}
	
	// Update is called once per frame
	void Update () {
		life--;
		if (life <= 0) {
			Destroy(this.gameObject);

		}
	}
}
