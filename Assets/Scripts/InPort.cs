using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class InPort:MonoBehaviour
{
    public bool bit;
    private OutPort contect;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!contect)
            contect = collision.GetComponent<OutPort>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        contect = null;
        bit = false;
    }

    private void Start()
    {
        InvokeRepeating("Runtime", 1f, 1f);
    }

    private void Runtime()
    {
        if (contect)
            bit = contect.bit;
    }
}
