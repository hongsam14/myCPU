using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Not_Gate : GateBehavior
{
    public bool bit { private get; set; }
    public bool output => !bit;

    protected override void Runtime()
    {
        base.Runtime();
        this.bit = port[0].data;
        base.data = this.output;
    }
}
