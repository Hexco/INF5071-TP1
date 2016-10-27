using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Oxygen : MonoBehaviour {

	public float maxHP = 100f;
	public float currentHP;
	public GameObject hpObject;

	public void textDecrease(){
		GameObject.Find("oxyText").GetComponent<Text> ().text = currentHP.ToString();

	}

	void Start() {
		currentHP = maxHP;
		InvokeRepeating ("decreaseOxygen",0.0f,2.0f);
		//InvokeRepeating ("textDecrease",0.0f,2.0f);
	}

	public void decreaseOxygen(){
		currentHP -= 2f;
		setHP (currentHP>0?currentHP:0);
	}

	public void setHP(float hp){
		float y = hpObject.transform.localScale.y;
		float z = hpObject.transform.localScale.z;
		float x = hp / maxHP;
		hpObject.transform.localScale = new Vector3 (x,y,z);
	}

	public void mineMinerals(){
		currentHP = maxHP;
		setHP (maxHP);
		textDecrease ();
	}
}
