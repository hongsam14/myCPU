using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Types;

public class Gate : MonoBehaviour
{
    public GameObject[] inputs = null;

    public int inPortCount
    {
        get => inputs.Length;
        set
	    {
            if (inputs == null)
                inputs = new GameObject[value];
            else
	        {
                GameObject[] tmp = new GameObject[value];
                for(int i = 0; i < inputs.Length && i < value; i++)
		        {
                    tmp[i] = inputs[i];
		        }
                inputs = tmp;
	        }
	    }
    }
    public int outPortCount = 0;
    
    private BitArray outBit { get; set; }
    private BitArray[] inBit;
    
    private GateType gateType { get; set; }
    
    // Start is called before the first frame update
    private void Start()
    {
        //initialize inBit;
        inBit = new BitArray[inputs.Length];
    }
    
    private void FixedUpdate()
    {
        for (int i = 0; i < inputs.Length; i++)
	    {
            if (inputs[i] != null)
                inBit[i] = inputs[i].GetComponent<Gate>().outBit;
	    }
        outBit = gateAction(inBit);
    }

    private BitArray gateAction(BitArray[] data)
    {
        switch (gateType)
	    {
            case GateType.And:
                {
                    int i = 0, j = i + 1;

                    for (; j < data.Length; i++, j++)
                    {
                        data[j] = data[i].And(data[j]);
                    }
                    return data[j];
                }
            case GateType.Or:
                {
                    int i = 0, j = i + 1;

                    for (; j < data.Length; i++, j++)
                    {
                        data[j] = data[i].Or(data[j]);
                    }
                    return data[j];
                }
            case GateType.Not:
                if (data.Length == 1)
                    return data[0].Not();
                //error
                Debug.Log("too many input datas in converter");
                break;
            case GateType.Xor:
                {
                    int i = 0, j = i + 1;

                    for (; j < data.Length; i++, j++)
                    {
                        data[j] = data[i].Xor(data[j]);
                    }
                    return data[j];
                }
            default:
                break;
	    }
        return null;
    }
}
