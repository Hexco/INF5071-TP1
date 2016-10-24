using UnityEngine;
using System.Collections;

public class HeroMovement : MonoBehaviour {
	private Rigidbody2D rigi;
	public float maxSpeed = 10f;
	bool facingFront = true;
	bool facingLeft = false;
	bool facingRight = false;
	bool facingBack = false;

	Animator animator;

	void Start(){
		rigi = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
	}

	void Update(){
		if (Input.GetKey (KeyCode.DownArrow) || Input.GetKey (KeyCode.S)) {
			var move = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
			animator.SetBool ("Down", true);
			transform.position += move * maxSpeed * Time.deltaTime;

		} else if (Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.W)) {
			var move = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
			animator.SetBool ("Up", true);
			transform.position += move * maxSpeed * Time.deltaTime;

		} else if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A)) {
			var move = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
			animator.SetBool ("Left", true);
			transform.position += move * maxSpeed * Time.deltaTime;

		} else if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D)) {
			var move = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
			animator.SetBool ("Right", true);
			transform.position += move * maxSpeed * Time.deltaTime;

		} else {
			animator.SetBool ("Down", false);
			animator.SetBool ("Up", false);
			animator.SetBool ("Left", false);
			animator.SetBool ("Right", false);

		}


	}


		

}

