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
    private Transform handPoint;

    [SerializeField]
    private Collider2D bodyCollider;

    [SerializeField]
    private SpriteRenderer sr;

    [SerializeField]
    private GameObject holyShock;

    [SerializeField]
    private KeyCode shootButton;

    [SerializeField]
    private KeyCode TeleportButton;

    [SerializeField]
    private KeyCode SpecialButton;

    [SerializeField]
    private float chargeTimeForRetribution;

    private GameObject CurSpecial;
    public float teleSpeed;
    private Vector2 mousePos;
    private Vector2 dir;
    private float holyShockTimer;
    private float teleportTimer;
    public bool specialKeyPressing;
    public float specialKeyDownCounter;
    public float holyShockCD;
    public float teleportCD;

    [SerializeField] private PlayerRuneLight runeLight;


    float recoilAmount = 20;
    [SerializeField]
    public float recoilCounter = 0;

    void Update()
    {
        GetWorldMousePos();
        GetFirePointDirNor();
        SetFirePointRotation();
        HolyShockCDTimer();
        TeleportCDTimer();
        SpecialCDTimer();
        CountSpecialKeyTime();

        if(recoilCounter > 0) 
              recoilCounter -= Time.deltaTime;
       
    }

  

    private void SpecialCDTimer()
    {
        if (Inventory.InventoryInstace.specialAbility != null)
        {
            if (Inventory.InventoryInstace.specialAbility.runningCD <= Inventory.InventoryInstace.specialAbility.cooldown)
            {
                Inventory.InventoryInstace.specialAbility.runningCD += Time.deltaTime;
            }
            else
            {
                GetInputSpecial();

            }
        }
    }

    private void TeleportCDTimer()
    {
        if (teleportTimer <= teleportCD)
        {
            teleportTimer += Time.deltaTime;
        }
        else
        {
            GetInputTeleport();
        }
    }

    private void HolyShockCDTimer()
    {
        if (holyShockTimer <= holyShockCD)
        {
            holyShockTimer += Time.deltaTime;
        }
        else
        {
            GetInputShoot();
        }
    }
    #region specialInput
    void GetInputSpecial()
    {
       
            if (Inventory.InventoryInstace.specialAbility.isGetKeyDown)
            {
                if (Input.GetKeyDown(SpecialButton))
                {
                  Inventory.InventoryInstace.specialAbility.runningCD = 0;
                  UseSpecialAbility();
                   
                }
            }
            else
            {

            CheckSpecialKeyDown();
            CheckSpecialKeyUp();
            }


    }
   

    private void CheckSpecialKeyDown()
    {
        if (Input.GetKeyDown(SpecialButton) && !Inventory.InventoryInstace.specialAbility.isChargingReq)
        {
            UseSpecialAbility();
            if (CurSpecial != null)
            {
                CurSpecial.GetComponent<Animator>().SetBool("PlayEmission", true);
            }

        }else if(Input.GetKeyDown(SpecialButton) && Inventory.InventoryInstace.specialAbility.isChargingReq)
        {
            specialKeyPressing = true;
            playermove.canMove = false;
        }
    }
    private void CountSpecialKeyTime()
    {
        if (playermove.canMove == false)
        {
            if (specialKeyPressing)
            {
                 specialKeyDownCounter += Time.deltaTime;
                
                if (specialKeyDownCounter >= chargeTimeForRetribution)
                {
                    UseSpecialAbility();
                    specialKeyPressing = false;
                    Inventory.InventoryInstace.specialAbility.runningCD = 0;
                    CurSpecial.GetComponent<Animator>().SetBool("PlayEmission", true);


                }

            }

            if (specialKeyDownCounter >= chargeTimeForRetribution + 2)
            {


                specialKeyDownCounter = 0;
                playermove.canMove = true;

            }
        } 
          
    }
    private void CheckSpecialKeyUp()
    {
        if (Input.GetKeyUp(SpecialButton))
        {
            specialKeyPressing = false;
            playermove.canMove = true;
            if (CurSpecial != null)
            {
                CurSpecial.GetComponent<Animator>().SetBool("PlayEmission", false);
                Inventory.InventoryInstace.specialAbility.runningCD = 0;
                specialKeyDownCounter = 0;
                Destroy(CurSpecial.gameObject, 0.5f);
            }
         
        }
    }
    #endregion


    #region baseInputs
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
    #endregion
    private IEnumerator Teleport()
    {
        playermove.canMove = false;
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


    private float Angle(Vector2 v)
    {
        //return Vector2.SignedAngle(Vector2.up, v) + 90; // Use this Nadav of the future
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
        if(recoilCounter < 4)
           recoilCounter += 0.5f;

        Vector2 shootDir = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y).normalized;
        if(recoilCounter >= 2)
        {
            GameObject bullet = Instantiate(holyShock, handPoint.position, Quaternion.Euler(Quaternion.identity.x, Quaternion.identity.y, Quaternion.identity.z + Randomizer.ReturnRandomFloat(-recoilAmount,recoilAmount)));
            bullet.GetComponent<Bullet>().SetMovement(shootDir);

        }
        else
        {
            GameObject bullet = Instantiate(holyShock, handPoint.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().SetMovement(shootDir);

        }
        runeLight.PlayRuneAnim(1000, 1.5f);
    }
    GameObject UseSpecialAbility()
    {
        GameObject specialBullet = Instantiate(Inventory.InventoryInstace.curAbilityPrefab, handPoint.position, firePoint.rotation);
        runeLight.PlayRuneAnim(1000, 1.5f);
        if (!Inventory.InventoryInstace.specialAbility.isGetKeyDown)
        {
            specialBullet.transform.parent = firePoint.transform;
        }
        CurSpecial = specialBullet;
        return specialBullet;
    }
}
