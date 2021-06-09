using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beatle : LiveBody
{
    IAstarAI ai;
    Animator animator;
    public int damage;
    private void OnEnable()
    {
        ai = GetComponent<IAstarAI>();
        animator = GetComponentInChildren<Animator>();

    }
    private void Update()
    {
        if (ai.reachedDestination)
        {
            Debug.Log("Reached");
        }
    }
    protected override void AfterTakeDamage()
    {
        //this.GetComponentInChildren<SpriteRenderer>().color = Color.red;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger("Explode");
            collision.gameObject.GetComponent<LiveBody>().TakeDamage(damage);
            Destroy(gameObject, 1f);
            this.enabled = false;
        }
    }
}

