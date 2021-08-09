using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineShooting : Pattern
{
    [SerializeField]
    private int bulletAmount = 10;


 
  

     
    private void OnEnable()
    {
        StartCoroutine(ShootLine());
    }

    IEnumerator ShootLine()
    {
       

        for (int i = 0; i < bulletAmount; i++)
        {
         
         
            Vector2 bulletDir = (playerRef.transform.position - transform.position).normalized;
            GameObject bullet = BulletPool.bp_instace.GetBullet();
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            bullet.GetComponent<Bullet>().SetMovement(bulletDir);
            bullet.SetActive(true);
            yield return new WaitForSeconds(0.25f);
          
        }
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }
}

