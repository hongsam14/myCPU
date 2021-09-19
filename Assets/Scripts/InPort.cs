using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class InPort:MonoBehaviour
{
    public bool bit;

    private void OnTriggerStay2D(Collider2D collision)
    {
        OutPort contect = collision.GetComponent<OutPort>();
        this.bit = contect.bit;
    }
}
