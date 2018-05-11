using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


	public Transform playerTransf;
	public Rigidbody2D playerRB;
	public Animator playerAnim;

	public float moveSpeed = 5f;
	public Camera cam;
	private Vector3 mousePos;
	private float angle;



	// Use this for initialization
	void Start () {
		playerTransf = GetComponent<Transform> ();
		playerRB = GetComponent<Rigidbody2D> ();
		playerAnim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		movePlayer ();


	}


	void movePlayer(){

		//move player according to axis inputs
		playerTransf.position = new Vector2(playerTransf.position.x + Input.GetAxis("Horizontal")*moveSpeed*Time.deltaTime, playerTransf.position.y + Input.GetAxis ("Vertical")*moveSpeed*Time.deltaTime);
		float speed = Mathf.Abs(Input.GetAxis ("Horizontal")) + Mathf.Abs(Input.GetAxis ("Vertical"));
		playerAnim.SetFloat (moveSpeed,speed);
			
		//rotate player according to mouse position

		mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
		var dir = mousePos - playerTransf.position;
		angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;

		playerTransf.rotation = Quaternion.Euler(0f,0f,angle);


	}


	void OnCollisionEnter2D(Collision2D hit){
		if (hit.gameObject.CompareTag ("Enemy")) {
			//damage code
		}

	}

	void OnTriggerEnter2D(Collider2D hit){

		if (hit.gameObject.CompareTag ("EnemyBullet")) {

			Destroy (hit.gameObject,0);
			//damage code
		}

	}
}
