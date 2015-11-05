using UnityEngine;
using System.Collections;

public class TerroristControllerJump : MonoBehaviour {
	
	public float speed;
	public float jumpHeight;

	GameObject target;
	bool east;
	
	public Transform w;
	public Transform e;
	public Transform s;
	public Transform nw;
	public Transform ne;

	public GameObject powerUp1;
	public GameObject powerUp2;
	public GameObject powerUp3;

	Transform objectOfAttraction; 
	public Rigidbody myRigidbody; 
	public Transform myTransform; 

	public AudioSource coin;

	public float hpIn;
	float hp;
	
	// Use this for initialization
	void Start () {
		hp = hpIn;

		jumpHeight = Random.Range (jumpHeight / 2, jumpHeight * 2);

		if (transform.position.x >= 0) {
			if (ne != null){
				objectOfAttraction = ne;
			}
			else if (e != null){
				objectOfAttraction = e;
			}
			else if (s != null){
				objectOfAttraction = s;
			}
			if (w != null){
				objectOfAttraction = w;
			}
			else if (nw != null){
				objectOfAttraction = nw;
			}
			else{
				Destroy(gameObject);
			}
		} else {
			if (nw != null){
				objectOfAttraction = nw;
			}
			else if (w != null){
				objectOfAttraction = w;
			}
			else if (s != null){
				objectOfAttraction = s;
			}
			else if (e != null){
				objectOfAttraction = e;
			}
			else if (ne != null){
				objectOfAttraction = ne;
			}
			else {
				Destroy (gameObject);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (objectOfAttraction == null) {
			
			if (transform.position.x >= 0) {
				if (ne != null){
					objectOfAttraction = ne;
				}
				else if (e != null){
					objectOfAttraction = e;
				}
				else if (s != null){
					objectOfAttraction = s;
				}
				if (w != null){
					objectOfAttraction = w;
				}
				else if (nw != null){
					objectOfAttraction = nw;
				}
				else{
					Destroy(gameObject);
				}
			} else {
				if (nw != null){
					objectOfAttraction = nw;
				}
				else if (w != null){
					objectOfAttraction = w;
				}
				else if (s != null){
					objectOfAttraction = s;
				}
				else if (e != null){
					objectOfAttraction = e;
				}
				else if (ne != null){
					objectOfAttraction = ne;
				}
				else {
					Destroy (gameObject);
				}
			}
			
		}
		
		Vector3 targetPosition = objectOfAttraction.position; 
		Vector3 myPosition = myTransform.position;
		Vector3 direction = (targetPosition - myPosition).normalized; 
		myRigidbody.AddForce (direction * speed * Time.deltaTime); 
		
		if (hp <= 0) {
			coin.Play ();
			Roll();
			score.scores+=5;
			Destroy(this.gameObject);
		}
	}
	
	
	void OnCollisionEnter(Collision col) {
		if (col.gameObject.name.Contains ("Ground")) {
			GetComponent<Rigidbody>().AddForce(Vector3.up * jumpHeight);
		}

		if (col.gameObject.name.Contains("Bullet")) {
			if (col.gameObject.name.Contains("Laser")){
				hp -= (hpIn - 1);
			}
			score.scores+=5;
			hp--;
		}
	}

	void Roll(){
		int roll = Random.Range (0,61);
		if (roll > 59) {
			GameObject pow = (GameObject)Instantiate (powerUp3, transform.position, new Quaternion (0,0,0,0));
		}
		else if (roll > 58) {
			GameObject pow = (GameObject)Instantiate (powerUp2, transform.position, new Quaternion(0,0,0,0));
		} 
		else if (roll > 57) {
			GameObject pow = (GameObject)Instantiate (powerUp1, transform.position, new Quaternion(0,0,0,0));
		}
	}
	
}
