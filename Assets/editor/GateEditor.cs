using UnityEngine;
using UnityEditor;
using TMPro.EditorUtilities;
using System.Collections;

[CustomEditor(typeof(Gate))]
public class GateEditor : Editor
{
    Gate origin;

    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        serializedObject.Update();
        origin = (Gate)target;
        DrawGateSection();
        serializedObject.ApplyModifiedProperties();
    }


    /// <summary>
    /// Draw 1 by 2 section on inspector
    /// </summary>
    void DrawGateSection()
    {
        DrawGateHeader();

        origin.gateType = (Types.GateType)EditorGUILayout.EnumPopup(origin.gateType);

        EditorGUILayout.BeginHorizontal();
        EditorList.Show(serializedObject.FindProperty("inputs"), null);
        EditorList.Show(serializedObject.FindProperty("outputs"), null);
        EditorGUILayout.EndHorizontal();
    }

    void DrawGateHeader()
    {
        GUILayout.Label("Gate Controler", EditorStyles.boldLabel);
        EditorGUILayout.Space();
    }

    void gateEditorButton(SerializedProperty list, int index)
    {
    }

    delegate void setObjmethod(GameObject to);

    /// <summary>
    /// Open Connected window and wait it closed, get result.
    /// </summary>
    /// <param name="portID">ID that you want to connect.</param>
    /// <returns></returns>
    IEnumerator Connect(setObjmethod setObj)
    {
        int id = ConnectWindow.OpenWindow(origin.gameObject);
        while (ConnectWindow.cache[id].open)
        {
            yield return null;
        }
        //origin.inputs[portID] = ConnectWindow.cache[id].selectedObj;
        setObj.Invoke(ConnectWindow.cache[id].selectedObj);
        ConnectWindow.cache.DelWindowCache(id);
    }
}
