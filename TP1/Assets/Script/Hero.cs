using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour {

	public float speed = 1.0f;
	public GameObject character;
	SpriteRenderer hero;
	public Sprite frontStand;
	public Sprite frontLeftArm;
	public Sprite frontRightArm;

	public Sprite leftStand;
	public Sprite leftLeftArm;
	public Sprite leftRightArm;

	public Sprite backStand;
	public Sprite backLeftArm;
	public Sprite backRightArm;

	public Sprite rightStand;
	public Sprite rightLeftArm;
	public Sprite rightRightArm;
	static int count = 0;


	void Start()
	{
		
		hero = character.GetComponent<SpriteRenderer>();
		hero.sprite = frontStand;
	}

	void LeftArrow(){
		
		if (hero.sprite == leftRightArm) {
			Debug.Log ("test");
			count++;
			hero.sprite = leftStand;
		} else if (hero.sprite == leftLeftArm) {
			count--;
			hero.sprite = leftStand;
		} else {
			if (count == 0) {
				hero.sprite = leftRightArm;
			} else {
				hero.sprite = leftLeftArm;
			}
		}
	}


	void Update() {

		if (Input.GetKeyDown(KeyCode.LeftArrow)){
			Debug.Log ("test");
			LeftArrow ();
		}
		var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
				character.transform.position += move * speed * Time.deltaTime;
	}



}