using UnityEngine;
using System.Collections;

public class Grenade : MonoBehaviour {
	// Use this for initialization

	public float explosionForce;
	public int numComponents;

	public float verticalLaunch;
	public float horizontalLaunch;


	void Start () {
		Vector3 launch = new Vector3 (Mathf.Sin (transform.rotation.eulerAngles.y * Mathf.Deg2Rad) *  horizontalLaunch, verticalLaunch, Mathf.Cos (transform.rotation.eulerAngles.y * Mathf.Deg2Rad) *  horizontalLaunch);
		GetComponent<Rigidbody> ().AddForce (launch);
	
	}

	
	// Update is called once per frame
	void Update () {
		if (GetComponent<Rigidbody> ().velocity == new Vector3 (0, 0, 0)) {
			Destroy (this.gameObject);
		}
	}

	void OnCollisionEnter(Collision col) {
		Destroy (this.gameObject);
	}

	void Die(){
		Destroy (this.gameObject);
	}
}
