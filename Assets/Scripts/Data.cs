using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Data : MonoBehaviour
{

    private bool _bit;
    private SpriteRenderer spriteRenderer;
    private Wire wire;
    public bool Bit
    {
        get => _bit;
        set
        {
            _bit = value;
            if (_bit == true)
            {
                gameObject.name = "1";
                spriteRenderer.color = Color.yellow;
                wire.ChangeColor(Color.yellow);

            }
            else
            {
                gameObject.name = "0";
                spriteRenderer.color = Color.gray;
                wire.ChangeColor(Color.gray);
            }
        }
    }

    private void Start()
    {
        gameObject.name = "?";
        spriteRenderer = GetComponent<SpriteRenderer>();
        wire = GetComponent<Wire>();
        Bit = false;
    }
}
