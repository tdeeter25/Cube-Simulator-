using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MousePlayerController : MonoBehaviour {
	
	public float mouseSensitivity;
	public static bool godMode = false;
	public RawImage laserimage;
	public AudioSource game;
	public AudioSource rick;
	public AudioSource laserSound;
	
	
	public float speed;
	public float jumpHeight;
	public static float starTimer=0;
	
	public int jumpCool = 60;
	public static int framesCooldownJump;
	
	public int laserCool;
	public static int framesCooldownLaser;
	public Rigidbody laser;
	public Rigidbody grenade;
	
	public void Start(){
		framesCooldownJump = 0;
		framesCooldownLaser = 0;
	}
	
	public void launchGrenade(){
		Rigidbody grenadeClone = (Rigidbody)Instantiate (grenade, transform.position * 50, transform.rotation);
		
		
		grenadeClone.transform.rotation = new Quaternion (0, 0, 0, 0);
		grenadeClone.transform.Rotate(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
		grenadeClone.transform.position = transform.position + 2 * new Vector3 (Mathf.Sin (transform.rotation.eulerAngles.y * Mathf.Deg2Rad), 0, Mathf.Cos (transform.rotation.eulerAngles.y * Mathf.Deg2Rad));
		
	}
	
	public void fireLaser() {
		if (framesCooldownLaser <= 0) {
			laserSound.Play ();
			Rigidbody laserClone = (Rigidbody)Instantiate (laser, transform.position + 210 * new Vector3 (Mathf.Sin (transform.rotation.eulerAngles.y * Mathf.Deg2Rad), 0, Mathf.Cos (transform.rotation.eulerAngles.y * Mathf.Deg2Rad)), transform.rotation);
			
			laserClone.transform.rotation = new Quaternion (0, 0, 0, 0);
			laserClone.transform.Rotate (transform.rotation.eulerAngles.x + 90, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
			if(!godMode)
				framesCooldownLaser = laserCool;
		}
	}
	
	void OnCollisionEnter(Collision col)
	{
		if (godMode) {
			if(col.gameObject.name.Contains("Terrorist"))
			{
				Destroy(col.gameObject);
				score.scores+=10;
			}
		}
	}
	
	void jump() {
		if (framesCooldownJump <= 0) {
			Vector3 jump = new Vector3 (0, jumpHeight, 0);
			GetComponent<Rigidbody> ().AddForce (jump);
			
			framesCooldownJump = jumpCool;
		}
	}
	
	void Update() {
		starTimer--;
		float moveHorizontal = Input.GetAxis ("HorizontalTwo") * mouseSensitivity;
		float moveVertical = Input.GetAxis ("VerticalTwo") * mouseSensitivity;
		Vector3 moveX;
		Vector3 moveY = new Vector3 (0, 0, 0);
		
		moveY = moveVertical * new Vector3 ((Mathf.Sin (transform.rotation.eulerAngles.y * Mathf.Deg2Rad)), 0, (Mathf.Cos (transform.rotation.eulerAngles.y * Mathf.Deg2Rad)));
		moveX = moveHorizontal * Vector3.Cross (new Vector3 (0, 1, 0), new Vector3 ((Mathf.Sin (transform.rotation.eulerAngles.y * Mathf.Deg2Rad)), 0, (Mathf.Cos (transform.rotation.eulerAngles.y * Mathf.Deg2Rad))));
		transform.position = transform.position + (speed * moveY * Time.deltaTime) + (speed * moveX * Time.deltaTime);
		
		
		
		if (framesCooldownLaser > 0) {
			laserimage.color = Color.red;
		} else
			laserimage.color = Color.green;
		
		
		if (Input.GetKeyDown ("space")) {
			jump ();
		}
		
		
		if (Input.GetKeyDown ("mouse 1")) {
			fireLaser ();
		}
		
		if (Input.GetKeyDown ("mouse 0")) {
			launchGrenade ();
		}
		
		
		if (transform.rotation.eulerAngles.x != 0) {
			transform.Rotate (-transform.rotation.eulerAngles.x, 0, 0);
		}
		
		if (transform.rotation.eulerAngles.z != 0) {
			transform.Rotate (0, 0, -transform.rotation.eulerAngles.z);
		}
		
		if (framesCooldownJump > 0) {
			framesCooldownJump --;
		}
		if (framesCooldownLaser > 0) {
			framesCooldownLaser --;
		}
		if (starTimer > 0)
			starTimer--;
		
		if (starTimer <= 0) {
			godMode = false;
			if(rick.isPlaying)
			{
				rick.Pause();
				game.Play();
			}
		}
		
	}
	
}
