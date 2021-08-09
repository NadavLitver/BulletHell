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
        if (hp <= 0)
        {
            AudioManager.am.PlaySound(AudioManager.am.boss_Death, 1);
        }
        else
        {
            AudioManager.am.PlaySound(AudioManager.am.boss_Hit, 0.1f, true,0.05f);
        }
    }



}
