using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Input : Data
{
    private bool click = false;
    private bool data = false;
    
    private void OnMouseDown()
    {
        click = true;
    }

    protected override void Start()
    {
        base.Start();
        Bit = false;
    }

    private void FixedUpdate()
    {
        Bit = data;
        if (click)
        {
            data = !data;
            click = false;
        }
    }
}
