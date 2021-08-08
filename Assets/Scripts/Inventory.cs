using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory InventoryInstace;

    public GameObject[] abilities;

    public GameObject curAbilityPrefab;

    public Ability specialAbility;

    public UIAbilitiesHandler uiHandler;
    private void Awake()
    {
        if (InventoryInstace ==null)
        {
            InventoryInstace = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        SwapWeapon(0);
    }
    public void SwapWeapon(int index)
    {
        curAbilityPrefab = abilities[index];
        specialAbility = curAbilityPrefab.GetComponent<Ability>();
        uiHandler.special_image.sprite = specialAbility.spriteForUI;
        Debug.Log("CurWeapon is" + index);
    }
   
}
