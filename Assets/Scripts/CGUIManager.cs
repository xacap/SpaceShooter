using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGUIManager : MonoBehaviour
{
    CPlayerController mPlayerController;

    
    public void ShowGameFinishWindow()
    {
        mPlayerController = GameObject.FindGameObjectWithTag("player").GetComponent<CPlayerController>();

        if (mPlayerController.mState == EPlayerState.ePlayerWinner)
        {
            GameObject go = Instantiate(Resources.Load("CanvasFinishWindow")) as GameObject;
            go.GetComponent<RectTransform>().localPosition = new Vector3(960f, 540f, 0);
        }

        if (mPlayerController.mState == EPlayerState.ePlayerLost)
        {
            GameObject go = Instantiate(Resources.Load("CanvasLostWindow")) as GameObject;
            go.GetComponent<RectTransform>().localPosition = new Vector3(960f, 540f, 0);
        }


    }
}
