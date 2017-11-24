using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour {

	private int life = 0;
	private Animator anim;
	private SpriteRenderer render;
	public GameObject collider;
	void Start () {
		anim = GetComponent<Animator>();
		render = gameObject.GetComponent<SpriteRenderer>();
	}
	
	public void takeDamage(){
		
		GameObject lifeObject;

		life += 1;

		switch(life){
			case 1:
			lifeObject = GameObject.Find("fullheart1");
			DestroyObject(lifeObject);
			break;
			case 2:
			lifeObject = GameObject.Find("half-heart1");
			DestroyObject(lifeObject);
			break;
			case 3:
			lifeObject = GameObject.Find("fullheart2");
			DestroyObject(lifeObject);
			break;
			case 4:
			lifeObject = GameObject.Find("half-heart2");
			DestroyObject(lifeObject);
			break;
			case 5:
			lifeObject = GameObject.Find("fullheart3");
			DestroyObject(lifeObject);
			break;
			case 6:
			lifeObject = GameObject.Find("half-heart3");
			DestroyObject(lifeObject);
			break;
			case 7:
			lifeObject = GameObject.Find("fullheart4");
			DestroyObject(lifeObject);
			break;
			case 8:
			lifeObject = GameObject.Find("half-heart4");
			DestroyObject(lifeObject);
			break;
		}
		
		if(life >= 8){
			GameObject go = GameObject.Find ("Camera");
			ScoreTimer timerController = go.GetComponent<ScoreTimer>();
			timerController.gameFinished = true;

			gameObject.GetComponent<PlayerMovement>().enabled = false;
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
