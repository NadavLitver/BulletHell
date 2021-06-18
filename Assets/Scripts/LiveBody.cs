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
            if (gameObject.CompareTag("Player"))
            {
                GameManager.gm.RestartScene();
            }
            Debug.Log(gameObject.name + " is Dead");
            Destroy(gameObject,0.1f);
        }
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
  
}
