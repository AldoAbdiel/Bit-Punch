using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour {

	// Use this for initialization
	private float life = 64;
	private Animator anim;

	private SpriteRenderer render;
	void Start () {
		anim = GetComponent<Animator>();
		render = gameObject.GetComponent<SpriteRenderer>();
	}

	public void takeDamage(){
		life -= 20;
		if(life <= 0){
			gameObject.GetComponent<EnemyRoutine>().enabled = false;
			anim.SetBool("isDead", true);
			StartCoroutine(Wait());
			
		}
	}

	 IEnumerator Wait()
     {
        yield return new WaitForSeconds(0.2f);
        render.enabled = false;

        yield return new WaitForSeconds(0.2f);
		render.enabled = true;

		yield return new WaitForSeconds(0.2f);
		render.enabled = false;

		yield return new WaitForSeconds(0.2f);
		render.enabled = true;

		yield return new WaitForSeconds(0.2f);
		render.enabled = false;

		yield return new WaitForSeconds(0.2f);
		render.enabled = true;

		yield return new WaitForSeconds(0.2f);
		render.enabled = false;

		yield return new WaitForSeconds(0.4f);
		render.enabled = true;

		Destroy(gameObject);
     }
}
