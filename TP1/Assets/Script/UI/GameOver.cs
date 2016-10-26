using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	public GameObject gameOverPanel;

	void FixedUpdate () {
		if (Hunger.currentHP <= 0.0f) {
			gameOverPanel.SetActive (true);
		}
	}
}
