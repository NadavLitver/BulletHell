using UnityEngine;

public class Pickable : MonoBehaviour
{
    [SerializeField]
    private int abilityHeld;
    private RuneLight runelight;

    private bool isInRange;
    public bool Picked;

    private PlayerMovement player;
    private void OnEnable()
    {
        Picked = false;
        if (player == null)
        {
            player = FindObjectOfType<PlayerMovement>();
        }
        if (runelight == null)
        {
            runelight = GetComponent<RuneLight>();
        }
        runelight.SetLight(runelight.idleIntensity, 0.5f);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            PickUp();
        }
    }
    void PickUp()
    {
        if (isInRange && !Picked)
        {
            Picked = true;
            Inventory.InventoryInstace.SwapWeapon(abilityHeld);
            runelight.PlayRuneAnim(100, 1.5f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !Picked)
        {
            isInRange = true;
            runelight.SetLight(30, 1f);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") &&!Picked)
        {
            isInRange = false;
            if (!Picked)
            {
                runelight.SetLight(runelight.idleIntensity, 1f);
            }
        }
    }
    private void OnDisable()
    {
        Picked = false;
    }

}
