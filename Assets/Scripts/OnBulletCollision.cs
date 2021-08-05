using UnityEngine;

public class OnBulletCollision : MonoBehaviour
{
    [SerializeField]
    private int dmg;
    [SerializeField]
    private GameObject death;
    private void OnEnable()
    {
        death.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    { 
     switch (collision.tag) {

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
            case "Boss":
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
