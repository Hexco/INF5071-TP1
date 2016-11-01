using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Oxygen : MonoBehaviour {

	public float maxHP = 100f;
	public static float currentHP;
	public GameObject hpObject;

	void Start() {
		currentHP = maxHP;
		InvokeRepeating ("decreaseOxygen",0.0f,2.0f);
	}

	public void decreaseOxygen(){
		currentHP -= 2f;
		setHP (currentHP);
	}

	public void setHP(float hp){
		GameObject hpObject = GameObject.Find ("OxygenBar");
		float y = hpObject.transform.localScale.y;
		float z = hpObject.transform.localScale.z;
		float x = hp / maxHP;
		hpObject.transform.localScale = new Vector3 (x,y,z);
	}

	public void mineMinerals(){
		currentHP = maxHP;
		setHP (maxHP);
	}
}
