using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class And_Gate : GateBehaviour
{
    public bool output(bool a, bool b) => a & b;

    protected override void Runtime()
    {
        base.out_port[0].bit = output(base.in_port[0].bit, base.in_port[1].bit);
        Switch_Color(out_port[0].bit);
        base.Runtime();
    }

    private void Switch_Color(bool bit)
    {
        switch (bit)
        {
            case true:
                base.color = Color.yellow;
                break;
            case false:
                base.color = Color.grey;
                break;
        }
    }
}
