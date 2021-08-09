﻿using System.Collections;
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

    private Vector3 m_scale;

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
        target = destinationSetter.target;

        m_scale = transform.localScale;
        
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
        transform.localScale = new Vector2(target.transform.position.x > transform.position.x ? -1 : 1 * m_scale.x, m_scale.y);
        UpdateAnimator();
    }

    private void UpdateAnimator()
    {
        Vector2 dir = (transform.position - target.position).normalized;
        animator.SetFloat("x", dir.x);
        animator.SetFloat("y", dir.y);
    }

    IEnumerator Throw(Vector2 direction)
    {
        AudioManager.am.PlaySound(AudioManager.am.mummy_Attack, 0.15f, true, 0.1f);
        animator.SetTrigger("Throw");
        isThrowing = true;
        throwCooldownRunning = 0;
        canThrow = false;
        yield return new WaitForSeconds(.6f);
        GameObject bullet = BulletPool.bp_instace.GetBullet();
        bullet.transform.position = transform.position;
        bullet.transform.rotation = transform.rotation;
        bullet.GetComponent<Bullet>().SetMovement(direction);
        bullet.SetActive(true);
        bullet.transform.position = bulletPivot.position;
        isThrowing = false;
         

    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        if (hp <= 0)
        {
            m_effects.OnDeath();
            AudioManager.am.PlaySound(AudioManager.am.mummy_Death, 0.5f);
        }
        else
        {
            m_effects.TakeDamage(damage);
            AudioManager.am.PlaySound(AudioManager.am.mummy_Hit, 0.25f, true, 0.2f);
        }

    }

    protected override void AfterTakeDamage()
    {
    }
}
