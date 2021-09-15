using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InPort : MonoBehaviour
{
    public bool bit
    {
        get;
        private set;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        OutPort contect = collision.GetComponent<OutPort>();
        this.bit = contect.bit;
    }
}
