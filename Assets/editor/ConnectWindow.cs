using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using ConnectData;

public class ConnectWindow : EditorWindow
{
    public static WindowCache cache { get; private set; } = new WindowCache();
    private static int id = 0;
    
    private GameObject parentObj;
    private int my_id;

    /// <summary>
    /// make ConnectWindow Instance and return WindowId.
    /// </summary>
    public static int OpenWindow(GameObject parent)
    {
        ConnectWindow window = CreateInstance<ConnectWindow>();

        window.parentObj = parent;
        window.my_id = id;

        Debug.Log("in:" + window.my_id.ToString());

        window.minSize = new Vector2(100, 100);
        GUIContent titleContent = new GUIContent(parent.name);
        window.titleContent = titleContent;

        window.Show();
        return id++;
    }

    private void OnEnable()
    {
        cache.AddWindowCache(id).open = true;
    }

    private void OnDestroy()
    {
        cache[my_id].open = false;
        id--;
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
                cache[my_id].selectedObj = tmp;
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