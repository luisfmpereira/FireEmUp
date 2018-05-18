using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawnController : MonoBehaviour {


	public float respawnRate = 5f;
	private float respawnCounter;
	public Transform respawnArea;
	public GameObject [] newEnemy;

	public bool horizontalSpawn;

	// Use this for initialization
	void Start () {
		respawnArea = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		respawnCounter -= Time.deltaTime;
		 
		if (respawnCounter <= 0) {
			respawnCounter = respawnRate;
			if(horizontalSpawn)
				Instantiate(newEnemy[Random.Range(0,newEnemy.Length)],new Vector3(Random.Range(-10,10),respawnArea.position.y,0),Quaternion.identity);
			else
				Instantiate(newEnemy[Random.Range(0,newEnemy.Length)],new Vector3(respawnArea.position.x,Random.Range(-10,10),0),Quaternion.identity);
		}
	}
}
