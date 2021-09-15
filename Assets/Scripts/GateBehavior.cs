using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateBehavior : MonoBehaviour
{
    /// <summary>
    /// Gate 오브젝트의 동작을 구현한 클래스.
    /// </summary>
    [SerializeField]
    protected InPort[] in_port;
    [SerializeField]
    protected OutPort[] out_port;
    protected int data_num = 1;

    private bool[] data;
    public bool this[int i]
    {
        get => data[i];
        set => this.data[i] = value;
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        data = new bool[data_num];
    }

    private void FixedUpdate()
    {
        Runtime();
    }

    protected virtual void Runtime()
    {
        for (int i = 0; i < data_num; i++)
        {
            out_port[i].bit = this.data[i];
        }
    }
}
