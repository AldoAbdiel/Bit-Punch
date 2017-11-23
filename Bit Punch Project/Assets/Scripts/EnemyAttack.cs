using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

	public GameObject fatherObjetc;
	private Animator anim;
	public BoxCollider2D colliderPunch;

	private bool isPunching;

	// Use this for initialization
	void Start () {
		anim = fatherObjetc.GetComponent(typeof(Animator)) as Animator;
	}
	
	// Update is called once per frame
	void Update () {
		StartCoroutine(AutoPunch());
	}

	IEnumerator AutoPunch(){

		while (true) {
			//isPunching = true;
			yield return new WaitForSeconds(Random.Range(3.0f, 6.0f));
			anim.SetBool("isPunching", true);
			//fatherObjetc.GetComponent<EnemyRoutine>()
			fatherObjetc.GetComponent<EnemyRoutine>().prueba(true);
			yield return new WaitForSeconds(0.5f);
			anim.SetBool("isPunching", false);
			fatherObjetc.GetComponent<EnemyRoutine>().prueba(false);
			//fatherObjetc.GetComponent<EnemyRoutine>().enabled = false;
			
			//colliderPunch.enabled = false;
			//isPunching = false;
			//anim.SetBool("isPunching", isPunching);
			StopAllCoroutines();
		}
	}
}
