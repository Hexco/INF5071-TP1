using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Hunger : MonoBehaviour
{

	public float maxHP = 100f;
	public static float currentHP;
	public GameObject hpObject;

	void Start ()
	{
		currentHP = maxHP;
		InvokeRepeating ("decreaseHunger", 0.0f, 6.0f);
	}

	public void decreaseHunger ()
	{
		currentHP -= 4f;
		setHP (currentHP);
	}

	public void setHP (float hp)
	{
		GameObject hpObject = GameObject.Find ("HungerBar");
		float y = hpObject.transform.localScale.y;
		float z = hpObject.transform.localScale.z;
		float x = hp / maxHP;
		hpObject.transform.localScale = new Vector3 (x, y, z);
	}

	public void farmSomePotato ()
	{
		currentHP += 30;
		if (currentHP > maxHP) {
			currentHP = maxHP;
		}
		setHP (currentHP);

	}
}
