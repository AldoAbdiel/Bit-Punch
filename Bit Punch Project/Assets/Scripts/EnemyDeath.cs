using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour {

	private float life = 64;
	private Animator anim;
	private SpriteRenderer render;
	public GameObject collider;
	
	void Start () {
		anim = GetComponent<Animator>();
		render = gameObject.GetComponent<SpriteRenderer>();
	}

	public void takeDamage(){
		life -= 20;
		if(life <= 0){
			collider.GetComponent<EnemyAttack>().enabled = false;
			gameObject.GetComponent<EnemyRoutine>().enabled = false;
			anim.SetBool("isDead", true);

			// Make points in Score
			GameObject go = GameObject.Find ("Camera");
			ScoreTimer scoreController = go.GetComponent<ScoreTimer>();
			scoreController.score += 2;
			
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
