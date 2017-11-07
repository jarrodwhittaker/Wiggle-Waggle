using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeManager : MonoBehaviour {

    public float distance;

    public GameObject nodePrefab;
    public GameObject currentNode;
    public GameObject lastNode;

    public Mesh nodeMesh;

    Vector3 mousePos;
    Vector3 currentMousePos;

	// Use this for initialization
	void Start ()
    {



        nodePrefab = GameObject.FindGameObjectWithTag("Node");

        mousePos = Input.mousePosition;

        Vector3 distance = Vector3.Scale(transform.localScale, nodeMesh.bounds.size);


        currentNode = gameObject;
        lastNode = currentNode;

    }

    // Update is called once per frame
    void Update ()
    {
        currentNode = this.gameObject;

        currentMousePos = Input.mousePosition;



        if (/*mousePos.x > currentMousePos.x + 2 || mousePos.x < currentMousePos.x - 2*/ Input.GetKeyDown(KeyCode.Alpha1))
        {

            Vector3 SpawnPoint = currentNode.transform.position - lastNode.transform.position;
            SpawnPoint.Normalize();
            SpawnPoint *= distance;

            currentNode = Instantiate(nodePrefab, SpawnPoint, Quaternion.identity);

            lastNode.GetComponent<HingeJoint>().connectedBody = currentNode.GetComponent<Rigidbody>();

            lastNode = currentNode;
        }

	}


}
