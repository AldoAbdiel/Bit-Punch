using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

	public GameObject fatherObjetc;
	private Animator anim, playerAnim;
	public BoxCollider2D colliderPunch;

	private bool isPunching;

	// Use this for initialization
	void Start () {
		anim = fatherObjetc.GetComponent(typeof(Animator)) as Animator;
	}
	
	// Update is called once per frame
	void Update ( ) {
		StartCoroutine(AutoPunch());
	}

	IEnumerator AutoPunch(){

		while (true) {
			yield return new WaitForSeconds(Random.Range(1.0f, 8.0f));
			anim.SetBool("isPunching", true);
			colliderPunch.enabled = true;

			yield return new WaitForSeconds(0.5f);
			anim.SetBool("isPunching", false);
			colliderPunch.enabled = false;
			StopAllCoroutines();
		}
	}

	void OnTriggerEnter2D(Collider2D collider){
		GameObject objectCollided = collider.gameObject;
		
		if(objectCollided.CompareTag("Player")){
			playerAnim = objectCollided.GetComponent<Animator>();
			playerAnim.SetBool("isHurted", true);
			objectCollided.GetComponent<PlayerMovement>().getDelay(objectCollided);

			// Make damage to player
			objectCollided.GetComponent<PlayerDeath>().takeDamage();
		}
	}
}
