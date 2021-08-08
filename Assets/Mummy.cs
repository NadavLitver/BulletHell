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
    
   
    protected override void OnLiveBodyEnable()
    {
        base.OnLiveBodyEnable();
        ai = GetComponent<IAstarAI>();
        destinationSetter = GetComponent<AIDestinationSetter>();
        animator = GetComponentInChildren<Animator>();
        throwCooldownRunning = ThrowCD;
        destinationSetter.target = FindObjectOfType<Target>().transform;
        target = destinationSetter.target;
    }
    private void Update()
    {
        if (target == null)
        {
            return;
        }
        if (Vector2.Distance(transform.position, target.position) <= DistanceToThrow)
        {
            ai.canMove = false;

            if (!isThrowing && canThrow)
            {
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
        GameObject bullet = BulletPool.bp_instace.GetBullet();
        bullet.transform.position = transform.position;
        bullet.transform.rotation = transform.rotation;
        bullet.GetComponent<Bullet>().SetMovement(direction);
        bullet.SetActive(true);
        isThrowing = false;
         

    }

    protected override void AfterTakeDamage()
    {
    }
}
