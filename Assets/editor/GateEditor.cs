using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(Gate))]
public class GateEditor : Editor
{
    Gate origin;

    public override void OnInspectorGUI()
    {
#if false
        base.OnInspectorGUI();
#else
        serializedObject.Update();
        origin = (Gate)target;
        DrawGateSection();
        serializedObject.ApplyModifiedProperties();
#endif
    }


    /// <summary>
    /// Draw 1 by 2 section on inspector
    /// </summary>
    void DrawGateSection()
    {
        DrawGateHeader();

        origin.gateType = (Types.GateType)EditorGUILayout.EnumPopup(origin.gateType);
        EditorList.Show(serializedObject.FindProperty("inputs"), InputButton);
        EditorList.Show(serializedObject.FindProperty("outputs"), OutputButton);
    }

    void DrawGateHeader()
    {
        GUILayout.Label("Gate Controler", EditorStyles.boldLabel);
        EditorGUILayout.Space();
    }

    void InputButton(SerializedProperty list, int index)
    {
        return;
        if (origin.inputs[index] == null)
        {
            if (GUILayout.Button("connect"))
            {
                ConnectWindow.Connect(origin.gameObject, (newValue) => { origin.inputs[index] = newValue; });
            }
        }
        else
        {
            if (GUILayout.Button("disconnect"))
            {
                origin.inputs[index] = null;
            }
        }
    }

    void OutputButton(SerializedProperty list, int index)
    {
        return;
        if (origin.outputs[index] == null)
        {
            if (GUILayout.Button("connect"))
            {
                ConnectWindow.Connect(origin.gameObject, (newValue) => { origin.outputs[index] = newValue; });
            }
        }
        else
        {
            if (GUILayout.Button("disconnect"))
            {
                origin.outputs[index] = null;
            }
        }
    }
}
