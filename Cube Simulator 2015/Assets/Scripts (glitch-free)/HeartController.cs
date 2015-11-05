using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HeartController : MonoBehaviour {

	public WallController Ewall; 
	public WallController Wwall; 
	public WallController Swall; 
	public WallController NWwall; 
	public WallController NEwall; 
	
	public Transform myTransform; 
	public AudioSource levelUp;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		myTransform.Rotate (Vector3.up); 
	}

	void OnCollisionEnter(Collision col){
		if (!col.gameObject.name.Contains ("Terrorist")) {

			levelUp.Play();

			if (Ewall != null){
				Ewall.RestoreHp();
			}
			if (Wwall != null){
				Wwall.RestoreHp();
			}
			if (Swall != null){
				Swall.RestoreHp();
			}
			if (NWwall != null){
				NWwall.RestoreHp();
			}
			if (NEwall != null){
				NEwall.RestoreHp();
			}
			Destroy(this.gameObject); 
		}

	
	}

}
