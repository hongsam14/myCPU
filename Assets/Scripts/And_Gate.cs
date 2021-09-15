using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class And_Gate:GateBehavior
{
    public bool bit_a { private get; set; }
    public bool bit_b { private get; set; }
    public bool output => bit_a & bit_b;

    protected override void Start()
    {
        base.data_num = 1;
        base.Start();
    }

    protected override void Runtime()
    {
        this.bit_a = base.in_port[0].bit;
        this.bit_b = base.in_port[1].bit;
        base[0] = this.output;
        base.Runtime();
    }
}
