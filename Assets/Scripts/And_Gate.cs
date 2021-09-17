using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class And_Gate : GateBehaviour
{
    public bool bit_a { private get; set; } = false;
    public bool bit_b { private get; set; } = false;
    public bool output => bit_a & bit_b;

    private SpriteRenderer spriteRenderer;

    protected override void Start()
    {
        base.Start();
        spriteRenderer = transform.GetComponent<SpriteRenderer>();
    }

    protected override void Runtime()
    {
        bool tmp;

        base.Runtime();
        this.bit_a = base.in_port[0].bit;
        this.bit_b = base.in_port[1].bit;
        tmp = this.output;

        base.out_port[0].bit = tmp;
        Switch_Color(tmp);
    }
}
