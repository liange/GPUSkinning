
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIButtonLoadScene : MonoBehaviour
{
    public Button m_Button;

    public string m_SceneName;

    void Start()
    {
        m_Button.onClick.AddListener(OnLoadScene);
    }

    public void OnLoadScene()
    {
        SceneManager.LoadScene(m_SceneName);
    }
}
