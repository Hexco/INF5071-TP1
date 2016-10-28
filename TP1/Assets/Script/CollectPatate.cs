using UnityEngine;
using System.Collections;

public class CollectPatate : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			//TODO Ajout patate to inventory
			Destroy (this.gameObject);
		}
	}
}
