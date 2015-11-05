using UnityEngine;
using System.Collections;

public class StarController : MonoBehaviour {

	public Transform myTransform; 
	public AudioSource rick;
	public AudioSource game;
	public AudioSource levelUp;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		myTransform.Rotate (Vector3.up); 

	}
	
	void OnCollisionEnter(Collision col){
		
		if (!col.gameObject.name.Contains ("Terrorist")) {
			

				
			PlayerControllerDirect.godMode = true;
			PlayerControllerDirect.starTimer = 2000;
			game.Pause ();
			rick.Play ();
			levelUp.Play ();

			Destroy (this.gameObject); 
		}
			
	}
	
}
