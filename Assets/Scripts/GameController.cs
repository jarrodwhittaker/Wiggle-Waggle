using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public static GameController Instance;

    public float timeLeft;
    public Text gameTimer;
    public GameObject gameOver;
    public Text winText;
    public float startTime;
    public Text firstTimer;

    public bool isStart;


    void Awake()
    {
        Instance = this;
    }
    // Use this for initialization
    // When the game starts all UI is enabled/disabled correctly
    // The timer before initial countdown begins
    void Start () {
       // firstTimer.SetActive(true);
        firstTimer.enabled = true;
        gameOver.SetActive(false);
        winText.enabled = false;
        //gameTimer.SetActive(false);
        gameTimer.enabled = false;
        timeLeft = 10.0f;
        startTime = 4.0f;

        isStart = true;
	}
	
	// Update is called once per frame
	void Update () {

        startTime -= Time.deltaTime;
        firstTimer.text = "" + Mathf.Round(startTime);

        if (startTime <= 4)
        {
            firstTimer.text = "3";
        }

        if (startTime <= 3)
        {
            firstTimer.text = "2";
        }

        if (startTime <= 2)
        {
            firstTimer.text = "1";
        }

        if (startTime <= 1)
        {
            firstTimer.text = "Go!";
        }

        if (startTime <= 0)
        {
            //firstTimer.SetActive(false);
            firstTimer.enabled = false;
            //gameTimer.SetActive(true);
            gameTimer.enabled = true;
            timeLeft -= Time.deltaTime;
            gameTimer.text = "" + Mathf.Round(timeLeft);
            isStart = false;
        }

        if (timeLeft < 0)
        {
            gameTimer.enabled = false;
            gameOver.SetActive(true);
            winText.enabled = true;
            Time.timeScale = 0;
            int n1 = SpawnManager.physics1.nodes.Count;
            int n2 = SpawnManager.physics2.nodes.Count;
            if(n1>n2)
            {
                //player 1 won
                winText.text = "Player 1 Wins by " + (n1 - n2) + " Playdoughs";
            }
            else if(n1<n2)
            {
                //player 2 won
                winText.text = "Player 2 Wins by " + (n2 - n1) + " Playdoughs";
            }
            else
            {
                winText.text = "Tie with length "+n1;
            }
            
        }
	}
}
