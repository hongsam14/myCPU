using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Types;

public class GateDesignerWindow : EditorWindow
{
    Texture2D headerTexture;
    Texture2D gateSectionTexture;
    Texture2D muxSectionTexture;

    Color headerTextureColor = new Color(0.2f, 0.2f, 0.2f, 1f);
    Color gateSectionTextureColor = new Color(0.4f, 0.4f, 0.4f, 1f);
    Color muxSectionTextureColor = new Color(0.3f, 0.3f, 0.3f, 1.0f);

    Rect headerSection;
    Rect gateSection;
    Rect muxSection;

    static GateType gateType;
    static MuxType muxType;

    public static GateType gateInfo { get => gateType; }
    public static MuxType muxInfo { get => muxType;}

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
        InitTextures();
        InitData();
    }
    /// <summary>
    /// initialize Texture2D values
    /// </summary>
    void InitTextures()
    {
        if (!(headerTexture = Resources.Load<Texture2D>("icons/editor_header_gradient")))
        {
            headerTexture = new Texture2D(1, 1);
            headerTexture.SetPixel(0, 0, headerTextureColor);
            headerTexture.Apply();
        }
        if (!(gateSectionTexture = Resources.Load<Texture2D>("icons/editor_gateSection_gradient")))
        {
            gateSectionTexture = new Texture2D(1, 1);
            gateSectionTexture.SetPixel(0, 0, gateSectionTextureColor);
            gateSectionTexture.Apply();
        }
        if (!(muxSectionTexture = Resources.Load<Texture2D>("icons/editor_muxSection_gradient")))
        {
            muxSectionTexture = new Texture2D(1, 1);
            muxSectionTexture.SetPixel(0, 0, muxSectionTextureColor);
            muxSectionTexture.Apply();
        }
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
        DrawLayouts();
        DrawHeader();
        DrawGateSetting();
        DrawMuxSetting();

    }
    /// <summary>
    /// define rect values and point textures based on rects
    /// </summary>
    void DrawLayouts() 
    {
        headerSection.position = new Vector2(0, 0);
        headerSection.width = this.minSize.x;
        headerSection.height = 50;

        gateSection.position = new Vector2(0, headerSection.height);
        gateSection.width = headerSection.width / 2;
        gateSection.height = this.minSize.y - headerSection.height;

        muxSection.position = new Vector2(gateSection.width, headerSection.height);
        muxSection.width = headerSection.width / 2;
        muxSection.height = this.minSize.y - headerSection.height;

        GUI.DrawTexture(headerSection, headerTexture);
        GUI.DrawTexture(gateSection, gateSectionTexture);
        GUI.DrawTexture(muxSection, muxSectionTexture);
    }
    /// <summary>
    /// draw contents of header
    /// </summary>
    void DrawHeader() 
    {
        GUILayout.BeginArea(headerSection);
        GUILayout.Label("Gate Designer", EditorStyles.boldLabel);
        GUILayout.EndArea();
    }
    /// <summary>
    /// draw contents of gate object
    /// </summary>
    void DrawGateSetting()
    {
        GUILayout.BeginArea(gateSection);
        GUILayout.Label("Gate", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        GUILayout.BeginHorizontal();
        GUILayout.Label("type :");
        gateType = (GateType)EditorGUILayout.EnumPopup(gateType);
        GUILayout.EndHorizontal();

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
        
	    GUILayout.EndArea();
    }
    /// <summary>
    /// draw contents of mux object
    /// </summary>
    void DrawMuxSetting()
    { 
        GUILayout.BeginArea(muxSection);
        GUILayout.Label("Multiplexor", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        GUILayout.BeginHorizontal();
        GUILayout.Label("type :");
        muxType = (MuxType)EditorGUILayout.EnumPopup(muxType);
        GUILayout.EndHorizontal();
        
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
	    
	    GUILayout.EndArea();
    }
}