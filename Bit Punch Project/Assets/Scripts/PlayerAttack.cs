using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

	public GameObject fatherObjetc;
	private Animator anim, enemyAnim;
	public BoxCollider2D colliderPunch;
	public bool isPunching = false;

	void Start () {
		anim = fatherObjetc.GetComponent(typeof(Animator)) as Animator;
	}
	
	void Update () {
		if (Input.GetKeyDown("space")){
			// Activate colliders for punch and start animation
			colliderPunch.enabled = true;
			isPunching = true;
			anim.SetBool("isPunching", isPunching);
			StartCoroutine (PunchDelay ());
		}
	}	

	IEnumerator PunchDelay(){
		while (true) {
			yield return new WaitForSeconds(0.5f); // anim duration
			colliderPunch.enabled = false;
			isPunching = false;
			anim.SetBool("isPunching", isPunching);
			
			StopAllCoroutines();
		}
	}

	void OnTriggerEnter2D(Collider2D collider){
		GameObject objectCollided = collider.gameObject;
		
		if(objectCollided.CompareTag("Enemy")){ // if the target object is an enemy
			// Handle enemy animation
			enemyAnim = objectCollided.GetComponent<Animator>();
			enemyAnim.SetBool("isHurt", true);
			objectCollided.GetComponent<EnemyRoutine>().getDelay(objectCollided);

			// Make damage to enemy
			objectCollided.GetComponent<EnemyDeath>().takeDamage();
		}
	}
}