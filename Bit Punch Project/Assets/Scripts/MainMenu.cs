﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	public void changeMenuScene(string sceneName){
		SceneManager.LoadScene(sceneName);
	}
}
