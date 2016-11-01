using UnityEngine;
using System.Collections;

public class Collect : MonoBehaviour {

    public Inventory inventory;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Item")
        {
			AudioSource sound = GameObject.Find ("CollectSound").GetComponent<AudioSource> ();
			sound.Play ();
            inventory.AddItem(other.GetComponent<Item>());
        }
    }
}
