using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Water : MonoBehaviour {

	public static float currentWater;
	public GameObject waterText;

	public static void increaseWater(){
		currentWater++;
		GameObject.Find ("WaterNb").GetComponent<Text> ().text = currentWater.ToString(); 
	}

	public static void decreaseWater(){
		currentWater--;
		GameObject.Find ("WaterNb").GetComponent<Text> ().text = currentWater.ToString(); 
	}

}
