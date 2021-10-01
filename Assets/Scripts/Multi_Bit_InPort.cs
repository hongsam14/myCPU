using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Multi_Bit_InPort : MonoBehaviour
{
    public string bitStr;
    private BitArray val;
    public BitArray bit
    {
        get => val;
        set
        {
            for (int i = 0; i < 8; i++)
            {
                outPort[i].bit = value.Get(i);
            }
            val = value;
        }
    }

    private Multi_Bit_OutPort contect = null;
    private OutPort[] outPort;

    private void Start()
    {
        outPort = new OutPort[8];
        for (int i = 0; i < 8; i++)
        {
            outPort[i] = transform.parent.GetChild(1 + i).GetComponentInChildren<OutPort>();
        }
        if (bitStr != null)
        {
            bit = new BitArray(bitStr.Select(c => c == '1').ToArray());
        }
        Debug.Log(bit.ToString());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        contect = collision.GetComponent<Multi_Bit_OutPort>();
        Debug.Log("contect");
        bit = contect.bit;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        contect = null;
        bit.SetAll(false);
        val.SetAll(false);
    }
}
