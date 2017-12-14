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
    private string sceneName;
    bool firePlayer1Won;
    bool firePlayer2Won;
    bool first;
    public float player1Total = 0;
    public float player2Total = 0;
    public float player1Time = 0;
    public float player2Time = 0;

    void Awake()
    {
        Instance = this;
    }
    // Use this for initialization
    // When the game starts all UI is enabled/disabled correctly
    // The timer before initial countdown begins
    void Start () {
        //Scene currentScene = SceneManager.GetActiveScene();
        //sceneName = currentScene.name;
        // firstTimer.SetActive(true);
        firstTimer.enabled = true;
        gameOver.SetActive(false);
        winText.enabled = false;
        //gameTimer.SetActive(false);
        gameTimer.enabled = false;
        timeLeft = 10.0f;
        startTime = 4.0f;
        firePlayer1Won = false;
        firePlayer2Won = false;
        first = true;
        isStart = true;
        sceneName = "";
        player1Total = 0;
        player2Total = 0;
        player1Time = 0;
        player2Time= 0;

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
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        Debug.Log("Scene-------"+sceneName);
        if (SceneManager.GetActiveScene().name == "FireStarter")
        {
            player1Total += Mathf.Abs(arduino.gx1);
            player1Total *= 0.9f;
            player2Total += Mathf.Abs(arduino.gx2);
            player2Total *= 0.9f;
            if (player1Total > 200000)
            {
                player1Time += Time.deltaTime;
            }
            if (player2Total > 200000)
            {
                player2Time += Time.deltaTime;
            }
            if(player1Time>3.0f)
            { 
            //Spawn particles for p1
                firePlayer1Won = true;
                gameTimer.enabled = false;
                gameOver.SetActive(true);
                winText.enabled = true;
                Time.timeScale = 0;
                winText.text = "Player 1 Wins!";
            }
            else
            if (player2Time > 3.0f)
            {
                //Spawn particles for p1
                firePlayer2Won = true;
                gameTimer.enabled = false;
                gameOver.SetActive(true);
                winText.enabled = true;
                Time.timeScale = 0;
                winText.text = "Player 2 Wins!";
            }
        }
        if (timeLeft < 0)
        {
            if (SceneManager.GetActiveScene().name == "Test") {
                gameTimer.enabled = false;
                gameOver.SetActive(true);
                winText.enabled = true;
                Time.timeScale = 0;


                int n1 = SpawnManager.physics1.nodes.Count;
                int n2 = SpawnManager.physics2.nodes.Count;
                if (n1 > n2)
                {
                    //player 1 won
                    winText.text = "Player 1 Wins by " + (n1 - n2) + " Playdoughs";
                }
                else if (n1 < n2)
                {
                    //player 2 won
                    winText.text = "Player 2 Wins by " + (n2 - n1) + " Playdoughs";
                }
                else
                {
                    winText.text = "Tie with length " + n1;
                }
            }
            else if (sceneName == "FireStarter")
            {
                if (!firePlayer1Won && !firePlayer2Won)
                {
                    gameTimer.enabled = false;
                    gameOver.SetActive(true);
                    winText.enabled = true;
                    Time.timeScale = 0;
                    winText.text = "Nobody Wins!";
                }
            }
        }
	}
}
