using UnityEngine;
using System.Collections;

public class ScopeScript : MonoBehaviour {

	bool Aim = false; 
	public GameObject target;
	public GameObject ScopeCam; 
	public GameObject MainCam; 
	
	// Update is called once per frame

	void Start(){
		ScopeCam.SetActive (false); 
	
	}
	void LateUpdate () {
		transform.position = target.transform.position;
		transform.LookAt(target.transform);
	}

	void Update(){
		if (Input.GetKeyDown("space")) {
			ScopeCam.SetActive(true);  
			MainCam.SetActive(false);  
		}
	

	}
}
