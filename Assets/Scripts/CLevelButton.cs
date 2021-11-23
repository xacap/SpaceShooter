using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CLevelButton : MonoBehaviour
{
    [SerializeField] Font font;
    [SerializeField] Sprite levelCompletedSprite;

    [System.Obsolete]
    public void Initialize(int mLevelID, string mLevelName, bool mLevelCompleted, bool buttonActive)
    {
        this.GetComponent<Button>().interactable = buttonActive;
        this.GetComponent<Button>().transition = Selectable.Transition.SpriteSwap;

        if (mLevelCompleted)
        {
            this.GetComponent<Button>().image.sprite = levelCompletedSprite;
        }

        this.GetComponent<Button>().onClick.AddListener(delegate {
            CGameManager.Instance.SetLevelID(mLevelID);
            CGameManager.Instance.SwitchScene(mLevelName);
        });
    }
}
