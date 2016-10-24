using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class StartButton : MonoBehaviour
{

	public void startTheGame ()
	{
		SceneManager.LoadScene ("alpha");
	}
		
}