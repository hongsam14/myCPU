using UnityEngine;
using UnityEditor;
using UnityEditor.UI;
using Unity;
using TMPro.EditorUtilities;
using System.Collections;

[CustomEditor(typeof(Gate))]
public class GateEditor : Editor
{
    Gate origin;
    
    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        origin = (Gate)target;
        DrawGateSection();
    }


    /// <summary>
    /// Draw 1 by 2 section on inspector
    /// </summary>
    void DrawGateSection()
    {
        GUILayout.BeginVertical();
        DrawGateHeader();

        GUILayout.BeginHorizontal();

        GUILayout.BeginVertical("Box");
        DrawInSection();
        GUILayout.EndVertical(); 
	    
	    GUILayout.BeginVertical("Box");
        DrawOutSection();
        GUILayout.EndVertical();

        GUILayout.EndHorizontal();
        
	    GUILayout.EndVertical();
    }

    void DrawGateHeader()
    {
        GUILayout.Label("Gate Controler", EditorStyles.boldLabel);
        EditorGUILayout.Space();
    }

    void DrawInSection()
    {
	    GUILayout.Label("In", EditorStyles.boldLabel);
        origin.inPortCount = EditorGUILayout.IntSlider(origin.inPortCount, 0, 10);

        for (int i = 0; i < origin.inPortCount; i++)
        {
            GUILayout.BeginHorizontal();
            if (origin.inputs == null || origin.inputs[i] == null)
            {
                GUILayout.Label("port" + i.ToString());
                if (GUILayout.Button("Connect"))
                {
				    //ConnectWindow.OpenWindow(origin.gameObject);
                    TMP_EditorCoroutine.StartCoroutine(Connect(i));
                }
            }
            else
            {
                GUILayout.Label("port" + i.ToString() + ":" + origin.inputs[i].name);
                if (GUILayout.Button("Disconnect"))
                {
                }
            }
            GUILayout.EndHorizontal();
        }
    }

    void DrawOutSection()
    {
    }

    /// <summary>
    /// Open Connected window and wait it closed, get result.
    /// </summary>
    /// <param name="portID">ID that you want to connect.</param>
    /// <returns></returns>
    IEnumerator Connect(int portID)
    {
        ConnectWindow.OpenWindow(origin.gameObject);
        //yield return new WaitWhile(()=>ConnectWindow.open);
        Debug.Log("wait start");
        while (ConnectWindow.open)
	    {
            yield return null;
	    }
        Debug.Log("wait end");
	    origin.inputs[portID] = ConnectWindow.selectedObject;
    }
}
