using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRoutine : MonoBehaviour {

	// Use this for initialization
	private Animator anim;
	private bool movementController = true;

	private bool enemyIsAttacked = false;

	//public static bool isHurted = false;
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!enemyIsAttacked){
			if(this.transform.position.x < 1 && movementController == true){
				transform.position += new Vector3(2.0f, 0, 0).normalized * Time.deltaTime;
				anim.SetFloat("x", 1f);
			}else{
				movementController = false;
			}

			if(this.transform.position.x > -1 && movementController == false){
				transform.position += new Vector3(-2.0f, 0, 0).normalized * Time.deltaTime;
				anim.SetFloat("x", -1f);
			}else{
				movementController = true;
			}
		}
	}

	public void getDelay(GameObject objectCollided){
		enemyIsAttacked = true;
		StartCoroutine(EnemyHurDelay(objectCollided));
	}
	public IEnumerator EnemyHurDelay(GameObject objectCollided){
		Animator enemyAnim = objectCollided.GetComponent<Animator>();
		while (true) {
			yield return new WaitForSeconds(1.0f); // anim duration
			enemyAnim.SetBool("isHurt", false);
			enemyIsAttacked = false;
			StopAllCoroutines();
		}
	}

	public void prueba(bool valor){
		enemyIsAttacked = valor;
	}
}
