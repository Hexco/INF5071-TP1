﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class PlayerCloseTrigger : MonoBehaviour
{

	public GameObject plantBase;
	public GameObject patate1;
	public GameObject patate2;
	public GameObject patate3;
	public GameObject arbre1;
	public GameObject arbre2;
	public GameObject arbre3;
	public GameObject anchor;
	public GameObject patate;
	public float delay;

	public Text actionText1;
	public Text actionText2;
	public Text actionText3;

	private GameObject plant;
	private int level;
	private string typePlante;
	private bool playerIn;
	private float delayed;
	private bool watered;
	private bool dry;

	private SortedList patateList;
	private SortedList arbreList;
	private SortedList plantList;

	private Vector3 anchorPosi;
	private Quaternion anchorAngle;
	private Vector3 tempAngle;

	// Use this for initialization
	void Start ()
	{
		level = 0;
		delayed = 0.0f;
		anchorPosi = anchor.transform.position;
		anchorPosi.y = anchorPosi.y + 0.1f;
		anchorAngle = anchor.transform.rotation;
		typePlante = "";
		watered = false;
		// reset Text
		ReSetActionText ();

		patateList = new SortedList ();
		patateList.Add (0, plantBase);
		patateList.Add (1, patate1);
		patateList.Add (2, patate2);
		patateList.Add (3, patate3);

		arbreList = new SortedList ();
		arbreList.Add (0, plantBase);
		arbreList.Add (1, arbre1);
		arbreList.Add (2, arbre2);
		arbreList.Add (3, arbre3);

		plantList = new SortedList ();
		plantList.Add ("Patate", patateList);
		plantList.Add ("Arbre", arbreList);
	}

	// Update is called once per frame
	void Update ()
	{
		if (Time.time > delayed && playerIn) {
			switch (level) {
			case 0:
				if (Input.GetKey ("j")) {
					PlantPlant (plantBase);
					typePlante = "Patate";
					endAction ();
				} else if (Input.GetKey ("k")) {
					PlantPlant (plantBase);
					typePlante = "Arbre";
					endAction ();
				}
				break;
			case 1:
			case 2:
			case 3:
				if (Input.GetKey ("j")) {
					DestroyPlant ();
					endAction ();
				}
				if (Input.GetKey ("k")) {
					WaterPlant ();
					endAction ();
				}
				break;
			case 4:
				if (Input.GetKey ("j")) {
					DestroyPlant ();
					endAction ();
				} else if (Input.GetKey ("k") && typePlante == "Patate") {
					HarvestPlant ();
					endAction ();
				} else if (Input.GetKey ("k") && typePlante == "Arbre") {
					WaterPlant ();
					endAction ();
				}
				break;
			}
		}
	}

	void endAction ()
	{
		delayed = Time.time + delay;
		SetActionText ();
	}

	void PlantPlant (GameObject gameObj)
	{
		Destroy (plant);
		plant = (GameObject)Instantiate (gameObj, anchorPosi, RandomRotate (), anchor.transform);
		level++;
	}

	void WaterPlant ()
	{
		if (!watered) {
			if (InventoryBackEnd.nbWater > 0) {
				InventoryBackEnd.nbWater--;
				Water.decreaseWater ();
				watered = true;
				dry = false;
			}
		}
	}

	void DestroyPlant ()
	{
		level = 0;
		Destroy (plant);
	}

	void HarvestPlant ()
	{
		if (typePlante == "Patate") {
			float n = Random.Range (3.0f, 8.0f);
			Debug.Log (n);
			for (float i = 0.0f; i < n; i++) {
				Instantiate (patate, new Vector3 (250, 10 + 3 * i, 250), plant.transform.localRotation);
			}
		}
		DestroyPlant ();
	}

	public void EndDay ()
	{
		if (level > 0) {
			if (watered) {
				if (level < 4) {
					PlantPlant ((GameObject)((SortedList)plantList [typePlante]) [level]);
				}
			} else if (dry) {
				DestroyPlant ();
			} else {
				dry = true;
			}
		}
		watered = false;
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player") {
			playerIn = true;
			SetActionText ();
		}
	}

	void OnTriggerExit (Collider other)
	{
		if (other.tag == "Player") {
			playerIn = false;
			ReSetActionText ();
		}
	}

	void SetActionText ()
	{
		switch (level) {
		case 0:
			actionText1.text = "Press J to plant Potato";
			actionText2.text = "Press K to plant Tree";
			actionText3.color = Color.white;
			break;
		case 1:
		case 2:
		case 3:
			// TODO if need water
			actionText1.text = "Press J to destroy " + typePlante;
			actionText2.text = "Press K to water " + typePlante;
			if (watered) {
				actionText3.text = "Watered";
				actionText3.color = Color.blue;
			} else {
				if (dry) {
					actionText3.text = "Dry!!!";
					actionText3.color = Color.red;
				} else {
					actionText3.text = "Unwatered";
					actionText3.color = Color.yellow;
				}
			}
			break;
		case 4:
			// TODO recolter
			actionText1.text = "Press J to destroy " + typePlante;
			if (typePlante == "Patate") {
				actionText2.text = "Press K to harvest " + typePlante;
			} else if (typePlante == "Arbre") {
				actionText2.text = "Press K to water " + typePlante;
			}
			if (watered) {
				actionText3.text = "Watered";
				actionText3.color = Color.blue;
			} else {
				if (dry) {
					actionText3.text = "Dry!!!";
					actionText3.color = Color.red;
				} else {
					actionText3.text = "Unwatered";
					actionText3.color = Color.yellow;
				}
			}
			break;
		default:
			ReSetActionText ();
			break;
		}
	}

	void ReSetActionText ()
	{
		actionText1.text = "";
		actionText2.text = "";
		actionText3.text = "";
	}

	Quaternion RandomRotate ()
	{
		anchorAngle.eulerAngles = new Vector3 (anchorAngle.eulerAngles.x, anchorAngle.eulerAngles.y, Random.rotation.eulerAngles.z);
		return anchorAngle;
	}
}
