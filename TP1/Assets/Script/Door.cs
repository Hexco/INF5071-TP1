using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Door : MonoBehaviour
{

	public Text actionText1;
	public GameObject player;
	public GameObject door;
	public float delay;

	private bool playerIn;
	private float delayed;

	// Use this for initialization
	void Start ()
	{
		delayed = 0.0f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Time.time > delayed && playerIn) {
			if (Input.GetKey ("j")) {
				if (this.tag == "DoorIn") {
					player.transform.position += new Vector3 (30, 0, 0);
					delayed = Time.time + delay;
				} else if (this.tag == "DoorOut") {
					player.transform.position += new Vector3 (-30, 0, 0);
					delayed = Time.time + delay;
				}
			}
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
			SetActionText ();
		}
	}

	void SetActionText ()
	{
		if (playerIn) {
			if (door.tag == "DoorIn") {
				actionText1.text = "Press J to get in the dome";
			} else if (door.tag == "DoorOut") {
				actionText1.text = "Press J to get out of the dome";
			}
		} else {
			actionText1.text = "";
		}

	}
}
