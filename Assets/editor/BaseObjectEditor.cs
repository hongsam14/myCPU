using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using BaseModel;
using System;

[CustomEditor(typeof(BaseObject))]
public class BaseObjectEditor : Editor
{
    BaseObject origin;
    
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        origin = (BaseObject)target;
        serializedObject.Update();
        DrawSection();
        serializedObject.ApplyModifiedProperties();
    }

    protected virtual void DrawSection()
    {
        DrawInputSection();
        DrawOutputSection();
    }

    protected void DrawInputSection()
    {
        EditorGUILayout.BeginVertical("Box");
        GUILayout.Label("In", EditorStyles.boldLabel);
        //origin.InputSize = EditorGUILayout.IntSlider(origin.InputSize, 0, 10);
        for (int i = 0; i < origin.Inputs.Count; i++)
        {
            EditorGUILayout.BeginHorizontal("Box");
            GUILayout.Label(origin.Inputs[i].ToString());
            if (origin.Inputs[i].Connected() == null)
            {
                if (GUILayout.Button("Connect"))
                {
                    ConnectPortWindow.OpenWindow(origin.Inputs[i], origin.gameObject);
                }
            }
            else
            {
                GUILayout.Label("from");
                GUILayout.Label(String.Format("{0}.{1}", origin.Inputs[i].From.obj.name, origin.Inputs[i].From.ToString()));
                if (GUILayout.Button("Disconnect"))
                {
                    origin.Inputs[i].Disconnect();
                }
            }
            EditorGUILayout.EndHorizontal();
        }
        EditorGUILayout.EndVertical();
    }

    protected void DrawSelSection()
    {
        EditorGUILayout.BeginVertical("Box");
        GUILayout.Label("Sel", EditorStyles.boldLabel);
        //origin.SelSize = EditorGUILayout.IntSlider(origin.SelSize, 0, 10);
        for (int i = 0; i < origin.Sels.Count; i++)
        {
            EditorGUILayout.BeginHorizontal("Box");
            GUILayout.Label(origin.Sels[i].ToString());
            if (origin.Sels[i].Connected() == null)
            {
                if (GUILayout.Button("Connect"))
                {
                    ConnectPortWindow.OpenWindow(origin.Sels[i], origin.gameObject);
                }
            }
            else
            {
                GUILayout.Label("from");
                GUILayout.Label(String.Format("{0}.{1}", origin.Sels[i].From.obj.name, origin.Sels[i].From.ToString()));
                if (GUILayout.Button("Disconnect"))
                {
                    origin.Sels[i].Disconnect();
                }
            }
            EditorGUILayout.EndHorizontal();
        }
        EditorGUILayout.EndVertical();
    }

    protected void DrawOutputSection()
    {
        EditorGUILayout.BeginVertical("Box");
        GUILayout.Label("Out", EditorStyles.boldLabel);
        //origin.OutputSize = EditorGUILayout.IntSlider(origin.OutputSize, 0, 10);
        for (int i = 0; i < origin.Outputs.Count; i++)
        {
            EditorGUILayout.BeginHorizontal("Box");
            GUILayout.Label(origin.Outputs[i].ToString());
            if (origin.Outputs[i].Connected() == null)
            {
                if (GUILayout.Button("Connect"))
                {
                    ConnectPortWindow.OpenWindow(origin.Outputs[i], origin.gameObject);
                }
            }
            else
            {
                GUILayout.Label("to");
                GUILayout.Label(String.Format("{0}.{1}", origin.Outputs[i].To.obj.name, origin.Outputs[i].To.ToString()));
                if (GUILayout.Button("Disconnect"))
                {
                    origin.Outputs[i].Disconnect();
                }
            }
            EditorGUILayout.EndHorizontal();
        }
        EditorGUILayout.EndVertical();
    }
}
