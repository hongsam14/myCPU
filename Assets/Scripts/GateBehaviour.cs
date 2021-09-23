using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class GateBehaviour : MonoBehaviour
{
    /// <summary>
    /// Gate 오브젝트의 동작을 구현한 클래스.
    /// </summary>
    [SerializeField]
    protected InPort[] in_port;
    [SerializeField]
    protected OutPort[] out_port;

    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        spriteRenderer = transform.GetComponent<SpriteRenderer>();
        InvokeRepeating("Runtime", 1f, 1f);
    }

    protected virtual void Runtime()
    {
    }

    protected void Switch_Color(bool bit)
    {
        switch (bit)
        {
            case true:
                spriteRenderer.color = Color.yellow;
                break;
            case false:
                spriteRenderer.color = Color.grey;
                break;
        }
    }
}
