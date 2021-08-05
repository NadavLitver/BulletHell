using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory InventoryInstace;

    public GameObject[] abilities;

    public GameObject curAbilityPrefab;

    public Ability specialAbility;
    private void Awake()
    {
        InventoryInstace = this;
        SwapWeapon(2);
    }
    public void SwapWeapon(int index)
    {
        curAbilityPrefab = abilities[index];
        specialAbility = curAbilityPrefab.GetComponent<Ability>();
        Debug.Log("CurWeapon is" + index);
    }
   
}
