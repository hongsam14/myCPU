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
}
