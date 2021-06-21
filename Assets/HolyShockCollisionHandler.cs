using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolyShockCollisionHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject death;

    [SerializeField]
    private int dmg;

    private void OnEnable()
    {
        death.SetActive(false);
    }

    //public AttachGameObjectsToParticles parentref;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Wall":
                Destroy(gameObject);
                break;
            case "Enviroment":
                Destroy(gameObject);
                break;
            case "Enemy":
                collision.GetComponent<LiveBody>().TakeDamage(dmg);
                Destroy(gameObject);
                break;
            case "Player":
                collision.GetComponent<LiveBody>().TakeDamage(dmg);
                Destroy(gameObject);
                break;
        }
    }
    private void OnDisable()
    {
        death.SetActive(true);
        death.transform.parent = null;
    }
}
