using UnityEngine;

public class OnBulletCollision : MonoBehaviour
{
    [SerializeField]
    private int dmg;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    { 
     switch (collision.tag) {
            case "Wall":
            Destroy(gameObject);
                break;
            case "Enemy":
                break;
            case "Player":
                collision.GetComponent<LiveBody>().TakeDamage(dmg);
                Destroy(gameObject);
                break;
        }
    }
}
