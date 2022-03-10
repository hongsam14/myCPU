using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Wire : MonoBehaviour
{
    LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void DrawLine(Vector3 from, Vector3 to)
    {
        lineRenderer.positionCount = 4;
        lineRenderer.SetPosition(0, from);

        lineRenderer.SetPosition(1, new Vector3(from.x + (to.x - from.x) / 2, from.y));
        lineRenderer.SetPosition(2, new Vector3(from.x + (to.x - from.x) / 2, to.y));

        lineRenderer.SetPosition(3, to);
    }

    public void ChangeColor(Color color)
    {
        lineRenderer.startColor = color;
        lineRenderer.endColor = color;
    }
}
