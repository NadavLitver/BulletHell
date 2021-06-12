using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class Mummy : LiveBody
{
    IAstarAI ai;
    AIDestinationSetter destinationSetter;
    private Transform target;
    public float DistanceToThrow;
    public float bulletSpeed;
    private float throwCooldownRunning;
    public float ThrowCD;
    private bool isThrowing;
    private bool canThrow;
    
    [SerializeField]
    private GameObject BulletPrefab;
    private void OnEnable()
    {
        ai = GetComponent<IAstarAI>();
        destinationSetter = GetComponent<AIDestinationSetter>();
        animator = GetComponentInChildren<Animator>();
        target = destinationSetter.target;
        throwCooldownRunning = ThrowCD;

    }
    private void Update()
    {
        if (Vector2.Distance(transform.position, target.position) <= DistanceToThrow)
        {
            if (!isThrowing && canThrow)
            {
                ai.canMove = false;
                Vector2 dir = (target.position - transform.position).normalized;
                StartCoroutine(Throw(dir));
                Debug.Log("Reached");
            }
            return;

        }
        else
        {
            if (!isThrowing)
            {
                ai.canMove = true;

            }
        }
        if(throwCooldownRunning <= ThrowCD)
        {
            throwCooldownRunning += Time.deltaTime;

        }
        else
        {
            canThrow = true;
        }
    }
    IEnumerator Throw(Vector2 direction)
    {

        isThrowing = true;
        animator.SetTrigger("Throw");
        throwCooldownRunning = 0;
        canThrow = false;
        yield return new WaitForSeconds(1f);
        GameObject bullet =  Instantiate(BulletPrefab, transform.position, transform.rotation);
        bullet.GetComponent<MummyOrb>().velocity = direction * bulletSpeed; 
        isThrowing = false;
         

    }

    protected override void AfterTakeDamage()
    {
    }
}
