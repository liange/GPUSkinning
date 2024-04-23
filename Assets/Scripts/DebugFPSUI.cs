using UnityEngine;
using System.Collections;

public class DebugFPSUI : MonoBehaviour
{
    public bool m_CenterTop = true;

    public Rect m_StartRect = new Rect(0, 0, 80, 40);

    public bool m_AllowDrag = true;

    public float m_FPSMeasurePeriod = 0.5F;

    public int m_TargetFrameRate = 60;

    private int m_FpsAccumulator = 0;

    private Color m_Color = Color.white;

    private string m_StrFPS = "";

    private GUIStyle m_Style;

    private float m_LastTime;

    void Start()
    {
        m_LastTime = Time.realtimeSinceStartup;
        Application.targetFrameRate = m_TargetFrameRate;
    }

    void Update()
    {
        m_FpsAccumulator++;

        float passTime = Time.realtimeSinceStartup - m_LastTime;
        if (passTime >= m_FPSMeasurePeriod)
        {
            float fps = m_FpsAccumulator / passTime;
            m_Color = (fps >= 30) ? Color.green : ((fps > 24) ? Color.yellow : Color.red);
            m_FpsAccumulator = 0;
            m_LastTime = Time.realtimeSinceStartup;

            m_StrFPS = string.Format("FPS:{0:F1}", fps);
        }
    }

    void OnGUI()
    {
        if (m_Style == null)
        {
            m_Style = new GUIStyle(GUI.skin.label);
            m_Style.normal.textColor = Color.white;
            m_Style.alignment = TextAnchor.MiddleLeft;
        }

        GUI.color = m_Color;

        Rect rect = m_StartRect;
        if (m_CenterTop)
        {
            rect.x += Screen.width / 2 - rect.width / 2;
        }

        m_StartRect = GUI.Window(GetInstanceID(), rect, UpdateWindow, "");

        if (m_CenterTop)
        {
            m_StartRect.x -= Screen.width / 2 - rect.width / 2;
        }
    }

    void UpdateWindow(int windowID)
    {
        GUI.Label(new Rect(10, 0, m_StartRect.width, m_StartRect.height), m_StrFPS, m_Style);
        if (m_AllowDrag)
        {
            //GUI.DragWindow(new Rect(0, 0, Screen.width, Screen.height));
            GUI.DragWindow();
        }
    }
}