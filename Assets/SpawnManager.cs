using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
    [SerializeField]

    public GameObject player1;
    public GameObject player2;

    public GameObject player1Start;
    public GameObject player2Start;

    // Use this for initialization
    void Start ()
    {
       // player1 = GameObject.FindGameObjectWithTag("Player1");

        player1Start = GameObject.FindGameObjectWithTag("Player1start");
        player2Start = GameObject.FindGameObjectWithTag("Player2start");

        Instantiate(player1, player1Start.transform.position, Quaternion.identity);
        Instantiate(player2, player2Start.transform.position, Quaternion.identity);

    }

    // Update is called once per frame
    void Update () {
		
	}
}
