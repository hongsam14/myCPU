using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Types;

public class GateDesignerWindow : EditorWindow
{
    static GateType gateType;
    static MuxType muxType;

    public static GateType gateInfo { get => gateType; }
    public static MuxType muxInfo { get => muxType; }

    static GateData gateData;
    static MuxData muxData;

    [MenuItem("Window/Gate Designer")]
    static void OpenWindow()
    {
        GateDesignerWindow window = (GateDesignerWindow)GetWindow(typeof(GateDesignerWindow));
        window.minSize = new Vector2(400, 300);
        window.Show();
    }


    /// <summary>
    /// similar with Awake() and Start()
    /// </summary>
    void OnEnable()
    {
        //InitTextures();
        InitData();
    }
    
    /// <summary>
    /// read Gate, Mux Objects from resources
    /// </summary>
    void InitData()
    {
        gateData = Resources.Load<GateData>("gateData/data/gate/gateData");
        muxData = Resources.Load<MuxData>("gateData/data/mux/muxData");
    }
    
    /// <summary>
    /// similar with Update function. not called once per frame, called one or more times per interactions
    /// </summary>
    void OnGUI()
    {
        //DrawLayouts();
        DrawHeader();
        GUILayout.BeginHorizontal();
        DrawGateSetting();
        DrawMuxSetting();
        GUILayout.EndHorizontal();

    }
    
    /// <summary>
    /// draw contents of header
    /// </summary>
    void DrawHeader()
    {
        GUILayout.BeginVertical();
        GUILayout.Label("Gate Designer", EditorStyles.boldLabel);
        EditorGUILayout.Space();
        GUILayout.EndVertical();
    }
    
    /// <summary>
    /// draw contents of gate object
    /// </summary>
    void DrawGateSetting()
    {
        GUILayout.BeginVertical("Box");

        GUILayout.Label("Gate", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        GUILayout.BeginHorizontal();
        GUILayout.Label("type :");
        gateType = (GateType)EditorGUILayout.EnumPopup(gateType);
        GUILayout.EndHorizontal();
        EditorGUILayout.Space();

        if (GUILayout.Button("Create"))
        {
            switch (gateType)
            {
                case GateType.Not:
                    Instantiate<GameObject>(gateData.notObject);
                    break;
                case GateType.Or:
                    Instantiate<GameObject>(gateData.orObject);
                    break;
                case GateType.And:
                    Instantiate<GameObject>(gateData.andObject);
                    break;
                case GateType.Xor:
                    Instantiate<GameObject>(gateData.xorObject);
                    break;
                default:
                    break;
            }
        }

        GUILayout.EndVertical();
    }
    
    /// <summary>
    /// draw contents of mux object
    /// </summary>
    void DrawMuxSetting()
    {
        GUILayout.BeginVertical("Box");

        GUILayout.Label("Multiplexor", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        GUILayout.BeginHorizontal();
        GUILayout.Label("type :");
        muxType = (MuxType)EditorGUILayout.EnumPopup(muxType);
        GUILayout.EndHorizontal();
        EditorGUILayout.Space();

        if (GUILayout.Button("Create"))
        {
            switch (muxType)
            {
                case MuxType.Mux:
                    Instantiate<GameObject>(muxData.muxObject);
                    break;
                case MuxType.DeMux:
                    Instantiate<GameObject>(muxData.deMuxObject);
                    break;
                default:
                    break;
            }
        }

        GUILayout.EndVertical();
    }
}