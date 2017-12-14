using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneManger : MonoBehaviour {

    public bool isPause;
    // Use this for initialization
    void Start ()
    {
        isPause = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IsToggle();
        }
    }

    public void Restart()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name, LoadSceneMode.Single);
    }

    public void IsToggle()
    {
        if (isPause)
        {
            SceneManager.UnloadSceneAsync("PauseMenu");
            Time.timeScale = 1;

            isPause = false;
        }
        else if (!isPause)
        {
            SceneManager.LoadSceneAsync("PauseMenu", LoadSceneMode.Additive);
            Time.timeScale = 0;
            isPause = true;
        }
    }
}
