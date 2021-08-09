using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSecondPhase : State
{
    [SerializeField]
    private GameObject BeatleType;
    [SerializeField]
    private GameObject MummyType;
    public int amountOfMummyPerSummon;
    public int amountOfBeatlePerSummon;
    public float TimeBetweenEnemy;
    public float TimeToNextState = 10;

    [SerializeField] private List<SarcHandler> m_Lsacs;
    [SerializeField] private List<SarcHandler> m_Rsacs;
    protected override void StateOnEnable()
    {
        base.StateOnEnable();
        boss.isVulnerable = false;
        CallSummon();

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


        yield return new WaitForSeconds(TimeToNextState);
        CallSwapState();
    }
    protected override void CallSwapState()
    {
        base.CallSwapState();
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
