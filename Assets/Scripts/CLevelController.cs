using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CGameData;


public class CLevelController : MonoBehaviour
{
    [SerializeField] GameObject MeteorObj;
    [SerializeField] GameObject FinishObj;
    [SerializeField] float minMeteor;
    [SerializeField] float maxMeteor;
    [SerializeField] float finishDalay = 10f;

    CLevelConfig levelConfig;

    int lvlID;
    float meteorDelay;

    private void Awake()
    {
        InitializationMeteor();
    }
    void Start()
    {
        StartCoroutine(MeteorSpawn(meteorDelay));
        StartCoroutine(FinishObjSpawn(finishDalay));
    }
    void InitializationMeteor()
    {
        lvlID = CGameManager.Instance.mGameData.mActiveLevelId - 1;

        levelConfig = CGameManager.Instance.mGameData.ConfigsList[lvlID];

        if (levelConfig.meteorCout == 0)
        {
            meteorDelay = Random.Range(minMeteor, maxMeteor);
            CGameManager.Instance.mGameData.AddMeteorCount(lvlID, meteorDelay);
        }
        else
        {
            meteorDelay = levelConfig.meteorCout;
        }
        Debug.Log("meteorDelay " + meteorDelay);
    }

    public IEnumerator MeteorSpawn(float waitTime)
    {
       while (true)
        {
            float randomX = Random.Range(-4f, 4f);
            Vector3 meteorPos = new Vector3(randomX, -5, 16);
            GameObject newMeteor = Instantiate(MeteorObj, meteorPos, transform.rotation);
            yield return new WaitForSeconds(waitTime);
        }
    }

    public IEnumerator FinishObjSpawn(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        Vector3 meteorPos = new Vector3(0, -3, 18);
        GameObject newMeteor = Instantiate(FinishObj, meteorPos, transform.rotation);
    }
}
