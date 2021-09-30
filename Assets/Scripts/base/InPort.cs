using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(BoxCollider2D))]

public class InPort : MonoBehaviour, IPointerClickHandler
{
    private bool val = false;
    private OutPort contect;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        contect = collision.GetComponent<OutPort>();
        Debug.Log("contect");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        contect = null;
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        Debug.Log("click");
        val = !val;
    }
}
