using System.Collections;
using UnityEngine;
using UnityEditor;
using ConnectData;
using TMPro.EditorUtilities;

public class ConnectWindow : EditorWindow
{
    private static WindowCache cache { get; set; } = new WindowCache();
    private static int id = 0;
    
    private GameObject parentObj;
    private int my_id;

    /// <summary>
    /// make ConnectWindow Instance and return WindowId.
    /// </summary>
    static int OpenWindow(GameObject parent)
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

    public delegate void setObjmethod(GameObject to);

    /// <summary>
    /// Open ConnectWindow and run func
    /// </summary>
    /// <param name="parent"></param>
    /// <param name="func"></param>
    public static void Connect(GameObject parent, setObjmethod func)
    {
        TMP_EditorCoroutine.StartCoroutine(ConnectCoroutine(parent, func));
    }
    
    static IEnumerator ConnectCoroutine(GameObject parent, setObjmethod func)
    {
        //ActiveEditorTracker.sharedTracker.isLocked = true;
        int id = OpenWindow(parent);
        while (cache[id].open)
        {
            yield return null;
        }
        func.Invoke(cache[id].selectedObj);
        cache.DelWindowCache(id);
        //ActiveEditorTracker.sharedTracker.isLocked = false;
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
                returnSelection();
                this.Close();
            }
	    }
	    if (warn)
            DrawWarnMessage();
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
}