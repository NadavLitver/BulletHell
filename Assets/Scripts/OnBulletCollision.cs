using UnityEngine;

public class OnBulletCollision : MonoBehaviour
{
    [SerializeField]
    private int dmg;
    [SerializeField]
    private GameObject death;
    //public AttachGameObjectsToParticles parentref;
    private void OnEnable()
    {
        if (death != null)
            death.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    { 
     switch (collision.tag) {

            case "Wall":
                gameObject.SetActive(false);
                break;
            case "Enviroment":
                gameObject.SetActive(false);
                break;
            case "Enemy":
                collision.GetComponent<LiveBody>().TakeDamage(dmg);
              //  Destroy(gameObject);
                break;
            case "Player":
                collision.GetComponent<LiveBody>().TakeDamage(dmg);
                gameObject.SetActive(false);
                break;
        }
    }
    private void OnDisable()
    {
        if (death != null)
        {
            death.SetActive(true);
            death.transform.parent = null;
        }
           


    }

}
