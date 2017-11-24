using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Timer : MonoBehaviour {

	public Text timerText;
	private float startTime;
	public bool gameFinished;

	void Start () {
		startTime = Time.time;
		gameFinished = false;
	}
	
	void Update () {
		if(!gameFinished){
			float t = Time.time - startTime;
			string minutes = ((int) t / 60).ToString();
			string seconds = (t % 60).ToString();

			timerText.text = "Time: " + minutes + ":" + seconds;			
		}
	}
}
