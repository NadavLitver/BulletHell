using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Boss : LiveBody
{
    [SerializeField] private BossHitEffect m_hitEffect;

    public UnityEvent EightyPercentEvent;
    public UnityEvent SixtyFivePercent;
    public UnityEvent FiftyPercentEvent;
    public UnityEvent ThirtyPercentEvent;
    public UnityEvent TenPercentEvent;

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
            animator.SetTrigger("Dead");
        }
        else
        {
            AudioManager.am.PlaySound(AudioManager.am.boss_Hit, 0.25f, true, 0.1f);
        }
        if (maxHP * 0.8f >= hp)
        {
            EightyPercentEvent?.Invoke();
        }
        if (maxHP * 0.65f >= hp)
        {
            SixtyFivePercent?.Invoke();
        }
        if (maxHP * 0.5f >= hp)
        {
            FiftyPercentEvent?.Invoke();
        }
        if (maxHP * 0.3f >= hp)
        {
            ThirtyPercentEvent?.Invoke();
        }
        if (maxHP * 0.1f >= hp)
        {
            TenPercentEvent?.Invoke();
        }
    }
 
   
   
}
