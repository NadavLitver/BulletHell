using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LiveBody : MonoBehaviour
{

    public int hp;
    public bool isVulnerable = true;
 
    public virtual void TakeDamage(int damage)
    {
        if(isVulnerable){hp -= damage;}
        if(hp <= 0)
        {
            Debug.Log(gameObject.name + " is Dead");
            Destroy(gameObject,0.1f);
        }
        AfterTakeDamage();
    }
    protected abstract void AfterTakeDamage();
  
}
