using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    [SerializeField]
    float timeBetweenPickupSpawn = 7;

    [SerializeField]
    List<GameObject> pickups;

    float maxX = 11;
    float maxY = 6.5f;
    void Start()
    {
        InvokeRepeating("Spawn", 0, timeBetweenPickupSpawn);
    }

    void Spawn()
    {
        for (int i = 0; i < pickups.Count; i++)
        {
            if (pickups[i].activeInHierarchy)
            {
                if(!pickups[i].GetComponent<Pickable>().Picked)
                    pickups[i].GetComponent<RuneLight>().PlayRuneAnim(100, 1f);
                
            }
        }
        int RandomPickupNum = Randomizer.ReturnRandomNum(0,pickups.Count);
        Debug.Log(RandomPickupNum);
        GameObject curPickup = pickups[RandomPickupNum];
        float PosX = Randomizer.ReturnRandomFloat(-maxX, maxX);
        float PosY = Randomizer.ReturnRandomFloat(-maxY, maxY);
        curPickup.transform.position = new Vector2(PosX, PosY);
        curPickup.SetActive(true);


    }
}
