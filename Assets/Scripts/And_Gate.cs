using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class And_Gate : GateBehaviour
{
    private bool bit_a = false;
    private bool bit_b = false;
    public bool output => bit_a & bit_b;

    protected override void Runtime()
    {
        base.Runtime();
        bit_a = base.in_port[0].bit;
        bit_b = base.in_port[1].bit;
        base.out_port[0].bit = output;
        Switch_Color(output);
    }
}
