using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

	//scoring
	public Text scoreText;
	public int score;
	public int enemyCount;

	public GameObject player;
	public GameObject shield;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		score = 0;
	}
	

	void Update () {
		scoreText.text = "Score : \n" + score;

		if (enemyCount >= 10) {
			enemyCount = 0;
			shield.gameObject.SetActive(true);
		}


	}
}
