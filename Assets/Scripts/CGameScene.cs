using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CGameData;
using UnityEngine.SceneManagement;

public class CGameScene : MonoBehaviour
{
    int currentLevelID;
    List<CLevelConfig> levelConfigs;

    private void Awake()
    {
        levelConfigs = CGameManager.Instance.mGameData.ConfigsList;
        currentLevelID = CGameManager.Instance.mGameData.mActiveLevelId;
    }
    private void Start()
    {
        int aLevelID;
        string aLevelName;

        for (int i = 0; i < levelConfigs.Count; i++)
        {
            aLevelID = levelConfigs[i].levelID;
            aLevelName = levelConfigs[i].levelName;

            if (aLevelID == currentLevelID)
            {
                GameObject newLevel = (GameObject)Instantiate(Resources.Load(aLevelName));
            }
        }
    }

}
