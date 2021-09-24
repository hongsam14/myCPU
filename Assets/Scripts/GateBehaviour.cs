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
    protected InPort[] in_port;
    [SerializeField]
    protected OutPort[] out_port;
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
