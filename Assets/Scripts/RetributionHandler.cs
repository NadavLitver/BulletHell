using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetributionHandler : MonoBehaviour
{
    [SerializeField]
    private int dmg;

    private void OnEnable()
    {
        AudioManager.am.PlaySound(AudioManager.am.Player_Retribution, 0.5f);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        LiveBody body = collision.GetComponent<LiveBody>();
        if (body != null)
        {
            body.TakeDamage(dmg);
        }
    }
}
