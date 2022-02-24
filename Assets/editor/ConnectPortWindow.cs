using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using BaseModel;

public class ConnectPortWindow : EditorWindow
{
    public bool open { get; private set; }
    public Port selectedPort { get; private set; }

    private Port parentPort;
    private GameObject parentObj;
    private GameObject selected;
    private bool warn = false;

    public static ConnectPortWindow OpenWindow(Port parentPort, GameObject parentObj)
    {
        ConnectPortWindow window = CreateInstance<ConnectPortWindow>();
        window.parentPort = parentPort;
        window.parentObj = parentObj;

        window.minSize = new Vector2(100, 100);
        GUIContent titleContent = new GUIContent(parentPort.ToString());
        window.titleContent = titleContent;

        window.Show();
        return window;
    }

    private void OnEnable()
    {
        open = true;
    }

    private void OnDestroy()
    {
        open = false;
        returnSelection();
    }

    private void OnGUI()
    {
        DrawTutorialMessage();
        if (selected == null)
        {
            if (GUILayout.Button("Select"))
            {
                GameObject tmp = null;
                int num = 0;

                foreach (GameObject obj in Selection.gameObjects)
                {
                    if (obj != parentObj)
                    {
                        tmp = obj;
                        num++;
                    }
                }
                if (num > 1 || num == 0)
                {
                    warn = true;
                }
                else
                {
                    warn = false;
                    selected = tmp;
                }
            }
            if (warn)
                DrawWarnMessage();
        }
        else
        {
            DrawPortInfo(selected);
            if (GUILayout.Button("Deselect"))
            {
                selected = null;
            }
        }
    }

    private void returnSelection()
    {
        Object[] lst = new Object[1];
        lst[0] = parentObj;
        Selection.objects = lst;
    }

    private void DrawTutorialMessage()
    {
        EditorGUILayout.HelpBox("please Select Object and press connect button. ", MessageType.Info);
    }

    private void DrawWarnMessage()
    {
        EditorGUILayout.HelpBox("please select just one Object.", MessageType.Warning);
    }

    private void DrawPortInfo(GameObject select)
    {
        List<Port> portList;

        if (parentPort.type == Port.Dir.enter || parentPort.type == Port.Dir.sel)
        {
            portList = select.GetComponent<BaseObject>().Outputs;
        }
        else
        {
            portList = select.GetComponent<BaseObject>().Inputs;
            portList.AddRange(select.GetComponent<BaseObject>().Sels);
        }
        if (portList != null)
        {
            for (int i = 0; i < portList.Count; i++)
            {
                EditorGUILayout.BeginHorizontal("Box");
                GUILayout.Label(portList[i].ToString());
                if (GUILayout.Button("connect"))
                {
                    selectedPort = portList[i];
                    if (parentPort.type == Port.Dir.enter || parentPort.type == Port.Dir.sel)
                    {
                        parentPort.ConnectFrom(selectedPort);
                    }
                    else
                    {
                        parentPort.ConnectTo(selectedPort);
                    }
                    this.Close();
                }
                EditorGUILayout.EndHorizontal();
            }
        }
    }
}