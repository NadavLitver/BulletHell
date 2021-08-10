using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSixPhase : State
{

    [SerializeField]
    private GameObject BeatleType;
    [SerializeField]
    private GameObject MummyType;
    public int amountOfMummyPerSummon;//2
    public int amountOfBeatlePerSummon;//1
    public float TimeBetweenEnemy;
    public float TimeToNextState = 10;
    public float timeBetweenLasers;
    [SerializeField] private List<SarcHandler> m_Lsacs;
    [SerializeField] private List<SarcHandler> m_Rsacs;
    protected override void StateOnEnable()
    {
        base.StateOnEnable();
        boss.isVulnerable = false;
        CallSummon();
        GameManager.gm.isSixPhaseReached = true;

    }
    private void CallSummon()
    {
        animator.SetTrigger("Summon");
        StartCoroutine(SummonEnemy());

    }
    IEnumerator SummonEnemy()
    {

        for (int i = 0; i < amountOfMummyPerSummon; i++)
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

            yield return new WaitForSeconds(TimeBetweenEnemy);
        }
        for (int i = 0; i < amountOfBeatlePerSummon; i++)
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


        yield return new WaitForSeconds(TimeBetweenEnemy);
        CallLaser();
    }
    void CallLaser()
    {
        StartCoroutine(RepeatLaser());
    }
    IEnumerator RepeatLaser()
    {
        boss.isVulnerable = false;
        animator.speed = 2;
        animator.SetTrigger("Laser");
        yield return new WaitForSeconds(timeBetweenLasers);
        animator.SetTrigger("Laser");
        yield return new WaitForSeconds(timeBetweenLasers);
        animator.SetTrigger("Laser");
        yield return new WaitForSeconds(timeBetweenLasers);
        animator.speed = 1;
        boss.isVulnerable = true;
        ChoosePattern();

    }




    [SerializeField] private int amountOfPatterns = 5;

    [SerializeField] private float timeBetweenAttacks;
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

    IEnumerator ChoosePattern()
    {
       
            yield return new WaitForSeconds(timeBetweenAttacks);
            StartCoroutine(PatternDelay(LwavePattern, RwavePattern));
            yield return new WaitForSeconds(timeBetweenAttacks * 3);
            StartCoroutine(PatternDelay(LlinePattern, RlinePattern));
            yield return new WaitForSeconds(timeBetweenAttacks * 3);
            StartCoroutine(PatternDelay(LZigZagPattern, RZigZagPattern));
            yield return new WaitForSeconds(timeBetweenAttacks * 3);
            StartCoroutine(PatternDelay(LCirclePattern, RCirclePattern));
            yield return new WaitForSeconds(timeBetweenAttacks * 3);
            StartCoroutine(PatternDelay(LxShapePattern, RxShapePattern));
            yield return new WaitForSeconds(timeBetweenAttacks * 3);

            CallLaser();

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
}
