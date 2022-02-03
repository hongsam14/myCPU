using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ConnectWindow : EditorWindow
{
    public static bool open;
    public static GameObject selectedObject { get; private set; }
    
    private GameObject target;

    /// <summary>
    /// init connect_window.
    /// </summary>
    public static void OpenWindow(GameObject target)
    {
        ConnectWindow window = GetWindow<ConnectWindow>(typeof(ConnectWindow));
        window.minSize = new Vector2(100, 100);
        window.target = target;
        window.Show();
    }
    
    private void OnEnable()
    {
        Debug.Log("open");
        selectedObject = null;
        open = true;
    }

    private void OnDestroy()
    {
        Debug.Log("close");
        open = false;
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
			    selectedObject = tmp;
			    this.Close(); 
	        }
	    }
        
	    if (warn)
            DrawWarnMessage();
    }

    void DrawTutorialMessage()
    {
	    EditorGUILayout.HelpBox("please Select Object and press connect button. ", MessageType.Info);
    }

    void DrawWarnMessage()
    {
	    EditorGUILayout.HelpBox("please select just one Object.", MessageType.Warning);
    }
}
