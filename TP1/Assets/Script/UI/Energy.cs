using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Energy : MonoBehaviour {

	public float maxHP = 100f;
	public static float currentHP;
	public GameObject hpObject;

	void Start() {
		currentHP = maxHP;
		InvokeRepeating ("decreaseEnergy",0.0f,2.0f);
	}

	public void decreaseEnergy(){

		currentHP -= 1f;
		setHP (currentHP);
	}

	public void setHP(float hp){
		GameObject hpObject = GameObject.Find ("EnergyBar");
		float y = hpObject.transform.localScale.y;
		float z = hpObject.transform.localScale.z;
		float x = hp / maxHP;
		hpObject.transform.localScale = new Vector3 (x,y,z);
	}

	public void reloadEnergy(){
		currentHP = maxHP;
		setHP (maxHP);
	}
}
