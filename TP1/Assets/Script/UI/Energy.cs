using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Energy : MonoBehaviour {

	public float maxHP = 100f;
	public float currentHP;
	public GameObject hpObject;


	public void textDecrease(){
		GameObject.Find("energyTextNumber").GetComponent<Text> ().text = currentHP.ToString();

	}

	void Start() {
		currentHP = maxHP;
		InvokeRepeating ("decreaseEnergy",0.0f,2.0f);
		//InvokeRepeating ("textDecrease",0.0f,2.0f);
	}

	public void decreaseEnergy(){

		currentHP -= 1f;
		setHP (currentHP>0?currentHP:0);
	}

	public void setHP(float hp){
		float y = hpObject.transform.localScale.y;
		float z = hpObject.transform.localScale.z;
		float x = hp / maxHP;
		hpObject.transform.localScale = new Vector3 (x,y,z);
	}

	public void reloadEnergy(){
		currentHP = maxHP;
		setHP (maxHP);
		textDecrease ();
	}
}
