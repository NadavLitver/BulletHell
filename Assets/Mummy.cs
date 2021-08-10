﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class Mummy : LiveBody
{
    IAstarAI ai;
    AIDestinationSetter destinationSetter;
    public float DistanceToThrow;
    public float bulletSpeed;
    private float throwCooldownRunning;
    public float ThrowCD;
    private bool isThrowing;
    private bool canThrow;


    [SerializeField] private EnemyHitAndDeadEffect m_effects;

    [SerializeField] private Transform bulletPivot;
   
    protected override void OnLiveBodyEnable()
    {
        base.OnLiveBodyEnable();
        ai = GetComponent<IAstarAI>();
        destinationSetter = GetComponent<AIDestinationSetter>();
        animator = GetComponentInChildren<Animator>();
        throwCooldownRunning = ThrowCD;
        destinationSetter.target = FindObjectOfType<Target>().transform;
    }
    private void Update()
    {
        if (destinationSetter.target == null || GameManager.gm.isPaused)
        {
            return;
        }
        UpdateAnimator();
        if (Vector2.Distance(transform.position, destinationSetter.target.position) <= DistanceToThrow)
        {
            ai.canMove = false;

            if (!isThrowing && canThrow)
            {
                StartCoroutine(Throw());
                Debug.Log("Reached");
            }
            

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

    private void UpdateAnimator()
    {
        if(animator != null)
        {
            Vector2 dir = (destinationSetter.target.position - transform.position).normalized;
            animator.SetFloat("x", dir.x);
            animator.SetFloat("y", dir.y);
        }
      
    }

    IEnumerator Throw()
    {
        if(this!= null)
        {
            Vector2 dir = (destinationSetter.target.position - transform.position).normalized;
            AudioManager.am.PlaySound(AudioManager.am.mummy_Attack, 0.25f, true, 0.1f);
            if (animator != null)
                animator.SetTrigger("Throw");
            isThrowing = true;
            throwCooldownRunning = 0;
            canThrow = false;
            yield return new WaitForSeconds(.15f);
            GameObject bullet = BulletPool.bp_instace.GetBullet();
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            bullet.GetComponent<Bullet>().SetMovement(dir);
            bullet.SetActive(true);
            if(bulletPivot != null)
                bullet.transform.position = bulletPivot.position;

            
            isThrowing = false;
        }
        


    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        if (hp <= 0)
        {
            m_effects.OnDeath();
            AudioManager.am.PlaySound(AudioManager.am.mummy_Death, 0.35f);
        }
        else
        {
            m_effects.TakeDamage(damage);
            AudioManager.am.PlaySound(AudioManager.am.mummy_Hit, 0.2f, true, 0.1f);
        }

    }

    protected override void AfterTakeDamage()
    {
    }
}
