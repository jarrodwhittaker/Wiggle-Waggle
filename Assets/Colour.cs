﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colour : MonoBehaviour {

    public Material colour;

    void ColourSelect(Material mat)
    {
        colour = mat;
    }
}