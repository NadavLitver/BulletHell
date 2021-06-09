using UnityEngine;

public class OnBulletCollision : MonoBehaviour
{
    [SerializeField]
    private int dmg;

    //public AttachGameObjectsToParticles parentref;
    private void OnTriggerEnter2D(Collider2D collision)
    { 
     switch (collision.tag) {

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
 
}
