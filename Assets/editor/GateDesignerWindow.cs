using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GateDesignerWindow : EditorWindow
{
    [MenuItem("Window/Gate Designer")]
    static void OpenWindow()
    {
        GateDesignerWindow window = (GateDesignerWindow)GetWindow(typeof(GateDesignerWindow));
        window.minSize = new Vector2(600, 300);
        window.Show();
    }

    /// <summary>
    /// similar with Awake() and Start()
    /// </summary>
    void OnEnable()
    {

    }
    /// <summary>
    /// initialize Texture2D values
    /// </summary>
    void InitTextures()
    {
    }
    /// <summary>
    /// similar with Update function. not called once per frame, called one or more times per interactions
    /// </summary>
    void OnGUI()
    { 
    }
    /// <summary>
    /// define rect values and point textures based on rects
    /// </summary>
    void DrawLayouts() 
    {
    }
    /// <summary>
    /// draw contents of header
    /// </summary>
    void DrawHeader() 
    {
    }
    /// <summary>
    /// draw contents of gate object
    /// </summary>
    void DrawGateSetting()
    {
    }
    /// <summary>
    /// draw contents of mux object
    /// </summary>
    void DrawMuxSetting()
    { 
    }
}
