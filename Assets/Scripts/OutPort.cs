using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WireBehaviour))]

public class OutPort : MonoBehaviour
{
    private bool val;
    public bool bit
    {
        get => val;
        set
        {
            switch (value)
            {
                case true:
                    wireBehaviour.color = Color.yellow;
                    break;
                case false:
                    wireBehaviour.color = Color.gray;
                    break;
            }
            val = value;
        }
    }

    private WireBehaviour wireBehaviour;

    private void Start()
    {
        wireBehaviour = transform.GetComponent<WireBehaviour>();
    }
}
