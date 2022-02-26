using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class And_Gate : MonoBehaviour
{
    public Data input_a;
    public Data input_b;

    public Data output;

    Wire out_wire;
    Wire in_a_wire;
    Wire in_b_wire;
    SpriteRenderer spriteRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        out_wire = GetComponent<Wire>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (input_a)
            in_a_wire = input_a.GetComponent<Wire>();
        if (input_b)
            in_b_wire = input_b.GetComponent<Wire>();
    }

    void Update()
    {
        DrawWire();
    }

    private void DrawWire()
    {
        float rightPoint_x = transform.position.x + transform.localScale.x / 2;
        out_wire.DrawLine(new Vector3(rightPoint_x, transform.position.y), output.transform.position);
        float leftPoint_x = transform.position.x - transform.localScale.x / 2;
        if (in_a_wire)
            in_a_wire.DrawLine(input_a.transform.position, new Vector3(leftPoint_x, transform.position.y + transform.localScale.y / 4));
        if (in_b_wire)
            in_b_wire.DrawLine(input_b.transform.position, new Vector3(leftPoint_x, transform.position.y - transform.localScale.y / 4));
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (input_a)
            Gizmos.DrawLine(input_a.transform.position, transform.position);
        if (input_b)
            Gizmos.DrawLine(input_b.transform.position, transform.position);
        if (output)
            Gizmos.DrawLine(output.transform.position, transform.position);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        output.Bit = input_a.Bit & input_b.Bit;
        if (output.Bit == true)
        {
            out_wire.ChangeColor(Color.yellow);
            spriteRenderer.color = Color.yellow;
        }
        else
        {
            out_wire.ChangeColor(Color.gray);
            spriteRenderer.color = Color.gray;
        }
    }
}
