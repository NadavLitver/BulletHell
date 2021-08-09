﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserHandler : MonoBehaviour
{
    private Collider2D m_col;
    [SerializeField] private int damage;

    private void OnEnable()
    {
        m_col = GetComponent<Collider2D>();
        m_col.enabled = false;
    }


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
        yield return new WaitForSeconds(0.4f);
        m_col.enabled = true;
    }
}
