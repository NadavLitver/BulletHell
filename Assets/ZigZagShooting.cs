using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZigZagShooting : Pattern
{
    [SerializeField]
    private int bulletAmount = 10;

    [SerializeField]
    private float distanceBetweenBullets = 1.1f;
 
 
    private void OnEnable()
    {
        StartCoroutine(ShootZigZag());
    }

    IEnumerator ShootZigZag()
    {
        float posX = transform.position.x;
        Vector2 bulletDir = (playerRef.transform.position - transform.position).normalized;
        for (int i = 0; i < bulletAmount; i++)
        {

            if (i % 3 == 0)
            {
                distanceBetweenBullets *= -1;
            }
            GameObject bullet = BulletPool.bp_instace.GetBullet();
            bullet.transform.position = new Vector2(posX,transform.position.y);
            bullet.transform.rotation = transform.rotation;
            bullet.GetComponent<Bullet>().SetMovement(bulletDir);
            bullet.SetActive(true);
            posX += distanceBetweenBullets;
          
            yield return new WaitForSeconds(0.1f);
        }
    }
    private void OnDisable()
    {
        
    }
}

