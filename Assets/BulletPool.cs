using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool bp_instace;

    [SerializeField]
    private GameObject pooledBullet;

    public bool notEnoughBulletsInPool = false;

    List<GameObject> bullets;

    private void Awake()
    {
        bp_instace = this;
        bullets = new List<GameObject>();
    }
    // Start is called before the first frame update
    void Start()
    {
       
        CreateStartingPool();
    }

    public GameObject GetBullet()
    {
        if (AmountOfInactiveBullets() > 1)
        {
            notEnoughBulletsInPool = false;
        }
        else
        {
            notEnoughBulletsInPool = true;
        }
        if (bullets.Count > 0)
        {
            for (int i = 0; i < bullets.Count; i++)
                if (!bullets[i].activeInHierarchy)
                    return bullets[i];

        }
     
        if (notEnoughBulletsInPool)
        {
            return CreateAndAddToList();

        }
        return null;
    }

    private GameObject CreateAndAddToList()
    {
        GameObject b = Instantiate(pooledBullet, transform, true);
        b.SetActive(false);
        bullets.Add(b);
        return b;
    }

    int AmountOfInactiveBullets()
    {
        int amount = 0;
        for (int i = 0; i < bullets.Count; i++)
        {

            if (!bullets[i].activeInHierarchy)
            {
                amount++;
            }
        }
        return amount;
    }
    void CreateStartingPool()
    {
        for (int i = 0; i < 100; i++)
        {
            CreateAndAddToList();
        }
    }
}
    
