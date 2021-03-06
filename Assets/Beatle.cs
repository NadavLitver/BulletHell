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
     void LookAtPlayer()
    {
        float angle = Mathf.Atan2(destinationSetter.target.position.y - transform.position.y, destinationSetter.target.position.x - transform.position.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle - 90f));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime) ;

    }
}

