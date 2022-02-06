using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using ConnectData;

public class ConnectWindow : EditorWindow
{
    public static WindowCache cache = new WindowCache();
    
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

        cache.AddPortCacheToGate(target, index).Open();

        window.minSize = new Vector2(100, 100);
        GUIContent titleContent = new GUIContent(target.name + "/port" + index.ToString());
        window.titleContent = titleContent;

        window.Show();
    }

    public static GameObject getConnectObjInfo(GameObject obj, int i) => cache[obj, i].GetObject();
    
    public static bool getWindowStatusInfo(GameObject obj, int i) => cache[obj, i].Status();

    public static void cleanConnectWindowInfo(GameObject obj, int i) => cache.DelPortCacheFromGate(obj, i);

    private void OnEnable()
    {
    }

    private void OnDestroy()
    {
        cache[target, index].Close();
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
                cache[target, index].Connect(tmp);
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