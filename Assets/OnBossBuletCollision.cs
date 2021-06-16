using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBossBuletCollision : MonoBehaviour
{
    [SerializeField]
    private int dmg;



    //public AttachGameObjectsToParticles parentref;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {

            case "Wall":
                gameObject.SetActive(false);
                break;
            case "Enviroment":
                gameObject.SetActive(false);
                break;
            case "Player":
                collision.GetComponent<LiveBody>().TakeDamage(dmg);
                gameObject.SetActive(false);
                break;
        }
    }

}
