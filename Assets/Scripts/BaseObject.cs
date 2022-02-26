using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BaseModel;

public class BaseObject : MonoBehaviour
{
    /*
    public List<Port> Inputs { get; private set; }
    public List<Port> Sels { get; private set; }
    public List<Port> Outputs { get; private set; }
    */
    public List<Port> Inputs;
    public List<Port> Sels;
    public List<Port> Outputs;

    public int InputSize
    {
        get
        {
            if (Inputs == null)
                Inputs = new List<Port>();
            return Inputs.Count;
        }
        set
        {
            if (value > Inputs.Count)
            {
                for (int i = Inputs.Count; i < value; i++)
                {
                    Inputs.Add(new Port(i, Port.Dir.enter));
                }
            }
            else if (value < Inputs.Count)
            {
                Inputs.RemoveRange(value, Inputs.Count - value);
            }
        }
    }
    
    public int SelSize
    {
        get
        {
            if (Sels == null)
                Sels = new List<Port>();
            return Sels.Count;
        }
        set
        {
            if (value > Sels.Count)
            {
                for (int i = Sels.Count; i < value; i++)
                {
                    Inputs.Add(new Port(i, Port.Dir.sel));
                }
            }
            else if (value < Sels.Count)
            {
                Inputs.RemoveRange(value, Sels.Count - value);
            }
        }
    }
    
    public int OutputSize
    {
        get
        {
            if (Outputs == null)
                Outputs = new List<Port>();
            return Outputs.Count;
        }
        set
        {
            if (value > Outputs.Count)
            {
                for (int i = Outputs.Count; i < value; i++)
                {
                    Outputs.Add(new Port(i, Port.Dir.exit));
                }
            }
            else if (value < Outputs.Count)
            {
                Outputs.RemoveRange(value, Outputs.Count - value);
            }
        }
    }

    protected bool[] inputBit;
    protected bool[] selBit;
    protected bool[] outputBit;

    protected virtual void Start()
    {
        inputBit = new bool[Inputs.Count];
        selBit = new bool[Sels.Count];
        outputBit = new bool[Outputs.Count];
    }

    void FixedUpdate()
    {
        for (int i = 0; i < InputSize; i++)
        {
            Inputs[i].Update();
            inputBit[i] = Inputs[i].Bit;
        }
        for (int i = 0; i < SelSize; i++)
        {
            Sels[i].Update();
            selBit[i] = Sels[i].Bit;
        }
        Function();
        for (int i = 0; i < OutputSize; i++)
        {
            Outputs[i].Bit = outputBit[i];
            Outputs[i].Update();
        }
    }

    protected virtual void Function()
    {
    }
}
