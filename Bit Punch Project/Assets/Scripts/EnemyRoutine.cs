using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRoutine : MonoBehaviour {

	// Use this for initialization
	private Animator anim;

	public GameObject collider;
	private bool movementController = true;

	public bool enemyIsAttacked = false;

	void Start () {
		anim = GetComponent<Animator>();
	}
	
	void Update () {
		if(!enemyIsAttacked){
			if(this.transform.position.x < 1 && movementController == true){
				collider.transform.position = new Vector3(this.transform.position.x + 0.12f, collider.transform.position.y, collider.transform.position.z);
				transform.position += new Vector3(2.0f, 0, 0).normalized * Time.deltaTime;
				anim.SetFloat("x", 1f);
			}else{
				movementController = false;
			}

			if(this.transform.position.x > -1 && movementController == false){
				collider.transform.position = new Vector3(this.transform.position.x - 0.12f, collider.transform.position.y, collider.transform.position.z);
				transform.position += new Vector3(-2.0f, 0, 0).normalized * Time.deltaTime;
				anim.SetFloat("x", -1f);
			}else{
				movementController = true;
			}
		}
	}

	public void getDelay(GameObject objectCollided){
		enemyIsAttacked = true;
		collider.GetComponent<EnemyAttack>().enabled = false;
		StartCoroutine(EnemyHurDelay(objectCollided));
	}
	IEnumerator EnemyHurDelay(GameObject objectCollided){
		Animator enemyAnim = objectCollided.GetComponent<Animator>();
		while (true) {
			yield return new WaitForSeconds(1.0f); // anim duration
			enemyAnim.SetBool("isHurt", false);
			enemyIsAttacked = false;
			collider.GetComponent<EnemyAttack>().enabled = true;
			StopAllCoroutines();
		}
	}
}
