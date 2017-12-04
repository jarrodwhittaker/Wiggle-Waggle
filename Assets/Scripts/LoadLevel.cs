using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    public void StartMenu()
    {
        SceneManager.LoadScene("Test");
        Debug.Log("Is CLicked");
    }

    public void SecondLevel()
    {
        SceneManager.LoadScene("FireStarter");
        Debug.Log("Loading");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
