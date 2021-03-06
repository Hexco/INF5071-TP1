﻿using UnityEngine;
using System.Collections;

public class HeroMovement : MonoBehaviour {
	private Rigidbody2D rigi;
	public float maxSpeed = 10f;
	static bool facingUp = false;
	static bool facingLeft = false;
	static bool facingRight = false;
	static bool facingDown = false;

	Animator animator;

	void Start(){
		rigi = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
	}

	void playWalkingAnimation(string side){
		var move = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
		animator.SetBool (side, true);
		transform.position += move * maxSpeed * Time.deltaTime;
	}

	void playMiningAnimation(){
		string side = findSide ();
		animator.SetBool (side + "Mining", true);
	}
	
	public string findSide(){
		if (facingUp == true){
			return "Up";
		} else if (facingDown == true){
			return "Down";
		} else if (facingLeft == true){
			return "Left";
		} else if (facingRight == true){
			return "Right";
		}
		return null;
	}

	void setParameterAnimator(string first, string second, string third){
		animator.SetBool (first,false);
		animator.SetBool (second,false);
		animator.SetBool (third,false);

	}

	void setFacingFalse(){
		facingUp = false;
		facingLeft = false;
		facingRight = false;
		facingDown = false;
	}

	void playSecretAnimation(){
		animator.SetBool ("Secret", true);
	}
	void FixedUpdate(){
		if (
			animator.GetCurrentAnimatorStateInfo (0).IsName ("MiningUp") ||
			animator.GetCurrentAnimatorStateInfo (0).IsName ("MiningDown") ||
			animator.GetCurrentAnimatorStateInfo (0).IsName ("MiningLeft") ||
			animator.GetCurrentAnimatorStateInfo (0).IsName ("MiningRight") ||
			animator.GetCurrentAnimatorStateInfo(0).IsName("Secret")
		) {
			animator.SetBool ("UpMining", false);
			animator.SetBool ("DownMining", false);
			animator.SetBool ("LeftMining", false);
			animator.SetBool ("RightMining", false);
			animator.SetBool ("Secret",false);
			return;
		}
			
		if (Input.GetAxis ("Vertical") < 0) {
			setFacingFalse ();
			setParameterAnimator ("Up","Left","Right");
			facingDown = true;
			playWalkingAnimation ("Down");

		} else if (Input.GetAxis ("Vertical") > 0) {
			setParameterAnimator ("Down","Left","Right");
			setFacingFalse ();
			facingUp = true;
			playWalkingAnimation ("Up");

		} else if (Input.GetAxis ("Horizontal") < 0) {
			setParameterAnimator ("Up","Down","Right");
			setFacingFalse ();
			facingLeft = true;
			playWalkingAnimation ("Left");


		} else if (Input.GetAxis ("Horizontal") > 0) {
			setParameterAnimator ("Up","Left","Down");
			setFacingFalse ();
			facingRight = true;
			playWalkingAnimation ("Right");

		} else if (Input.GetKey(KeyCode.E)){
			
			//playMiningAnimation ();


		} else if (Input.GetKey(KeyCode.P)){

			playSecretAnimation ();
			Hunger hunger = new Hunger ();
			Energy energy = new Energy ();
			energy.reloadEnergy ();
			hunger.farmSomePotato ();

		} else {
			animator.SetBool ("Down", false);
			animator.SetBool ("Up", false);
			animator.SetBool ("Left", false);
			animator.SetBool ("Right", false);
		}


	}






		

}

