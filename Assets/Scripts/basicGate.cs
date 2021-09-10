using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class And_Gate
{
    public bool input_A { private get; set; }
    public bool input_B { private get; set; }

    public bool output { get { return _and_func(input_A, input_B); } }

    private bool _and_func(bool a, bool b)
    {
        if (a && b)
            return true;
        return false;
    }
}

public class Or_Gate
{
    private bool A;
    private bool B;

    public bool input_A { set { A = value; } }
    public bool input_B { set { B = value; } }
    public bool output { get { return _or_func(A, B); } }

    private bool _or_func(bool a, bool b)
    {
        if (!a && !b)
            return false;
        return true;
    }
}

public class Not_Gate
{
    private bool A;

    public bool input_A { set { input_A = value; } }
    public bool output { get { return _not_func(A); } }

    private bool _not_func(bool a)
    {
        if (a)
            return false;
        return true;
    }
}

public class Multiplexor
{
    private bool A;
    private bool B;
    private bool sel;

    public bool input_A { set { A = value; } }
    public bool input_B { set { B = value; } }
    public bool input_sel { set { sel = value; } }
    public bool output { get { return multiplexor(A, B, sel); } }

    private bool multiplexor(bool a, bool b, bool sel)
    {
        if (sel)
            return b;
        return a;
    }
}

public class Demultiplexor
{
    private bool inp;
    private bool sel;

    public bool input { set { inp = value; } }
    public bool input_sel { set { sel = value; } }
    public bool output_A { get { return demultiplexor(inp, sel).a; } }
    public bool output_b { get { return demultiplexor(inp, sel).b; } }

    public (bool a, bool b) demultiplexor(bool input, bool sel)
    {
        if (sel)
            return (false, input);
        return (input, false);
    }
}