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
    private GameObject[] Abilities;

    [SerializeField]
    private Collider2D bodyCollider;

    [SerializeField]
    private SpriteRenderer sr;

    [SerializeField]
    private GameObject holyShock;

    [SerializeField]
    private GameObject specialAbilityPrefab;
   
    [SerializeField]
    private Ability specialAbility;

    [SerializeField]
    private KeyCode shootButton;

    [SerializeField]
    private KeyCode TeleportButton;

    [SerializeField]
    private KeyCode SpecialButton;

    public float teleSpeed;
    internal Vector2 curTelePos;
    private Vector2 mousePos;
    private Vector2 dir;
    private float holyShockTimer;
    private float teleportTimer;
    public float holyShockCD;
    public float teleportCD;
    // Update is called once per frame
    void Update()
    {
        GetWorldMousePos();
        GetFirePointDirNor();
        SetFirePointRotation();
       
       
        if(holyShockTimer <= holyShockCD)
        {
            holyShockTimer += Time.deltaTime;
        }
        else
        {
            GetInputShoot();
        }
        if (teleportTimer <= teleportCD)
        {
            teleportTimer += Time.deltaTime;
        }
        else
        {
            GetInputTeleport();
        }
        if(specialAbility.runningCD <= specialAbility.cooldown)
        {
            specialAbility.runningCD += Time.deltaTime;
        }
        else
        {
            GetInputSpecial();

        }


    }
    void GetInputSpecial()
    {
       
            if (specialAbility.isGetKeyDown)
            {
                if (Input.GetKeyDown(SpecialButton))
                {
                    UseSpecialAbility();
                    specialAbility.runningCD = 0;

                }
            }
            else
            {
              if (Input.GetKeyDown(SpecialButton))
              {
                Abilities[0].GetComponent<Animator>().SetBool("PlayEmission", true);
              }
              if (Input.GetKeyUp(SpecialButton))
              {
                Abilities[0].GetComponent<Animator>().SetBool("PlayEmission", false);
                specialAbility.runningCD = 0;
              }
            }


    }
    private void GetInputTeleport()
    {
        if (Input.GetKeyDown(TeleportButton))
        {
            StartCoroutine(Teleport());
            teleportTimer = 0;
        }
    }

    private void GetInputShoot()
    {
        if (Input.GetKeyDown(shootButton))
        {
            Shoot();
            holyShockTimer = 0;
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
        GameObject bullet = Instantiate(holyShock, firePoint.position, firePoint.rotation);
    }
    GameObject UseSpecialAbility()
    {
        GameObject specialBullet = Instantiate(specialAbilityPrefab, firePoint.position, firePoint.rotation);
        specialBullet.transform.parent = firePoint.transform;
        return specialBullet;
    }
}
