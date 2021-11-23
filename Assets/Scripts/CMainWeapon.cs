using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMainWeapon : MonoBehaviour, IWeapon
{
    public EWeponType main;

    private float mTime;

    private GameObject bulletPrefab;

    public void Shoot()
    {
        if (mTime + 0.5 <= Time.time)
        {
            bulletPrefab = Resources.Load<GameObject>("Bullet");
            Instantiate(bulletPrefab);

            mTime = Time.time;
        }

        if (bulletPrefab != null)
        {
            bulletPrefab.transform.position = this.transform.position;
        }
    }

    public EWeponType GetWeaponType(EWeponType eWeponTipe)
    {
        return main;
    }
}
