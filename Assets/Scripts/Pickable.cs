using UnityEngine;

public class Pickable : MonoBehaviour
{
    [SerializeField]
    private int abilityHeld;
    private RuneLight runelight;

    private bool isInRange;
    private PlayerMovement player;
    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        runelight = GetComponent<RuneLight>();
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
        if (isInRange)
        {
            Inventory.InventoryInstace.SwapWeapon(abilityHeld);
            runelight.PlayRuneAnim(800, 4);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = true;
            runelight.SetLight(30, 1f);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
            runelight.SetLight(runelight.idleIntensity, 1f);
        }
    }

}
