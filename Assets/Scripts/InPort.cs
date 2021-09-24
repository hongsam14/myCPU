using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(BoxCollider2D))]

public class InPort : MonoBehaviour, IPointerClickHandler
{
    public bool bit;
    private OutPort contect;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!contect)
            contect = collision.GetComponent<OutPort>();
        bit = contect.bit;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        contect = null;
        bit = false;
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        Debug.Log("click");
        bit = !bit;
    }
}
