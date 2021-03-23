using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartSystemColManager : MonoBehaviour
{
    [SerializeField]
    private int dmg;
    // Start is called before the first frame update
    private void OnParticleCollision(GameObject other)
    {
        Debug.Log(other.name + "hit");
        switch (other.tag)
        {
            case "Wall":
                break;
            case "Enemy":
                other.GetComponent<LiveBody>().TakeDamage(dmg);
                break;
            case "Player":
                other.GetComponent<LiveBody>().TakeDamage(dmg);
                break;
        }
    }
}
