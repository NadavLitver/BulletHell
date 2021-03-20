using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LiveBody : MonoBehaviour
{
    [SerializeField]
    protected int hp;
    public virtual void TakeDamage(int damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
            Debug.Log(gameObject.name + " is Dead");
        }
      StartCoroutine(SetPlayerHealthBar.SetHP(hp));
    }
}
