using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

	//private Animator anim;
	public GameObject fatherObjetc;
	private Animator anim, enemyAnim;
	public BoxCollider2D colliderPunch;
	public bool isPunching = false;

	//private float enemyLife = EnemyDeath.enemyLife;
	//private bool getIsHurted = EnemyRoutine.isHurted;

	void Start () {
		anim = fatherObjetc.GetComponent(typeof(Animator)) as Animator;
		//anim["isPunching"].time = 0.0f;
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
		
		if(objectCollided.CompareTag("Enemy")){
			//Debug.Log("golpe realizado");

			// Handle animation
			enemyAnim = objectCollided.GetComponent<Animator>();
			enemyAnim.SetBool("isHurt", true);
			objectCollided.transform.position = new Vector3(objectCollided.transform.position.x , objectCollided.transform.position.y, 0);
			objectCollided.GetComponent<EnemyRoutine>().getDelay(objectCollided);

			// Do damage to enemy
			objectCollided.GetComponent<EnemyDeath>().takeDamage();

		}
	}
}