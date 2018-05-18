using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour {

	public GameObject LevelController;
	public int foodScore = 50;

	public Transform playerTransf;
	public Rigidbody2D playerRB;
	public Animator playerAnim;

	//move and look
	public float moveSpeed = 5f;
	public Camera cam;
	private Vector3 mousePos;
	private float angle;

	//shooting
	public Rigidbody2D bulletPrefab; 
	public Transform muzzlePosition;

	//health
	public Image [] hearts;
	public int currentHeart;


	void Start () {
		playerTransf = GetComponent<Transform> ();
		playerRB = GetComponent<Rigidbody2D> ();
		playerAnim = GetComponent<Animator> ();

		LevelController = GameObject.FindGameObjectWithTag ("LevelController");

		currentHeart = hearts.Length;
	}
	

	void Update () {

		movePlayer ();

		playerShoot ();

		if (currentHeart <= 0)
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}


	void movePlayer(){

		//move player according to axis inputs
		playerTransf.position = new Vector2(playerTransf.position.x + Input.GetAxis("Horizontal")*moveSpeed*Time.deltaTime, playerTransf.position.y + Input.GetAxis ("Vertical")*moveSpeed*Time.deltaTime);
		float speed = Mathf.Abs(Input.GetAxis ("Horizontal")) + Mathf.Abs(Input.GetAxis ("Vertical"));
		playerAnim.SetFloat ("moveSpeed",speed);


		mousePos = cam.ScreenToWorldPoint (Input.mousePosition);
		var dir = mousePos - playerTransf.position;
		angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;

		if (!LevelController.GetComponent<PauseMenuController> ().pause) {

			//rotate player according to mouse position
			playerTransf.rotation = Quaternion.Euler (0f, 0f, angle);
		}

	}

	void playerShoot(){
		
		var dir = mousePos - playerTransf.position;

		if (Input.GetButtonDown ("Fire1")) {
			Instantiate (bulletPrefab, muzzlePosition.position, playerTransf.transform.rotation).AddForce(700 * new Vector2(dir.x,dir.y).normalized);
		}


	}


	void OnTriggerEnter2D(Collider2D hit){

		if (hit.gameObject.CompareTag ("Food")){
			Destroy (hit.gameObject);

			LevelController.GetComponent<ScoreController> ().score += foodScore;

			if (currentHeart < hearts.Length) {
				hearts [currentHeart].enabled = true;
				currentHeart++;
			}
		}

		if (hit.gameObject.CompareTag ("EnemyBullet")) {

			Destroy (hit.gameObject);
			hearts [currentHeart-1].enabled = false;
			currentHeart--;
		}

	}

	void OnCollisionEnter2D(Collision2D hit){
		if (hit.gameObject.CompareTag ("Enemy")) {
			hearts [currentHeart-1].enabled = false;
			currentHeart--;

		}




	}


}
