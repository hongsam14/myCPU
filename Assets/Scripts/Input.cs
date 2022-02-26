using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input : Data
{
    public bool input = false;

    void FixedUpdate()
    {
        Bit = input;
    }
}
