using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Types;

[RequireComponent(typeof(GateControler))]
public class Gate : MonoBehaviour
{
    private GateType gateType { get; set; }
    GateControler gateControler;
    
    // Start is called before the first frame update
    private void Start()
    {
        gateControler = gameObject.GetComponent<GateControler>();
    }
    
    private void FixedUpdate()
    {
        
    }

    private BitArray gateAction(params BitArray[] data)
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
