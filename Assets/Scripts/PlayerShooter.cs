using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public Transform firePoint;
    public float bulletForce = 20f;
    [SerializeField]
    private GameObject[] guns;
    [SerializeField]
    private KeyCode shootButton;
    [SerializeField]
    private GameObject currentGun;
    Vector2 mousePos;
    Vector2 dir;
    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dir = new Vector2(mousePos.x - firePoint.position.x, mousePos.y - firePoint.position.y).normalized;
        //float angle = Vector2.Angle(firePoint.forward, dir);
        // Debug.Log(dir);
        firePoint.rotation = Quaternion.Euler(0, 0, Angle(dir));
        //firePoint.LookAt(mousePos);
        Debug.DrawRay(firePoint.position, dir);
        if (Input.GetKeyDown(shootButton))
        {
            Shoot();
        }
    }
    private float Angle(Vector3 v)
    {
        var ang = Mathf.Asin(v.y) * Mathf.Rad2Deg;
        if (v.x < 0)
        {
            ang = 180 - ang;
        }
        if (v.y < 0)
        {
            ang = 360 + ang;
        }
        return ang;
    }
        void Shoot()
    {
        
        GameObject bullet = Instantiate(currentGun, firePoint.position, firePoint.rotation);
       // Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
       // rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
