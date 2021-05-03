using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    [SerializeField]
    private int abilityHeld;

    private PlayerMovement player;
    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
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
        if(Vector2.Distance(transform.position, player.transform.position) <= 0.9f)
        {
                Inventory.InventoryInstace.SwapWeapon(abilityHeld);
        }
    }

}
