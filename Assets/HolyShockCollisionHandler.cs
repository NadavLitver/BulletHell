using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolyShockCollisionHandler : MonoBehaviour
{
    [SerializeField]
    private int dmg;
    [SerializeField]
    private GameObject death;
    private void OnEnable()
    {
        if (death != null)
            death.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {

            case "Wall":
                OnHit();

                break;
            case "Enviroment":
                OnHit();

                break;
            case "Enemy":
                collision.GetComponent<LiveBody>().TakeDamage(dmg);
                OnHit();
                break;
            case "Player":
                collision.GetComponent<LiveBody>().TakeDamage(dmg);
                OnHit();
                break;
        }
    }
    private void OnHit()
    {
        death.SetActive(true);
        death.transform.parent = null;
        gameObject.SetActive(false);
    }

}
