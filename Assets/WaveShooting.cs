using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveShooting : Pattern
{
    [SerializeField]
    private int bulletAmount = 10;

    [SerializeField]
    private float startAngle = 90f;
    [SerializeField]
    private float endAngle = 270f;

   

    private void OnEnable()
    {
        ShootWave();
    }

    void ShootWave()
    {
        float angleStepTemp = (endAngle - startAngle);
        float angleStep = angleStepTemp / bulletAmount;
        float angle = startAngle;
       

        for (int i = 0; i < bulletAmount; i++)
        {

            float bulletDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulletDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);
            Vector2 bulletMoveVector = new Vector2(bulletDirX, bulletDirY);
            Vector2 bulletDir = (bulletMoveVector - (Vector2)transform.position).normalized;
            GameObject bullet = BulletPool.bp_instace.GetBullet();
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            bullet.GetComponent<Bullet>().SetMovement(bulletDir);
            bullet.SetActive(true);
            angle += angleStep;
        }
    }
    private void OnDisable()
    {
        
    }
}
