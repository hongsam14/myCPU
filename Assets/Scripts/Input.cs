using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Input : Data
{
    private void OnMouseDown()
    {
        Debug.Log("click");
        Bit = !Bit;
    }
}
