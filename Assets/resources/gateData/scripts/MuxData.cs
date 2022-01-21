using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Types;

[CreateAssetMenuAttribute(fileName="New Mux Data", menuName="MyCPU Data/Mux")]
public class MuxData : ScriptableObject
{
    public GameObject muxObject;
    public GameObject deMuxObject;
}
