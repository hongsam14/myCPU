using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Connect;

public class ConnectWindow : EditorWindow
{
    public static WindowData data = new WindowData();
    
    private GameObject target;
    private int index;

    /// <summary>
    /// init connect_window.
    /// </summary>
    public static void OpenWindow(GameObject target, int index)
    {
        ConnectWindow window = CreateInstance<ConnectWindow>();

        window.target = target;
        window.index = index;

        data.AddData(index);
        data.SetData(index, true); //set status data open.

        window.minSize = new Vector2(100, 100);
        GUIContent titleContent = new GUIContent(target.name + "/port" + index.ToString());
        window.titleContent = titleContent;

        window.Show();
    }

    public static GameObject getConnectObjInfo(int index) { return data.GetObj(index); }
    
    public static bool getWindowStatusInfo(int index) { return data.GetStatus(index); }

    public static void cleanConnectWindowInfo(int index) 
    {
        data.ClearData(index);
    }

    private void OnEnable()
    {
    }

    private void OnDestroy()
    {
        data.SetData(index, false);
    }

    private void OnGUI()
    {
	    bool warn = false;

        DrawTutorialMessage();
        if (GUILayout.Button("Connect"))
	    {
		    GameObject tmp = null;
            int num = 0;
            
	        foreach (GameObject obj in Selection.gameObjects)
	        {
                if (obj != target)
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
                data.SetData(index, tmp);
			    this.Close(); 
	        }
	    }
        
	    if (warn)
            DrawWarnMessage();
    }

    private void DrawTutorialMessage()
    {
	    EditorGUILayout.HelpBox("please Select Object and press connect button. ", MessageType.Info);
    }

    private void DrawWarnMessage()
    {
	    EditorGUILayout.HelpBox("please select just one Object.", MessageType.Warning);
    }
}

namespace Connect
{
    public class WindowData
    {
        private Dictionary<int, bool> windowStatus;
        private Dictionary<int, GameObject> selectionStatus;

        public WindowData()
        {
            windowStatus = new Dictionary<int, bool>();
            selectionStatus = new Dictionary<int, GameObject>();
        }

        public WindowData(ref WindowData prev)
        {
            windowStatus = prev.windowStatus;
            selectionStatus = prev.selectionStatus;
        }

        ~WindowData()
        {
            windowStatus.Clear();
            selectionStatus.Clear();
        }

        public void AddData(int index)
        {
            windowStatus.Add(index, false);
            selectionStatus.Add(index, null);
        }

        public void ClearData(int index)
        {
            windowStatus.Remove(index);
            selectionStatus.Remove(index);
        }

        public void SetData(int index, bool status)
        {
            windowStatus[index] = status;
        }

        public void SetData(int index, GameObject selected)
        {
            selectionStatus[index] = selected;
        }

        public void SetData(int index, bool status, GameObject selected)
        {
            windowStatus[index] = status;
            selectionStatus[index] = selected;
        }

        public bool GetStatus(int index) => windowStatus[index];

        public GameObject GetObj(int index) => selectionStatus[index];
    }
}

