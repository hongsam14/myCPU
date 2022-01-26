using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Types;

[CreateAssetMenuAttribute(fileName="New Gate Data", menuName="MyCPU Data/Gate")]
public class GateData : ScriptableObject
{
    public GameObject notObject;
    public GameObject orObject;
    public GameObject andObject;
    public GameObject xorObject;
}
