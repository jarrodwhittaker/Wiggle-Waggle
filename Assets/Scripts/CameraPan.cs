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

        var distBetween = (player1Script.nodes[player1Script.nodes.Count - 1].currentPosition - player2Script.nodes[player2Script.nodes.Count - 1].currentPosition).magnitude;
        Debug.Log(midPlayers + " | " + midNodes + " | " + midPoint);
        

        Vector3 minPoint = new Vector3(10000, 10000, 10000);
        Vector3 maxPoint = new Vector3(-10000, -10000, -10000);
        for(int i = player1Script.nodes.Count-1; i< player1Script.nodes.Count;++i)
        {
            if (player1Script.nodes[i].currentPosition.x < minPoint.x)
                minPoint.x = player1Script.nodes[i].currentPosition.x;
            if (player1Script.nodes[i].currentPosition.y < minPoint.y)
                minPoint.y = player1Script.nodes[i].currentPosition.y;
            if (player1Script.nodes[i].currentPosition.z < minPoint.z)
                minPoint.z = player1Script.nodes[i].currentPosition.z;
            if (player1Script.nodes[i].currentPosition.x > maxPoint.x)
                maxPoint.x = player1Script.nodes[i].currentPosition.x;
            if (player1Script.nodes[i].currentPosition.y > maxPoint.y)
                maxPoint.y = player1Script.nodes[i].currentPosition.y;
            if (player1Script.nodes[i].currentPosition.z > maxPoint.z)
                maxPoint.z = player1Script.nodes[i].currentPosition.z;
        }
        for (int i = player2Script.nodes.Count-1; i < player2Script.nodes.Count; ++i)
        {
            if (player2Script.nodes[i].currentPosition.x < minPoint.x)
                minPoint.x = player2Script.nodes[i].currentPosition.x;
            if (player2Script.nodes[i].currentPosition.y < minPoint.y)
                minPoint.y = player2Script.nodes[i].currentPosition.y;
            if (player2Script.nodes[i].currentPosition.z < minPoint.z)
                minPoint.z = player2Script.nodes[i].currentPosition.z;
            if (player2Script.nodes[i].currentPosition.x > maxPoint.x)
                maxPoint.x = player2Script.nodes[i].currentPosition.x;
            if (player2Script.nodes[i].currentPosition.y > maxPoint.y)
                maxPoint.y = player2Script.nodes[i].currentPosition.y;
            if (player2Script.nodes[i].currentPosition.z > maxPoint.z)
                maxPoint.z = player2Script.nodes[i].currentPosition.z;
        }

        
      //  Camera.main.transform.position = new Vector3(midNodes.x, midNodes.y, -player1Script.nodes.Count - distBetween);
      Camera.main.transform.position = new Vector3(midNodes.x, midNodes.y, -(maxPoint.y - minPoint.y)-15.0f);
    }
}
