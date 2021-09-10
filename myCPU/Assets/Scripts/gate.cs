using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gate : MonoBehaviour
{
    public GameObject[] input_port;
    public GameObject[] output_port;
#if false
    private gateBehaviour[] input_sig;
    private And_Gate
#else

    public gate(string name)
    {
        switch (name)
        {
            case "And":
                And_Gate _gate = new And_Gate();
                break ;
            case "Or":
                Or_Gate _gate = new Or_Gate();
                break;
            case "Not":
                Not_Gate _gate = new Not_Gate();
                break;
            case "Multiplexor":
                And_Gate _gate = new And_Gate();
                break;
            case "Demultiplexor":
                And_Gate _gate = new And_Gate();
                break;
            default:
                Debug.Log("there's no gate.");
                break;
        }
    }
#endif
    // Start is called before the first frame update
    void Start()
    {
#if false
        for (int i = 0; i < input_port.Length; i++)
        {
            input_sig[i] = input_port[i].GetComponent<gateBehaviour>();
        }
#else
        
#endif
    }

    // Update is called once per frame
    void Update()
    {
    }
}
