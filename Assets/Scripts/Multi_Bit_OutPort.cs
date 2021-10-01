using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(WireBehaviour))]

public class Multi_Bit_OutPort : MonoBehaviour
{
    private BitArray val;
    public BitArray bit
    {
        get => val;
        set
        {
            if (value.Count > 0)
                wireBehaviour.color = Color.yellow;
            else
                wireBehaviour.color = Color.gray;
            val = value;
        }
    }

    private WireBehaviour wireBehaviour;

    private void Start()
    {
        wireBehaviour = transform.GetComponent<WireBehaviour>();
    }
}
