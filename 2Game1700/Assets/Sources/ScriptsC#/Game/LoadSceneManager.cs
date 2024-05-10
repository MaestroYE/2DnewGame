using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour
{
    [SerializeField] GameObject settingPanel;

    public void LoadSceneID(int ID)
    {
        SceneManager.LoadScene(ID);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void SettingPanel()
    {
        settingPanel.SetActive(true);
    }
    public void ExitPanel()
    {
        settingPanel.SetActive(false);
    }
}
