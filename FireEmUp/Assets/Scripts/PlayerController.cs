using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


	public Transform playerTransf;
	public Rigidbody2D playerRB;

	public float moveSpeed = 5f;

	private Vector3 mousePos;
	private float angle;

	public Camera cam;


	// Use this for initialization
	void Start () {
		playerTransf = GetComponent<Transform> ();
		playerRB = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		movePlayer ();


	}




	void movePlayer(){

		//move player according to axis inputs
		playerTransf.position = new Vector2(playerTransf.position.x + Input.GetAxis("Horizontal")*moveSpeed*Time.deltaTime, playerTransf.position.y + Input.GetAxis ("Vertical")*moveSpeed*Time.deltaTime);


		//rotate player according to mouse position

		mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
		var dir = mousePos - playerTransf.position;
		angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;

		playerTransf.rotation = Quaternion.Euler(0f,0f,angle);


	}
}
