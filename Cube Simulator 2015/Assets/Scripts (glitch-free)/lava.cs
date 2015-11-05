using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class lava : MonoBehaviour {


	public Slider slider;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision col)
	{
		Destroy(col.gameObject);
		if (col.gameObject.name.Contains ("Player")) {
			slider.value=0;
		}
	}

}
