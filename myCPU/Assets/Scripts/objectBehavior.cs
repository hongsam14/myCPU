using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class objectBehavior : MonoBehaviour
{
    public string _name = "gate";

    // Start is called before the first frame update
    public virtual void Start()
    {
        //init gate name.
        Text    txt_field = gameObject.GetComponentInChildren<Text>();
        txt_field.text = _name;
    }
}
