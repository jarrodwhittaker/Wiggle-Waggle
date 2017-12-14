using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
    [SerializeField]
    public static VerletPhysics physics1;
    public static VerletPhysics physics2;
    public GameObject player1;
    public GameObject player2;

    public GameObject player1Start;
    public GameObject player2Start;

    // Use this for initialization
    void Awake()
    {
       // player1 = GameObject.FindGameObjectWithTag("Player1");

        player1Start = GameObject.FindGameObjectWithTag("Player1start");
        player2Start = GameObject.FindGameObjectWithTag("Player2start");

        GameObject gob1 = Instantiate(player1, player1Start.transform.position, Quaternion.identity);
        GameObject gob2 = Instantiate(player2, player2Start.transform.position, Quaternion.identity);
        physics1 = gob1.GetComponent<VerletPhysics>();
        physics2 = gob2.GetComponent<VerletPhysics>();
        physics1.id = 0;
        physics2.id = 1;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
