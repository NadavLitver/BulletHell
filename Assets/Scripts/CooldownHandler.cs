using UnityEngine;
using UnityEngine.UI;

public class CooldownHandler : MonoBehaviour
{
    public Image cooldownImage;

    private bool inCooldown = false;
    private float cooldownTime;

    public KeyCode abilityKey;

    public PlayerShooter PlayerShooterInstance;

    [HideInInspector] public enum Abilities {AbilityOne, AbilityTwo, TeleportAbility };
    public Abilities abilitiesRef;


    private void Start()
    {
        cooldownImage.fillAmount = 0f;
    }

    private void Update()
    {
        switch (abilitiesRef)
        {
            case Abilities.AbilityOne:
                Holyshock();
                break;
            case Abilities.AbilityTwo:
                SpecialAbility();
                break;
            case Abilities.TeleportAbility:
                DoorOfLight();
                break;
            default:
                break;
        }
    }

    private void Holyshock()
    {
        if (inCooldown)
        {
            cooldownImage.fillAmount -= 1 / cooldownTime * Time.deltaTime;
            if (cooldownImage.fillAmount <= 0)
            {
                cooldownImage.fillAmount = 0;
                inCooldown = false;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            cooldownTime = PlayerShooterInstance.holyShockCD;
            if (!inCooldown)
            {
                inCooldown = true;
                cooldownImage.fillAmount = 1;
            }

        }
    }

    private void SpecialAbility()
    {
        if (inCooldown)
        {
            cooldownImage.fillAmount -= 1 / cooldownTime * Time.deltaTime;
            if (cooldownImage.fillAmount <= 0)
            {
                cooldownImage.fillAmount = 0;
                inCooldown = false;
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            cooldownTime = Inventory.InventoryInstace.specialAbility.runningCD;

            if (!inCooldown)
            {
                inCooldown = true;
                cooldownImage.fillAmount = 1;
            }
        }
    }

    private void DoorOfLight()
    {
        if (inCooldown)
        {
            cooldownImage.fillAmount -= 1 / cooldownTime * Time.deltaTime;
            if (cooldownImage.fillAmount <= 0)
            {
                cooldownImage.fillAmount = 0;
                inCooldown = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            cooldownTime = PlayerShooterInstance.teleportCD;
            if (!inCooldown)
            {
                inCooldown = true;
                cooldownImage.fillAmount = 1;
            }
        }
    }




}
