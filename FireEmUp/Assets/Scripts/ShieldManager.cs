using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldManager : MonoBehaviour {

	public float maxTimer;
	public float shieldTime;

	void Start () {
		
	}

	void Update () {
		
	}



	void OnTriggerEnter2D(Collider2D hit){

		if (hit.gameObject.CompareTag ("Enemy")) {
			Destroy (hit.gameObject);
		}

		if (hit.gameObject.CompareTag ("EnemyBullet")) {
			Destroy (hit.gameObject);
		}
	}

}
