using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mAnd_Gate : GateBehavior
{
    public BitArray bus_a { private get; set; }
    public BitArray bus_b { private get; set; }
    public BitArray output => and_func(bus_a, bus_b);

    private BitArray outbit = new BitArray(Setting.bit);

    private BitArray and_func(BitArray a, BitArray b)
    {
        outbit.SetAll(false);
        for (int i = 0; i < Setting.bit; i++)
        {
            outbit.Set(i, a[i] & b[i]);
        }
        return outbit;
    }
}
