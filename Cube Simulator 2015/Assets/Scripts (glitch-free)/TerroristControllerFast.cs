using UnityEngine;
using System.Collections;

public class TerroristControllerFast : MonoBehaviour {

	public float timer;
	public float speed;
	GameObject target;
	bool east;
	bool memehere;
	public Transform w;
	public Transform e;
	public Transform s;
	public Transform nw;
	public Transform ne;

	public GameObject powerUp1;
	public GameObject powerUp2;
	public GameObject powerUp3;
	public GameObject meme1;

	public GameObject[] memes; 

	Transform objectOfAttraction;
	Vector3 targetPosition;
	public AudioSource coin;
	public Rigidbody myRigidbody; 
	public Transform myTransform; 

	public float hpIn;
	float hp;

	// Use this for initialization
	void Start () {
		hp = hpIn;

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
				objectOfAttraction = nw;
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
				objectOfAttraction = e;
			}
			else if (e != null){
				objectOfAttraction = e;
			}
			else if (ne != null){
				objectOfAttraction = e;
			}
			else {
				Destroy (gameObject);
			}
		}
		targetPosition = objectOfAttraction.position;
	}
	
	// Update is called once per frame
	void Update () {
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
		if (col.gameObject.name.Contains("Bullet")) {
			if (col.gameObject.name.Contains("Laser")){
				hp -= (hpIn - 1);
			}
			hp--;
			score.scores+=5;
		}

	}

	void wait()
	{
		float time = 0;
		while (time<timer) {
			time += Time.deltaTime;
		}
	}


	void Roll(){
		int roll = Random.Range (0,memes.Length + 5);
		if (roll > memes.Length+2) {
			GameObject pow = (GameObject)Instantiate (powerUp3, transform.position, new Quaternion (0, 0, 0, 0));
		} else if (roll > memes.Length+1) {
			GameObject pow = (GameObject)Instantiate (powerUp2, transform.position, new Quaternion (0, 0, 0, 0));
		} else if (roll > memes.Length) {
			GameObject pow = (GameObject)Instantiate (powerUp1, transform.position, new Quaternion (0, 0, 0, 0));
		} else {
			GameObject pow = (GameObject)Instantiate (memes[roll], transform.position, new Quaternion (0, -270, 270, 0));


		}
		
	}	


}
