using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LiveBody : MonoBehaviour
{

    public int hp;
    public bool isVulnerable = true;
    [SerializeField]
    protected Animator animator;
 
    public virtual void TakeDamage(int damage)
    {
        if(isVulnerable){hp -= damage;}
        if(hp <= 0)
        {
            OnDeath();
        }
        CamShake.instance.callCamShake(0.25f, (damage / 100) * 3);
        AfterTakeDamage();
    }
    private void OnEnable()
    {
        OnLiveBodyEnable();
    }
    protected virtual void OnLiveBodyEnable()
    {
      
    }
    protected abstract void AfterTakeDamage();
    void OnDeath()
    {
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
        Destroy(gameObject, 0.2f);
    }
  
}
