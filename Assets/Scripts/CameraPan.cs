using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPan : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    VerletPhysics player1Script;
    VerletPhysics player2Script;

    // Use this for initialization
    void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");
        player1Script = player1.GetComponent<VerletPhysics>();
        player2Script = player2.GetComponent<VerletPhysics>();
    }

    // Update is called once per frame
    void Update()
    {
        FollowMidPoint();
    }

    void FollowMidPoint()
    {

        Vector3 midPlayers = (player1.transform.position - player2.transform.position) * 0.5f + player2.transform.position;
        Vector3 midNodes = (player1Script.nodes[player1Script.nodes.Count - 1].currentPosition - player2Script.nodes[player2Script.nodes.Count - 1].currentPosition) *0.5f + player2Script.nodes[player2Script.nodes.Count - 1].currentPosition;
        Vector3 midPoint = (midPlayers - midNodes) * 0.5f + midNodes;

        Debug.Log(midPlayers + " | " + midNodes + " | " + midPoint);
        Camera.main.transform.position = new Vector3(midNodes.x, midNodes.y, -player1Script.nodes.Count - 3);
    }
}
