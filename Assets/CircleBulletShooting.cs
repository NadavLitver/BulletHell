using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleBulletShooting : Pattern
{
    [SerializeField]
    private GameObject CirclePrefab;
 
    private void OnEnable()
    {
        ShootCircle();
     
    }

   
    void ShootCircle()
    {
        Vector2 bulletDir = (playerRef.transform.position - transform.position).normalized;
        GameObject bullet = Instantiate(CirclePrefab);
        bullet.transform.position = transform.position;
        bullet.transform.rotation = transform.rotation;
        bullet.GetComponent<CircleBulletHandler>().dir = bulletDir;
    }
}
