using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnRetributionStay : MonoBehaviour
{
    [SerializeField]
    private int dmg;
    private void OnTriggerStay2D(Collider2D collision)
    {
        LiveBody body = collision.GetComponent<LiveBody>();
        if (body != null)
        {
            body.TakeDamage(dmg);
        }
    }
}
