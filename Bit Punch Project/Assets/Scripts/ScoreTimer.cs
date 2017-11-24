using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreTimer : MonoBehaviour {

	public Text timerText;
	public Text scoreText;
	private float startTime;
	public bool gameFinished;
	public int score;
	void Start () {
		score = 0;
		startTime = Time.time;
		gameFinished = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		if(!gameFinished){
			float t = Time.time - startTime;
			string minutes = ((int) t / 60).ToString();
			string seconds = (t % 60).ToString();

			timerText.text = "Time: " + minutes + ":" + seconds;
			scoreText.text = "Score: " + score;
		}
	}
}
