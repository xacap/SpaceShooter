using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class CGameManager : MonoBehaviour
{
    public static CGameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<CGameManager>();
                if (instance == null)
                {
                    var instanceContainer = new GameObject("CGameManager");
                    instance = instanceContainer.AddComponent<CGameManager>();
                }
            }
            return instance;
        }
    }
    private static CGameManager instance;

    public CGameData mGameData = null;
    public CEvents mNotificationManager = null;
    public CGUIManager mGUIManager = null;

    public CEvents GetNotificationManager()
    {
        return mNotificationManager;
    }

    private void Awake()
    {
        Initialization();
        mNotificationManager.Register(EEventType.eRestartGameEvent, IsGameFinished);
    }

    void Start()
    {
        if (PlayerPrefs.HasKey("gameData"))
        {
           mGameData.LoadLevelConfigList();
        }
        else
        {
           mGameData.CreateLevelConfigList();
        }

    }
    private void Initialization()
    {
        mGameData = new CGameData();
        mNotificationManager = new CEvents();
        mGUIManager = this.transform.GetComponent<CGUIManager>();
    }

    public void SetLevelID(int sceneID)
    {
        mGameData.SetActiveLevel(sceneID);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }
    public void SwitchScene(string sceneName)
    {
        SceneManager.LoadSceneAsync("GameScene");
    }

    public void IsGameFinished()
    {
        mGUIManager.ShowGameFinishWindow();
        Time.timeScale = 0f;
    }
}
