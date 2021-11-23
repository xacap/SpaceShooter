using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;

public class CGameData
{
    private List<CLevelConfig> mLevelConfigsList;
    public List<CLevelConfig> ConfigsList
    {
        get { return mLevelConfigsList; }
        set { mLevelConfigsList = value; }
    }

    public int mActiveLevelId;
    
    public void CreateLevelConfigList()
    {
        mLevelConfigsList = new List<CLevelConfig>();

        for (int i = 0; i < 3; i++)
        {
            CLevelConfig lConfig = new CLevelConfig();
            int lvlID = i + 1;
            string lvlName = "level";

            lConfig.levelID = lvlID;
            lConfig.levelName = lvlName + lvlID.ToString();
            lConfig.meteorCout = 0;
            lConfig.levelCompleted = false;
            
            mLevelConfigsList.Add(lConfig);
        }
    }
    public void EditLevelConfigsList(int aLevelId)
    {
        for (int i = 0; i < mLevelConfigsList.Count; i++)
        {
            CLevelConfig config = mLevelConfigsList[i];

            if (config.levelID == aLevelId)
            {
                config.levelCompleted = true;
                mLevelConfigsList[i] = config;

                SeveLevelConfigList();
            }
        }
    }
    public void AddMeteorCount(int lvlelID, float mDelay)
    {
        CLevelConfig config = mLevelConfigsList[lvlelID];

        config.meteorCout = mDelay;
        mLevelConfigsList[lvlelID] = config;
        SeveLevelConfigList();
    }

    public void SetActiveLevel(int levelID)
    {
        mActiveLevelId = levelID;
        EditLevelConfigsList(mActiveLevelId);
    }
    
    public void LoadLevelConfigList()
    {
        string jsonString = PlayerPrefs.GetString("gameData");

        if (String.IsNullOrEmpty(jsonString))
            return;

        CLevelSelectList tempLevelConfigList = JsonUtility.FromJson<CLevelSelectList>(jsonString);
        mLevelConfigsList = tempLevelConfigList.levelConfigList;
    }

    [Serializable]

    public class CLevelConfig
    {
        public int levelID;
        public string levelName;
        public float meteorCout;
        public bool levelCompleted = false;
    }

    [SerializeField]
    public class CLevelSelectList
    {
        public List<CLevelConfig> levelConfigList;
    }
    
    private void SeveLevelConfigList()
    {
        CLevelSelectList lvlSelList = new CLevelSelectList { levelConfigList = mLevelConfigsList };
        
        string jsonLvlConfigList = JsonUtility.ToJson(lvlSelList);
        Debug.Log(jsonLvlConfigList);
        
        PlayerPrefs.SetString("gameData", jsonLvlConfigList);
        PlayerPrefs.Save();
    }
}
