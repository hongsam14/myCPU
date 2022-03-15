using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{
    public GameObject wireObject;
    private List<LineRenderer> wires;

    // Start is called before the first frame update
    void Awake()
    {
        wires = new List<LineRenderer>();
    }

    public void DrawLine(int index, Vector3 from, Vector3 to)
    {
        LineRenderer lineRenderer = wires[index];

        lineRenderer.positionCount = 4;
        lineRenderer.SetPosition(0, from);

        lineRenderer.SetPosition(1, new Vector3(from.x + (to.x - from.x) / 2, from.y));
        lineRenderer.SetPosition(2, new Vector3(from.x + (to.x - from.x) / 2, to.y));

        lineRenderer.SetPosition(3, to);
    }

    public int Init()
    {
        GameObject inst = Instantiate(wireObject, transform.position, Quaternion.identity) as GameObject;
        inst.transform.parent = transform;

        wires.Add(inst.GetComponent<LineRenderer>());
        if (wires.Count > 0)
            return wires.Count - 1;
        return wires.Count;
    }

    public void ChangeColor(Color color)
    {
        for (int i = 0; i < wires.Count; i++)
        {
            wires[i].startColor = color;
            wires[i].endColor = color;
        }
    }
}
