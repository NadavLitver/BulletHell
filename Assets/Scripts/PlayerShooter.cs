using System.Collections;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField]
    private TeleportEffect teleportEffect;

    [SerializeField]
    private PlayerMovement playerMovement;

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
    private GameObject AuraBurst;
    [SerializeField]
    private GameObject Penance;

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
    private bool isMachineGun = false;
    [SerializeField] private PlayerRuneLight runeLight;


    private float recoilCounter = 0;

    public float timeBetweenPenanceShots = 0.2f;

    void Update()
    {
        GetWorldMousePos();
        GetFirePointDirNor();
        SetFirePointRotation();
        HolyShockCDTimer();
        TeleportCDTimer();
        SpecialCDTimer();
        CountSpecialKeyTime();

        if (recoilCounter > 0)
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
                StartCoroutine(AuraBurstWave());

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
            isMachineGun = true;
            StartCoroutine("MachineGun");

        }
        else if (Input.GetKeyDown(SpecialButton) && Inventory.InventoryInstace.specialAbility.isChargingReq)
        {
            specialKeyPressing = true;
            playerMovement.canMove = false;
        }
    }
    private void CountSpecialKeyTime()
    {
        if (playerMovement.canMove == false)
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
                    StartCoroutine(callPlayerKnockbackDelayed(5, 1f));

                }

            }

            if (specialKeyDownCounter >= chargeTimeForRetribution + 2)
            {


                specialKeyDownCounter = 0;
                playerMovement.canMove = true;

            }
        }

    }
    private void CheckSpecialKeyUp()
    {
        if (Input.GetKeyUp(SpecialButton))
        {
            specialKeyPressing = false;
            isMachineGun = false;
            playerMovement.canMove = true;
            StopCoroutine("MachineGun");
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
        teleportEffect.Activate(playerMovement.myDir);
        playerMovement.canMove = false;
        playerMovement.isVulnerable = false;
        bodyCollider.enabled = false;
        playerMovement.isTeleport = true;
        sr.color = new Color(255, 255, 255, 0);
        yield return new WaitForSeconds(0.19f);
        playerMovement.isTeleport = false;
        playerMovement.isVulnerable = true;
        bodyCollider.enabled = true;
        sr.color = new Color(255, 255, 255, 255);
        yield return new WaitForSeconds(0.31f);
        playerMovement.canMove = true;
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
        if (recoilCounter < 4)
            recoilCounter += 0.5f;
        float ShootRecoilAmount = 10;

        Vector2 shootDir = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y).normalized;
        if (recoilCounter >= 2)
        {
            GameObject bullet = Instantiate(holyShock, handPoint.position, Quaternion.Euler(Quaternion.identity.x, Quaternion.identity.y, Quaternion.identity.z + Randomizer.ReturnRandomFloat(-ShootRecoilAmount, ShootRecoilAmount)));
            bullet.GetComponent<Bullet>().SetMovement(shootDir);
            bullet.GetComponent<Bullet>().speed *= 0.6f;


        }
        else
        {
            GameObject bullet = Instantiate(holyShock, handPoint.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().SetMovement(shootDir);
            bullet.GetComponent<Bullet>().speed *= 0.4f;

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
    IEnumerator AuraBurstWave()
    {
        callPlayerKnockback(5);

        yield return new WaitForSeconds(0.1f);

        float angle = ShotgunData.startAngle;

        for (int i = 0; i < ShotgunData.bulletAmount; i++)
        {

            float bulletDirX = handPoint.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulletDirY = handPoint.transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);
            Vector2 bulletMoveVector = new Vector2(bulletDirX, bulletDirY);
            Vector2 bulletDir = (bulletMoveVector - (Vector2)handPoint.position).normalized;

            GameObject bullet = Instantiate(AuraBurst, handPoint.position, firePoint.rotation);

            bullet.GetComponent<Bullet>().SetMovement(bulletDir);
            bullet.GetComponent<Bullet>().speed *= 0.8f;
            bullet.SetActive(true);
            angle += ShotgunData.angleStep;
        }

    }

    private void callPlayerKnockback(float knockbackForce)
    {
        Vector2 knockBackDir = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y).normalized * -1;

        playerMovement.CallPlayerKnockback(knockBackDir * knockbackForce);
    }
    private IEnumerator callPlayerKnockbackDelayed(float knockbackForce, float delay)
    {
        yield return new WaitForSeconds(delay);

        Vector2 knockBackDir = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y).normalized * -1;

        playerMovement.CallPlayerKnockback(knockBackDir * knockbackForce);
    }

    IEnumerator MachineGun()
    {
        while (isMachineGun)
        {
            if (recoilCounter < 4)
                recoilCounter += 0.5f;
            float ShootRecoilAmount = 10;

            Vector2 shootDir = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y).normalized;
            if (recoilCounter >= 1)
            {
                if (recoilCounter >= 2)
                {
                    ShootRecoilAmount = 20;
                }
                else if (recoilCounter >= 3)
                {
                    ShootRecoilAmount = 30;
                }
                GameObject bullet = Instantiate(Penance, handPoint.position, Quaternion.Euler(Quaternion.identity.x, Quaternion.identity.y, Quaternion.identity.z + Randomizer.ReturnRandomFloat(-ShootRecoilAmount, ShootRecoilAmount)));
                bullet.GetComponent<Bullet>().SetMovement(shootDir);


            }
            else
            {
                GameObject bullet = Instantiate(Penance, handPoint.position, Quaternion.identity);
                bullet.GetComponent<Bullet>().SetMovement(shootDir);

            }
            runeLight.PlayRuneAnim(1000, 1.5f);
            yield return new WaitForSeconds(timeBetweenPenanceShots);

        }
        yield return null;
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }
}

internal static class ShotgunData
{
    internal static int bulletAmount = 4;
    internal static float startAngle = 80f;
    internal static float endAngle = 120f;
    internal static float angleStepTemp = (endAngle - startAngle);
    internal static float angleStep = angleStepTemp / bulletAmount;
}
