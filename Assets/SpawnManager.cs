using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
    [SerializeField]

    private GameObject player1;
    private GameObject player2;

    public GameObject player1Start;

    // Use this for initialization
    void Start ()
    {
       // player1 = GameObject.FindGameObjectWithTag("Player1");

        player1Start = GameObject.FindGameObjectWithTag("Player1start");

        Instantiate(player1, player1Start.transform.position, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
