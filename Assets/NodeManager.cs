using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class NodeManager : MonoBehaviour {

    public float distance;

    public GameObject nodePrefab;
    public GameObject lastNode;

    public Mesh nodeMesh;

    Vector3 mousePos;
    Vector3 currentMousePos;

    public Transform startPoint;

    public Renderer rend;

    void Awake()
    {

    }
    // Use this for initialization
    void Start ()
    {
        rend = nodePrefab.GetComponent<Renderer>();
        Instantiate(nodePrefab, new Vector3(startPoint.transform.position.x, startPoint.transform.position.y, startPoint.transform.position.z), Quaternion.identity);

    }

    // Update is called once per frame
    void Update ()
    {

        if (nodePrefab == null)
        {
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Spawned");
            Instantiate(nodePrefab, new Vector3(lastNode.transform.position.x, lastNode.transform.position.y - rend.bounds.size.y, lastNode.transform.position.z), Quaternion.identity);
        }

        NodeCount();
    }

    void NodeCount()
    {
        List<GameObject> nodes = GameObject.FindGameObjectsWithTag("Node").ToList();

        foreach (GameObject node in nodes)
        {
            
            int numOfNodes = nodes.Count;
            lastNode = nodes[numOfNodes - 1];
        }

    }
}
