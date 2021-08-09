using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossThirdPhase : State
{
    [SerializeField]
    private GameObject BeatleType;
    [SerializeField]
    private GameObject MummyType;

    [SerializeField] private List<SarcHandler> m_Lsacs;
    [SerializeField] private List<SarcHandler> m_Rsacs;
    public float TimeBetweenEnemy;

    [SerializeField] protected GameObject LwavePattern;
    [SerializeField] protected GameObject RwavePattern;
    [SerializeField] protected GameObject LlinePattern;
    [SerializeField] protected GameObject RlinePattern;
    [SerializeField] protected GameObject LZigZagPattern;
    [SerializeField] protected GameObject RZigZagPattern;
    [SerializeField] protected GameObject RCirclePattern;
    [SerializeField] protected GameObject LCirclePattern;
    [SerializeField] protected GameObject LxShapePattern;
    [SerializeField] protected GameObject RxShapePattern;

    [SerializeField] private int amountOfPatterns = 5;
    [SerializeField] private float timeBetweenAttacks;
    bool isSummon;

    protected override void StateOnEnable()
    {
        isSummon = false;
        boss.isVulnerable = true;
        base.StateOnEnable();
        boss.SixtyFivePercent.AddListener(CallSummon);
        boss.FiftyPercentEvent.AddListener(CallSwapState);
        StartCoroutine(ChoosePattern());

    }
    IEnumerator ChoosePattern()
    {
        yield return new WaitForSeconds(timeBetweenAttacks);


        StartCoroutine(PatternDelay(LwavePattern, RwavePattern));
        yield return new WaitForSeconds(timeBetweenAttacks * 2);
        StartCoroutine(PatternDelay(LlinePattern, RlinePattern));
        yield return new WaitForSeconds(timeBetweenAttacks * 2);
        StartCoroutine(PatternDelay(LZigZagPattern, RZigZagPattern));
        yield return new WaitForSeconds(timeBetweenAttacks * 2);
        StartCoroutine(PatternDelay(LCirclePattern, RCirclePattern));
        yield return new WaitForSeconds(timeBetweenAttacks * 2);
        StartCoroutine(PatternDelay(LxShapePattern, RxShapePattern));
        yield return new WaitForSeconds(timeBetweenAttacks * 2);
        StartCoroutine(PatternDelay(LwavePattern, RwavePattern));
        yield return new WaitForSeconds(timeBetweenAttacks * 2);
        StartCoroutine(PatternDelay(LlinePattern, RlinePattern));
        yield return new WaitForSeconds(timeBetweenAttacks * 2);
        StartCoroutine(PatternDelay(LZigZagPattern, RZigZagPattern));
        yield return new WaitForSeconds(timeBetweenAttacks * 2);
        StartCoroutine(PatternDelay(LCirclePattern, RCirclePattern));
        yield return new WaitForSeconds(timeBetweenAttacks * 2);
        StartCoroutine(PatternDelay(LxShapePattern, RxShapePattern));
        yield return new WaitForSeconds(timeBetweenAttacks * 2);
        StartCoroutine(PatternDelay(LwavePattern, RwavePattern));
        yield return new WaitForSeconds(timeBetweenAttacks * 2);
        StartCoroutine(PatternDelay(LlinePattern, RlinePattern));
        yield return new WaitForSeconds(timeBetweenAttacks * 2);
        StartCoroutine(PatternDelay(LZigZagPattern, RZigZagPattern));

    }
    IEnumerator PatternDelay(GameObject lP, GameObject rP)
    {
        Attack();
        lP.SetActive(true);
        yield return new WaitForSeconds(timeBetweenAttacks);
        lP.SetActive(false);
        rP.SetActive(true);
        yield return new WaitForSeconds(timeBetweenAttacks + 0.5f);
        rP.SetActive(false);
    }
    private void Attack()
    {
        animator.SetTrigger("Shoot");
        PlayAttackSound();
    }

    private void PlayAttackSound()
    {
        AudioManager.am.PlaySound(AudioManager.am.boss_Attack, 1);
    }
    protected override void CallSwapState()
    {
        base.CallSwapState();
    }

    private void CallSummon()
    {
        if(!isSummon)
            StartCoroutine(SummonEnemy());
        isSummon = true;
    }
    IEnumerator SummonEnemy()
    {
        for (int i = 0; i < 1; i++)
        {
            for (int j = 0; j < m_Lsacs.Count; j++)
            {
                m_Lsacs[j].Open();
                yield return new WaitForSeconds(TimeBetweenEnemy / 2);
                m_Lsacs[j].Spawn(MummyType);
                yield return new WaitForSeconds(TimeBetweenEnemy / 2);
                m_Lsacs[j].Close();
            }
            for (int j = 0; j < m_Rsacs.Count; j++)
            {
                m_Rsacs[j].Open();
                yield return new WaitForSeconds(TimeBetweenEnemy / 2);
                m_Rsacs[j].Spawn(MummyType);
                yield return new WaitForSeconds(TimeBetweenEnemy / 2);
                m_Rsacs[j].Close();
            }
        }
            

            yield return new WaitForSeconds(TimeBetweenEnemy);

        for (int i = 0; i < 1; i++)
        {
            for (int j = 0; j < m_Rsacs.Count; j++)
            {
                m_Rsacs[j].Open();
                yield return new WaitForSeconds(TimeBetweenEnemy / 2);
                m_Rsacs[j].Spawn(BeatleType);
                yield return new WaitForSeconds(TimeBetweenEnemy / 2);
                m_Rsacs[j].Close();

            }
            for (int j = 0; j < m_Lsacs.Count; j++)
            {
                m_Lsacs[j].Open();
                yield return new WaitForSeconds(TimeBetweenEnemy / 2);
                m_Lsacs[j].Spawn(BeatleType);
                yield return new WaitForSeconds(TimeBetweenEnemy / 2);
                m_Lsacs[j].Close();
            }
        }


    }
    private void OnDisable()
    {
        boss.SixtyFivePercent.RemoveListener(CallSummon);
        boss.FiftyPercentEvent.RemoveListener(CallSwapState);
        StopAllCoroutines();
    }
}

    

