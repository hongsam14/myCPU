using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Runtime.CompilerServices;

public class ConnectWindow : EditorWindow
{
    public static bool open;
    public static GameObject pickedObject { get; private set; }
    private bool warnMessage = false;
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
        pickedObject = null;
        open = true;
    }

    private void OnDestroy()
    {
        open = false;
    }

    private void OnGUI()
    {
        
	    EditorGUILayout.HelpBox("please Select Object and press connect button. ", MessageType.Info);
        if (GUILayout.Button("Connect"))
	    {
            int num = 0;
            GameObject tmp = null;
            foreach (GameObject i in Selection.gameObjects)
	        {
                if (i != target)
                {
		            tmp = i;
		            num++;
                }
	        }
            if (num > 1 || num == 0)
            {
                warnMessage = true;
            }
            else
	        {
                warnMessage = false;
                pickedObject = tmp;
                this.Close();
	        }
	    }
        if (warnMessage)
        {
            EditorGUILayout.HelpBox("please select just one Object.", MessageType.Warning);
        }
    }
}
