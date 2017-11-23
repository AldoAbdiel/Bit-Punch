using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	private Animator anim;
	public GameObject collider;
	private bool isPunching;
	void Start () {
		isPunching = false;
		anim = GetComponent<Animator>();
		
	}
	
	void Update () {
		isPunching = collider.GetComponent<PlayerAttack>().isPunching;

		if(!isPunching){ // prevent movement during punch animation
			float input_x = Input.GetAxisRaw("Horizontal");
			float input_y = Input.GetAxisRaw("Vertical");

			bool isWalking = (Mathf.Abs(input_x) + Mathf.Abs(input_y)) > 0;

			anim.SetBool("isWalking", isWalking);

			if(isWalking){
				anim.SetFloat("x", input_x);
				anim.SetFloat("y", input_y);

				transform.position += new Vector3(input_x, input_y, 0).normalized * Time.deltaTime;
			}

			if(input_x == 1){
				collider.transform.position = new Vector3(this.transform.position.x + 0.12f, collider.transform.position.y, collider.transform.position.z);
			}else if(input_x == -1){
				collider.transform.position = new Vector3(this.transform.position.x - 0.12f, collider.transform.position.y, collider.transform.position.z);
			}
		}
	}
}
