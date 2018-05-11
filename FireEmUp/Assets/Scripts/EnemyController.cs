using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	//move variables
	public GameObject player;
	private Transform enemyTransf;
	public float moveSpeed;

	//shooting variables
	private float cooldown = 2f;
	private float shootingCounter;
	public Rigidbody2D bulletPrefab;
	public bool allowShooting;

	

	// Use this for initialization
	void Start () {
		enemyTransf = GetComponent<Transform> ();
		player = GameObject.FindGameObjectWithTag ("Player");

		shootingCounter = 0f;
	}
	

	void FixedUpdate () {
		MoveEnemy ();

		if(allowShooting)
			ShootEnemy ();
	}


	void MoveEnemy(){
		
		enemyTransf.position = Vector2.MoveTowards (enemyTransf.position, player.transform.position, moveSpeed*Time.deltaTime);

		//rotate enemy sprite towards player
		var direction =  player.transform.position - enemyTransf.position;
		var angle = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;

		enemyTransf.rotation = Quaternion.Euler (0f, 0f, angle);
	}

	void ShootEnemy(){

		shootingCounter += Time.deltaTime;

		var direction =  (player.transform.position - enemyTransf.position);

		if (shootingCounter >= cooldown) {
			
			shootingCounter = 0;

			var bullet = Instantiate (bulletPrefab, enemyTransf.position, enemyTransf.rotation) as Rigidbody2D;

			bullet.AddForce (300 * new Vector2(direction.x,direction.y).normalized);

		}

	}
}
