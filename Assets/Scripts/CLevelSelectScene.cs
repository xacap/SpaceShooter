using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CGameData;


public class CLevelSelectScene : MonoBehaviour
{
    [SerializeField] GameObject levelIcon;
    [SerializeField] GameObject iconPanel;
    List<CLevelConfig> levelConfigsList;
    private int currentLevelCount = 0;
    //GameObject lvlCompltdImage;
    private int lvlCount;

    private void Awake()
    {
        levelConfigsList = CGameManager.Instance.mGameData.ConfigsList;
        lvlCount = levelConfigsList.Count;
    }

    [System.Obsolete]
    void Start()
    {
        LoadIcons(lvlCount);
    }

    [System.Obsolete]
    void LoadIcons(int numbIcons)
    {
        int aLevelID;
        string aLevelName;
        bool aLevelCompleted;

        for (int i = 0; i < numbIcons; i++)
        {
            aLevelID = levelConfigsList[currentLevelCount].levelID;
            aLevelName = levelConfigsList[currentLevelCount].levelName;
            aLevelCompleted = levelConfigsList[currentLevelCount].levelCompleted;
            bool buttonActive = false;

            if ((currentLevelCount - 1) < 0)
            {
                buttonActive = true;
            }
            else if (levelConfigsList[currentLevelCount - 1].levelCompleted == true)
            {
                buttonActive = true;
            }

            GameObject icon = Instantiate(levelIcon) as GameObject;
            icon.transform.SetParent(iconPanel.transform);

            CLevelButton aLevelIcon = icon.GetComponent<CLevelButton>();
            aLevelIcon.Initialize(aLevelID, aLevelName, aLevelCompleted, buttonActive);

            currentLevelCount++;
        }
    }
}
