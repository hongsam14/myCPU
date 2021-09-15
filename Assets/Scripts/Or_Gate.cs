using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Or_Gate:GateBehavior
{
    public bool bit_a { private get; set; }
    public bool bit_b { private get; set; }
    public bool output => bit_a | bit_b;
}
