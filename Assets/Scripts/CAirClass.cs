using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAirClass : MonoBehaviour
{
    public Vector3 targetPosition = Vector3.zero;
    public float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private CMainWeapon mMainWeapon;

    public Transform slotTransform;

    private void Awake()
    {
        mMainWeapon = Instantiate(mMainWeapon);
        mMainWeapon.transform.SetParent(this.transform, false);

        AddWeapons();
    }
    void Update()
    {
        mMainWeapon.transform.position = slotTransform.position;

        Shooting();
    }

    void Shooting()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            mMainWeapon.Shoot();
        }
    }

    public void AddWeapons()
    {
        slotTransform = this.gameObject.transform.GetChild(0);
    }
}
