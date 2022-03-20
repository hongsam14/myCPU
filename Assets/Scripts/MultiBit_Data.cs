using System.Collections;
using System.Collections.Generic;
using Microsoft.Win32.SafeHandles;
using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(Wire))]
public class MultiBit_Data : MonoBehaviour
{
    public MultiBit_Data input_Datas = null;

    public BitArray Bits
    {
        get
        {
            for (int i = 0; i < ports.Length; i++)
            {
                _bits[i] = ports[i].Bit;
            }
            return _bits;
        }
        set
        {
            _bits = value;
            for (int i = 0; i < _bits.Length; i++)
            {
                ports[i].Bit = _bits[i];
            }
        }
    }

    [SerializeField]
    private Data[] ports;

    private BitArray _bits;

    private Wire wire = null;
    private int wire_index = 0;

    void Awake()
    {
        _bits = new BitArray(8);

        if (input_Datas)
            wire = input_Datas.GetComponent<Wire>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (wire)
            wire_index = wire.Init();
    }

    // Update is called once per frame
    void Update()
    {
        DrawWire();
    }

    void DrawWire()
    {
        if (wire)
            wire.DrawLine(wire_index,
                input_Datas.transform.position + Vector3.up,
                    transform.position - Vector3.down);
    }

    void FixedUpdate()
    {
        if (input_Datas)
        {
            bool tmp = false;

            Bits = input_Datas.Bits;
            foreach (bool i in _bits)
            {
                tmp |= i;
            }

            if (!tmp)
                wire.ChangeColor(Color.gray);
            else
                wire.ChangeColor(Color.yellow);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (input_Datas)
            Gizmos.DrawLine(input_Datas.transform.position, transform.position);
    }
}
