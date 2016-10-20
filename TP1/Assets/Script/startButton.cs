using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class startButton : MonoBehaviour
{

	public void startTheGame ()
	{
		SceneManager.LoadScene ("alpha");
	}
		
}