using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Wire))]
public class Not_Gate : MonoBehaviour
{
    public Data input = null;
    public Data output = null;

    Wire
        input_wire = null,
        out_wire = null;

    int
        in_wire_index = 0,
        out_wire_index = 0;

    SpriteRenderer spriteRenderer;
     
    // Start is called before the first frame update
    void Start()
    {
        out_wire = GetComponent<Wire>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (input)
            input_wire = input.GetComponent<Wire>();
        if (output)
            out_wire = output.GetComponent<Wire>();

        in_wire_index = input_wire.Init();
        out_wire_index = out_wire.Init();
    }

    // Update is called once per frame
    void Update()
    {
        DrawWire();
    }

    private void DrawWire()
    {
        float rightPoint_x = transform.position.x + transform.localScale.x / 2;
        out_wire.DrawLine(out_wire_index, new Vector3(rightPoint_x, transform.position.y), output.transform.position);
        float leftPoint_x = transform.position.x - transform.localScale.x / 2;
        if (input_wire)
            input_wire.DrawLine(in_wire_index, input.transform.position, new Vector3(leftPoint_x, transform.position.y));
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (input)
            Gizmos.DrawLine(input.transform.position, transform.position);
        if (output)
            Gizmos.DrawLine(output.transform.position, transform.position);
    }

    void FixedUpdate()
    {
        output.Bit = !input.Bit;
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
