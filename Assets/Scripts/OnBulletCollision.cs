using UnityEngine;

public class OnBulletCollision : MonoBehaviour
{
    [SerializeField]
    private int dmg;

    public AttachGameObjectsToParticles parentref;
    private void OnTriggerEnter2D(Collider2D collision)
    { 
     switch (collision.tag) {
            case "Wall":
                Destroy(gameObject);
                break;
            case "Enemy":
                break;
            case "Player":
                //parentref.RemoveFromList(gameObject);
                collision.GetComponent<LiveBody>().TakeDamage(dmg);
                Destroy(gameObject);
               // GetComponentInParent<AttachGameObjectsToParticles>().RemoveFromList(gameObject);
                break;
        }
    }
 
}
