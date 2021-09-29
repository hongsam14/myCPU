using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class And_Gate : GateBehaviour
{
    protected override void Runtime()
    {
        base.Runtime();
        bool value = input_val(0) & input_val(1);
        output_val(0, value);
        Switch_Color(value);
    }

    private void Switch_Color(bool bit)
    {
        switch (bit)
        {
            case true:
                color = Color.yellow;
                break;
            case false:
                color = Color.grey;
                break;
        }
    }
}
