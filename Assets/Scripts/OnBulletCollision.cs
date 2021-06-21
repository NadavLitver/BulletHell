using UnityEngine;

public class OnBulletCollision : MonoBehaviour
{
    [SerializeField]
    private int dmg;

    [SerializeField]
    private GameObject bulletDead;
    private void OnEnable()
    {
        bulletDead.SetActive(false);
    }

    //public AttachGameObjectsToParticles parentref;
    private void OnTriggerEnter2D(Collider2D collision)
    { 
     switch (collision.tag) {

            case "Wall":
                bulletDead.SetActive(true);
                bulletDead.transform.parent = null;
                Destroy(gameObject);
                break;
            case "Enviroment":
                bulletDead.SetActive(true);
                bulletDead.transform.parent = null; 
                Destroy(gameObject);
                break;
            case "Enemy":
                collision.GetComponent<LiveBody>().TakeDamage(dmg);
                bulletDead.SetActive(true);
                bulletDead.transform.parent = null;
                Destroy(gameObject);
                break;
            case "Player":
                collision.GetComponent<LiveBody>().TakeDamage(dmg);
                bulletDead.SetActive(true);
                bulletDead.transform.parent = null;
                Destroy(gameObject);
                break;
        }
    }
 
}
