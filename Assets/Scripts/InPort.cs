using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(BoxCollider2D))]

public class InPort : MonoBehaviour, IPointerClickHandler
{
    private bool val = false;
    public OutPort contect;
    public bool bit
    {
        get
        {
            if (!contect)
                return val;
            return contect.bit;
        }
        set
        {
            val = value;
        }
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        Debug.Log("click");
        val = !val;
    }
}
