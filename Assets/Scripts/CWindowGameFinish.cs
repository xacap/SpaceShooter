using UnityEngine;
using UnityEngine.UI;

public class CWindowGameFinish : MonoBehaviour
{
    void Start()
    {
        GameObject panel = gameObject.transform.Find("PanelButton").gameObject;

        GameObject buttonSelectObj = panel.transform.Find("ButtonSelect").gameObject;
        Button buttonSelect = buttonSelectObj.GetComponent<Button>();
        buttonSelect.onClick.AddListener(() => LevelSelectSceneButton());

        GameObject buttonNextObj = panel.transform.Find("ButtonNext").gameObject;
        Button buttonNext = buttonNextObj.GetComponent<Button>();
        buttonNext.onClick.AddListener(() => NextLevelButton());
    }

    public void NextLevelButton()
    {
        int aLevelID;
        aLevelID = CGameManager.Instance.mGameData.mActiveLevelId;
        CGameManager.Instance.SetLevelID(aLevelID + 1);
        CGameManager.Instance.SwitchScene("GameScene");
        Destroy(this.gameObject);
        Time.timeScale = 1.0f;
    }

    public void LevelSelectSceneButton()
    {
        CGameManager.Instance.LoadScene("LevelSelectScn");

        Destroy(this.gameObject);
        Time.timeScale = 1.0f;
    }
}