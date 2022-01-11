using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
[ExecuteInEditMode]
public class WireBehaviour : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private Vector3 pos_x = Vector3.zero;
    private Color p_color = Color.white;

    public Transform dest;
    public Color color
    {
        get => lineRenderer.endColor;
        set
        {
            if (value != p_color)
            {
                lineRenderer.startColor = value;
                lineRenderer.endColor = value;
                p_color = value;
            }
        }
    }
    void Awake()
    {
        Debug.Log("awake");
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start");
        lineRenderer = transform.GetComponent<LineRenderer>();
        lineRenderer.positionCount = 4;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        color = Color.gray;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("update");
        if (pos_x != transform.position)
        {
            float x = (dest.position.x + transform.position.x) / 2;
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, new Vector3(x, transform.position.y, 0));
            lineRenderer.SetPosition(2, new Vector3(x, dest.position.y, 0));
            lineRenderer.SetPosition(3, dest.position);
            pos_x = transform.position;
        }
    }
}
