using UnityEngine;
using System.Collections;

public class EscapeMenu : MonoBehaviour {

	public GameObject menu; // Assign in inspector
	private bool isActive;

	void FixedUpdate() {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			isActive = !isActive;
			menu.SetActive(isActive);
		}
	}

	public void resumeGame(){
		isActive = !isActive;
		menu.SetActive(isActive);
	}
}