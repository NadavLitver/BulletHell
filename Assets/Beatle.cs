using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beatle : LiveBody
{
    IAstarAI ai;
    AIDestinationSetter destinationSetter;
    public int damage;
    [SerializeField]
    private float rotationSpeed;
    [SerializeField] private EnemyHitAndDeadEffect m_effects;
  
    protected override void OnLiveBodyEnable()
    {
        base.OnLiveBodyEnable();
        ai = GetComponent<IAstarAI>();
        destinationSetter = GetComponent<AIDestinationSetter>();
        animator = GetComponentInChildren<Animator>();
        destinationSetter.target = FindObjectOfType<Target>().transform;
    }
    private void Update()
    {
        if (ai.reachedDestination)
        {
            Debug.Log("Reached");
            
        }
        LookAtPlayer();


    }
    protected override void AfterTakeDamage()
    {
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(animator != null)
                animator.SetTrigger("Explode");
            collision.gameObject.GetComponent<LiveBody>().TakeDamage(damage);
            Destroy(gameObject, 1f);
            this.enabled = false;
        }
    }
     void LookAtPlayer()
    {
        if (destinationSetter == null)
        {
            return;
        }
        float angle = Mathf.Atan2(destinationSetter.target.position.y - transform.position.y, destinationSetter.target.position.x - transform.position.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle - 90f));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime) ;

    }
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        if (hp <= 0)
        {
            AudioManager.am.PlaySound(AudioManager.am.beatle_Death, 0.25f);
            m_effects.OnDeath();
        }
        else
        {
            AudioManager.am.PlaySound(AudioManager.am.beatle_hit, 0.2f, true, 0.1f);
            m_effects.TakeDamage(damage);
        }
    }
}

