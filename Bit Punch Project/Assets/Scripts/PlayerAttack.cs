using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

	// Use this for initialization
	public BoxCollider2D colliderPunch;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("space")){
			colliderPunch.enabled = true;
			StartCoroutine (PunchDelay ());
		}
	}

	IEnumerator PunchDelay(){
		while (true) {
			yield return new WaitForSeconds(1.0f);
			colliderPunch.enabled = false;
			StopAllCoroutines();
		}
	}
}
