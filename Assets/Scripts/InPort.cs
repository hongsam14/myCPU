using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class InPort:MonoBehaviour
{
    public bool bit;
    private OutPort contect;
    private bool connect = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!contect)
            contect = collision.GetComponent<OutPort>();
        if (!connect)
            connect = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        connect = false;
        contect = null;
    }

    private void Start()
    {
        InvokeRepeating("Runtime", 1f, 1f);
    }

    private void Runtime()
    {
        if (connect)
            bit = contect.bit;
    }
}
