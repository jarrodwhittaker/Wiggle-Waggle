﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerletPhysics : MonoBehaviour {

    [System.Serializable]
    public class Node
    {
        public Vector3 currentPosition;
        public Vector3 lastPosition;
        public bool isFrozen;
    }

    // Use this for initialization
    [SerializeField]

    public int numberOfNodes;
    public List<Node> nodes = new List<Node>();

    public float dampen;
    public float distance;

    public LineRenderer rope;

    public Vector3 acceleration;
    public float spin;
    public int id = 0;


    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < numberOfNodes; i++)
        {
            nodes.Add(new Node());
            nodes[i].currentPosition = transform.position + Vector3.down  /** numberOfNodes*/ * i;
            nodes[i].lastPosition = transform.position + Vector3.down /** numberOfNodes*/ * i;
        }

        rope = this.gameObject.GetComponent<LineRenderer>();

        nodes[0].isFrozen = true;

        rope.positionCount = nodes.Count;

        for (int j = 0; j < 100; ++j)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                if (i != 0)
                {
                    if (i == 1)
                        Restraint(nodes[i], nodes[i - 1], 1.0f, 0.0f);
                    else
                        Restraint(nodes[i], nodes[i - 1], 0.5f, 0.5f);
                }
            }
        }
        Verlet(acceleration);
    }

    void FixedUpdate()
    {
        if (GameController.Instance.isStart == true)
        {
            return;
        }
        spin = (id == 0 ? arduino.gx1 : arduino.gx2);
        if (Mathf.Abs(spin) < 100)
        {
            spin = 0;
        }
        spin *= 0.01f;
        if (Input.GetKeyDown(KeyCode.E))
        {
            spin += 100;
        }

        spin *= 0.9f;
        nodes[3].currentPosition += new Vector3(Random.Range(-1.0f, 1.0f) * spin*0.001f, 0, 0);
        if (spin > 100)
        {
            Node temp = new Node();
            temp.currentPosition = nodes[nodes.Count - 1].currentPosition + Vector3.down;
            temp.lastPosition = temp.currentPosition;
            nodes.Add(temp);
            rope.positionCount = nodes.Count;
            
        }
        for (int j = 0; j < 100; ++j)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                if (i != 0)
                {
                    if (i == 1)
                        Restraint(nodes[i], nodes[i - 1], 1.0f, 0.0f);
                    else
                        Restraint(nodes[i], nodes[i - 1], 0.5f, 0.5f);
                }
            }
        }
        Verlet(acceleration);
    }

    void Restraint(Node node1, Node node2, float c1, float c2)
    {
        float differenceBetweenX = node1.currentPosition.x - node2.currentPosition.x;
        float differenceBetweenY = node1.currentPosition.y - node2.currentPosition.y;
        float differenceBetweenZ = node1.currentPosition.z - node2.currentPosition.z;

        Vector3 direction = (node1.currentPosition - node2.currentPosition).normalized;

        float distanceBetween = Vector3.Distance(node1.currentPosition, node2.currentPosition);
        float difference = ((distance - distanceBetween) / distanceBetween);

        float translateNodeX = differenceBetweenX * difference;
        float translateNodeY = differenceBetweenY * difference;
        float translateNodeZ = differenceBetweenZ * difference;

        node1.currentPosition = new Vector3(node1.currentPosition.x + translateNodeX * c1, node1.currentPosition.y + translateNodeY * c1, node1.currentPosition.z + translateNodeZ * c1);
        node2.currentPosition = new Vector3(node2.currentPosition.x - translateNodeX * c2, node2.currentPosition.y - translateNodeY * c2, node2.currentPosition.z - translateNodeZ * c2);
    }

    void Verlet(Vector3 ropeAcceleration)
    {
        for (int i = 0; i < nodes.Count; i++)
        {
            if (!nodes[i].isFrozen)
            {
                Node currentNode = nodes[i];

                Vector3 currentVelocity = (currentNode.currentPosition - currentNode.lastPosition) * dampen;

                currentNode.lastPosition = currentNode.currentPosition;
                currentNode.currentPosition += (currentVelocity + ropeAcceleration * (Time.fixedDeltaTime * Time.fixedDeltaTime));
            }
            rope.SetPosition(i, nodes[i].currentPosition);
            
        }
    }
}
