using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonState : State
{
    [SerializeField]
    private GameObject BeatleType;
    [SerializeField]
    private GameObject MummyType;


    public int amountOfEnemiesPerSummon;
    public float TimeBetweenEnemy;
    public float TimeToNextState = 10;

    [SerializeField] private List<SarcHandler> m_sacs;


    protected override void StateOnEnable()
    {
        base.StateOnEnable();
        ChooseEnemyType();
    }

    private void ChooseEnemyType()
    {
        switch (Randomizer.GetOneOrMinusOne())
        {
            case 1:
                StartCoroutine(SummonEnemy(MummyType));
                animator.SetTrigger("Summon");
                break;
            case -1:
                StartCoroutine(SummonEnemy(BeatleType));
                animator.SetTrigger("Summon");
                break;
            
        }
    }
     IEnumerator SummonEnemy(GameObject type)
     {
        boss.isVulnerable = false;
        for (int i = 0; i < amountOfEnemiesPerSummon; i++)
        {
            for (int j = 0; j < m_sacs.Count; j++)
            {
                m_sacs[j].Open();
                yield return new WaitForSeconds(TimeBetweenEnemy / 2);
                m_sacs[j].Spawn(type);
                yield return new WaitForSeconds(TimeBetweenEnemy / 2);
                m_sacs[j].Close();
            }
            yield return new WaitForSeconds(TimeBetweenEnemy);
        }

        yield return new WaitForSeconds(TimeToNextState);
        boss.isVulnerable = true;
        CallSwapState(nextState);

     }

    protected override void CallSwapState(State NextState)
    {
        base.CallSwapState(NextState);
    }

}
