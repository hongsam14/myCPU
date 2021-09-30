using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class GateBehaviour : MonoBehaviour
{
    /// <summary>
    /// Gate 오브젝트의 동작을 구현한 클래스.
    /// </summary>
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private InPort[] in_port;
    [SerializeField]
    private OutPort[] out_port;
    protected bool input_val(int idx) => in_port[idx].bit;
    protected bool output_val(int idx, bool val) => out_port[idx].bit = val;

    protected Color color
    {
        get => spriteRenderer.color;
        set
        {
            spriteRenderer.color = value;
        }
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        spriteRenderer = transform.GetComponent<SpriteRenderer>();
        InvokeRepeating("Runtime", 1f, 1f);
    }

    protected virtual void Runtime()
    {
    }
}
