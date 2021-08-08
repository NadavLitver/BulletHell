using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    [SerializeField]
    float timeBetweenPickupSpawn = 7;

    [SerializeField]
    List<GameObject> pickups;

    float maxX = 10;
    float maxY = 4.5f;
    void Start()
    {
        InvokeRepeating("Spawn", 0, timeBetweenPickupSpawn);
    }

    void Spawn()
    {
        int RandomPickupNum = Randomizer.ReturnRandomNum(0,pickups.Count);
        Debug.Log(RandomPickupNum);
        GameObject curPickup = pickups[RandomPickupNum];
        float PosX = Randomizer.ReturnRandomFloat(-maxX, maxX);
        float PosY = Randomizer.ReturnRandomFloat(-maxY, maxY);
        curPickup.transform.position = new Vector2(PosX, PosY);
        curPickup.SetActive(true);


    }
}
