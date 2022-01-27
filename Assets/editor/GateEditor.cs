using UnityEngine;
using UnityEditor;
using UnityEditor.UI;

[CustomEditor(typeof(Gate))]
public class GateEditor : Editor
{
    private int inPortCount = 0;
    private int outPortCount = 0;
    
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
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
        inPortCount = EditorGUILayout.IntSlider(inPortCount, 0, 10);

        for (int i = 0; i < inPortCount; i++)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label("port" + i.ToString());
            if (GUILayout.Button("Connect"))
            {
            }
            if (GUILayout.Button("Disconnect"))
            {
            }
            GUILayout.EndHorizontal();
        }
    }

    void DrawOutSection()
    {
        GUILayout.Label("Out", EditorStyles.boldLabel);
	    
        outPortCount = EditorGUILayout.IntSlider(outPortCount, 0, 10);

        for (int i = 0; i < outPortCount; i++)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label("port" + i.ToString());
            if (GUILayout.Button("Connect"))
            {
            }
            if (GUILayout.Button("Disconnect"))
            {
            }
            GUILayout.EndHorizontal();
        }
    }
}
