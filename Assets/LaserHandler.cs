using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserHandler : MonoBehaviour
{
    [SerializeField] private Collider2D m_col;
    [SerializeField] private int damage;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<LiveBody>().TakeDamage(damage);
            OnHit();
        }
        
    }
    private void OnHit()
    {
        StartCoroutine(OnHitRoutine());
    }
    private IEnumerator OnHitRoutine()
    {
        m_col.enabled = false;
        yield return new WaitForSeconds(0.5f);
        m_col.enabled = true;
    }
}
