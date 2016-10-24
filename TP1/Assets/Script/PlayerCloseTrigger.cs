using UnityEngine;
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
	public float delay;

	private GameObject plant;
	private int level;
	private string typePlante;
	private bool playerIn;
	private float delayed;

	private Vector3 anchorPosi;
	private Vector3 anchorAngle;

	// Use this for initialization
	void Start ()
	{
		level = 0;
		delayed = 0.0f;
		anchorPosi = anchor.transform.position;
		anchorPosi.y = anchorPosi.y + 0.1f;
		typePlante = "";
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetButton ("Fire1") && Time.time > delayed && playerIn 
				&& (typePlante == "Patate" || typePlante == "")) {
			delayed = Time.time + delay;
			switch (level) {
			case 0:
				plant = (GameObject)Instantiate (plantBase, anchorPosi, anchor.transform.rotation, anchor.transform);
				level = 1;
				typePlante = "Patate";
				break;
			case 1:
				Destroy (plant);
				plant = (GameObject)Instantiate (patate1, anchorPosi, anchor.transform.rotation, anchor.transform);
				level = 2;
				break;
			case 2:
				Destroy (plant);
				plant = (GameObject)Instantiate (patate2, anchorPosi, anchor.transform.rotation, anchor.transform);
				level = 3;
				break;
			case 3:
				Destroy (plant);
				plant = (GameObject)Instantiate (patate3, anchorPosi, anchor.transform.rotation, anchor.transform);
				level = 4;
				break;
			case 4:
				Destroy (plant);
				//Spawn patates
				level = 0;
				typePlante = "";
				break;
			}
		}

		if (Input.GetButton ("Fire2") && Time.time > delayed && playerIn 
			&& (typePlante == "Arbre" || typePlante == "")) {
			delayed = Time.time + delay;
			switch (level) {
			case 0:
				plant = (GameObject)Instantiate (plantBase, anchorPosi, anchor.transform.rotation, anchor.transform);
				level = 1;
				typePlante = "Arbre";
				break;
			case 1:
				Destroy (plant);
				plant = (GameObject)Instantiate (arbre1, anchorPosi, anchor.transform.rotation, anchor.transform);
				level = 2;
				break;
			case 2:
				Destroy (plant);
				plant = (GameObject)Instantiate (arbre2, anchorPosi, anchor.transform.rotation, anchor.transform);
				level = 3;
				break;
			case 3:
				Destroy (plant);
				plant = (GameObject)Instantiate (arbre3, anchorPosi, anchor.transform.rotation, anchor.transform);
				level = 4;
				break;
			case 4:
				Destroy (plant);
				//Spawn patates
				level = 0;
				typePlante = "";
				break;
			}
		}

	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player") {
			playerIn = true;
		}
	}

	void OnTriggerExit (Collider other)
	{
		if (other.tag == "Player") {
			playerIn = false;
		}
	}
}
