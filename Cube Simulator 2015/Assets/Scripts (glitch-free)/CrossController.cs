using UnityEngine;
using System.Collections;

public class CrossController : MonoBehaviour {
	public Transform myTransform; 
	public AudioSource levelUp;


	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		myTransform.Rotate (Vector3.up); 
	}

	void OnCollisionEnter(Collision col){

		if (!col.gameObject.name.Contains ("Terrorist")) {
			levelUp.Play ();
			GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject> ();

			foreach (GameObject x in allObjects) {
				if (x.name.Contains ("Terrorist") && x.transform.position.y > 0) {
					Destroy (x); 
				}
		
			}
			Destroy (this.gameObject); 

		}
	}

}
