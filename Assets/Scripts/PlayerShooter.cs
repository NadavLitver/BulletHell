using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement playermove;

    [SerializeField]
    private Transform firePoint;

    [SerializeField]
    internal Transform telePoint;

    [SerializeField]
    private GameObject[] guns;

    [SerializeField]
    private Collider2D bodyCollider;

    [SerializeField]
    private SpriteRenderer sr; 

    [SerializeField]
    private GameObject currentGun;

    [SerializeField]
    private KeyCode shootButton;

    [SerializeField]
    private KeyCode TeleportButton;

    public float teleSpeed;
    internal Vector2 curTelePos;
    private Vector2 mousePos;
    private Vector2 dir;
 
    // Update is called once per frame
    void Update()
    {
        GetWorldMousePos();
        GetFirePointDirNor();
        SetFirePointRotation();
        if (Input.GetKeyDown(shootButton))
        {
            Shoot();
        }
        if (Input.GetKeyDown(TeleportButton))
        {
           StartCoroutine(Teleport());
        }
    }
    private IEnumerator Teleport()
    {
        playermove.canMove = false;
        curTelePos = telePoint.position;
        playermove.isVulnerable = false;
        bodyCollider.enabled = false;
        playermove.isTeleport = true;
        sr.color = new Color(255, 255, 255, 0);
        yield return new WaitForSeconds(0.26f);
        playermove.isTeleport = false;
        playermove.isVulnerable = true;
        bodyCollider.enabled = true;
        sr.color = new Color(255, 255, 255, 255);
        yield return new WaitForSeconds(0.45f);
        playermove.canMove = true;
        yield break;
    }
    private void GetWorldMousePos()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    private void GetFirePointDirNor()
    {
        dir = new Vector2(mousePos.x - firePoint.position.x, mousePos.y - firePoint.position.y).normalized;
    }
    private void SetFirePointRotation()
    {
        firePoint.rotation = Quaternion.Euler(0, 0, Angle(dir));
        Debug.DrawRay(firePoint.position, dir);
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
    }
}
