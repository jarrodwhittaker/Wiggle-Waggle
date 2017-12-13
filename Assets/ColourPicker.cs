using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourPicker : MonoBehaviour {

    Colour myMaterial;
    public LineRenderer rend;

    void Awake()
    {
        rend = this.gameObject.GetComponent<LineRenderer>();
        myMaterial = GetComponent<Colour>();
    }

	// Use this for initialization
	void Start ()
    {
        rend.material = myMaterial.colour;
	}
}
