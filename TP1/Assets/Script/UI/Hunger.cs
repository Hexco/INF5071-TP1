using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Hunger : MonoBehaviour {

	public float maxHP = 100f;
	public static float currentHP;
	public GameObject hpObject;

	public void textDecrease(){
		GameObject.Find("faimText").GetComponent<Text> ().text = currentHP.ToString();

	}

	void Start() {
		currentHP = maxHP;
		InvokeRepeating ("decreaseHunger",0.0f,1.0f);
		//InvokeRepeating ("textDecrease",0.0f,5.0f);
	}

	public void decreaseHunger(){

		currentHP -= 7f;
		setHP (currentHP);
		if (currentHP < 0) {
			Debug.Log ("Caca");
		}
	}

	public void setHP(float hp){
		float y = hpObject.transform.localScale.y;
		float z = hpObject.transform.localScale.z;
		float x = hp / maxHP;
		hpObject.transform.localScale = new Vector3 (x,y,z);
	}

	public void farmSomePotato(){
		currentHP = maxHP;
		setHP (maxHP);
		textDecrease ();
	}
}
