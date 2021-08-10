using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LiveBody : MonoBehaviour
{

    public int hp;
    public bool isVulnerable = true;
    [SerializeField]
    protected Animator animator;
    protected int maxHP;
 
    public virtual void TakeDamage(int damage)
    {
        if(isVulnerable){hp -= damage;}
        if(hp <= 0)
        {
            OnDeath();
        }
        CamShake.instance.callCamShake(0.25f, (damage / 10));
        AfterTakeDamage();
    }
    private void OnEnable()
    {
        maxHP = hp;
        OnLiveBodyEnable();
    }
    protected virtual void OnLiveBodyEnable()
    {
      
    }
    protected abstract void AfterTakeDamage();
    void OnDeath()
    {
        GetComponent<Collider2D>().enabled = false;
        if (gameObject.CompareTag("Player"))
        {
            GameManager.gm.PlayerLost?.Invoke();

        }
        else if (gameObject.CompareTag("Boss"))
        {
            GameManager.gm.PlayerWon?.Invoke();

        }
        Debug.Log(gameObject.name + " is Dead");
        StopAllCoroutines();
        Destroy(gameObject, 1f);
    }
  
}
