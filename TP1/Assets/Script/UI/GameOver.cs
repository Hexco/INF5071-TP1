using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	public GameObject gameOverPanel;
	public GameObject ui;

	void FixedUpdate () {
		if (Hunger.currentHP <= 0.0f) {
			ui.SetActive (false);
			gameOverPanel.SetActive (true);
		}
	}
}
