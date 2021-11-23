using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static CGameData;

public class CLevelStartScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void LoadLevelSelectScene()
    {
        SceneManager.LoadSceneAsync("LevelSelectScn");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
