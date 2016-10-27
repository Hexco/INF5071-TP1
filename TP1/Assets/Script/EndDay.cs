using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndDay : MonoBehaviour {

	public Text actionText1;
	public int delay;

	private bool playerIn;
	private float delayed;
	private PlayerCloseTrigger playerCloseTrigger;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > delayed && playerIn && Input.GetKey ("j")) {
			var pots = GameObject.FindGameObjectsWithTag("PlantPotTrigger");
			foreach (var pot in pots) {
				playerCloseTrigger = pot.GetComponent<PlayerCloseTrigger>();
				Debug.Log (playerCloseTrigger);
				playerCloseTrigger.EndDay ();
			}
			delayed = Time.time + delay;
		}
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

	void SetActionText(){
			actionText1.text = "Press J to end day";
	}

	void ReSetActionText(){
		actionText1.text = "";
	}
}
