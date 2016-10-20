using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeClicked : MonoBehaviour {
	static int energy = 100;


	void Start() {
		InvokeRepeating ("caca",0.0f,2.0f);
	}

	public void caca(){
		energy--;
		GameObject.Find("Times").GetComponent<Text> ().text = energy.ToString();

	}


}
