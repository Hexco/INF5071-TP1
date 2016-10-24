using UnityEngine;
using System.Collections;

public class HeroMovement : MonoBehaviour {
	private Rigidbody2D rigi;
	public float maxSpeed = 10f;
	bool facingUp = false;
	bool facingLeft = false;
	bool facingRight = false;
	bool facingDown = false;

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
	
	string findSide(){
		Debug.Log ("------------------------------------------");
		Debug.Log ("Up : " + facingUp);
		Debug.Log ("Down : " + facingDown);
		Debug.Log ("Left : " + facingLeft);
		Debug.Log ("Right : " + facingRight);
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


	void setFacingFalse(){
		facingUp = false;
		facingLeft = false;
		facingRight = false;
		facingDown = false;
	}

	void FixedUpdate(){
		if (
			animator.GetCurrentAnimatorStateInfo (0).IsName ("MiningUp") ||
			animator.GetCurrentAnimatorStateInfo (0).IsName ("MiningDown") ||
			animator.GetCurrentAnimatorStateInfo (0).IsName ("MiningLeft") ||
			animator.GetCurrentAnimatorStateInfo (0).IsName ("MiningRight")
		) {
			animator.SetBool ("UpMining", false);
			animator.SetBool ("DownMining", false);
			animator.SetBool ("LeftMining", false);
			animator.SetBool ("RightMining", false);
			return;
		}
			
		if (Input.GetKey (KeyCode.DownArrow) || Input.GetKey (KeyCode.S)) {
			
			playWalkingAnimation ("Down");
			setFacingFalse ();
			facingDown = true;

		} else if (Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.W)) {
			playWalkingAnimation ("Up");
			setFacingFalse ();
			facingUp = true;

		} else if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A)) {
			
			playWalkingAnimation ("Left");
			setFacingFalse ();
			facingLeft = true;

		} else if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D)) {
			
			playWalkingAnimation ("Right");
			setFacingFalse ();
			facingRight = true;

		} else if (Input.GetKey(KeyCode.E)){
			
			playMiningAnimation ();

		} else {
			animator.SetBool ("Down", false);
			animator.SetBool ("Up", false);
			animator.SetBool ("Left", false);
			animator.SetBool ("Right", false);


		}


	}






		

}

