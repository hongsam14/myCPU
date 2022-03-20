using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Input : Data
{
    public Data input_Data = null;

    Wire in_wire = null;
    int in_wire_index = 0;

    private bool click = false;
    private bool data = false;
    
    private void OnMouseDown()
    {
        click = true;
    }

    protected override void Awake()
    {
        base.Awake();
        if (input_Data)
            in_wire = input_Data.GetComponent<Wire>();
    }

    protected override void Start()
    {
        base.Start();
        Bit = false;
        if (in_wire)
            in_wire_index = in_wire.Init();
    }

    private void Update()
    {
        if (in_wire)
            in_wire.DrawLine(in_wire_index, input_Data.transform.position, transform.position);
    }

    private void FixedUpdate()
    {
        if (input_Data)
            Bit = input_Data.Bit;
        else
            Bit = data;
        if (click)
        {
            data = !data;
            click = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (input_Data)
            Gizmos.DrawLine(input_Data.transform.position, transform.position);
    }
}
