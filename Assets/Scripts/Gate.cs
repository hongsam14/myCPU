using System.Collections;
using UnityEngine;
using Types;

public class Gate : MonoBehaviour
{
    public GameObject[]
        inputs = null,
        outputs = null;
    
    public GateType gateType { get; set; }
    
    private BitArray outBit { get; set; }
    private BitArray[] inBit;
    

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
        outBit = gateAction(inBit, gateType);
    }

    private BitArray gateAction(BitArray[] data, GateType type = GateType.Not)
    {
        switch (type)
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
