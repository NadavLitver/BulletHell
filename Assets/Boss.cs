using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : LiveBody
{
    [SerializeField] private BossHitEffect m_hitEffect;

    protected override void OnLiveBodyEnable()
    {
        base.OnLiveBodyEnable();
    }

    protected override void AfterTakeDamage()
    {
       
    }
    public override void TakeDamage(int damage)
    {
        m_hitEffect.TakeDamage(damage);
        base.TakeDamage(damage);
    }



}
