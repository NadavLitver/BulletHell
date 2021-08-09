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
        bool isMummy;
        animator.SetTrigger("Summon");
        isMummy = Randomizer.ReturnRandomFloat(0, 1) > 0.5f;
        StartCoroutine(SummonEnemy(isMummy ? MummyType : BeatleType));

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

        boss.isVulnerable = true;
        yield return new WaitForSeconds(TimeToNextState);
        CallSwapState();
     }

    protected override void CallSwapState()
    {
        base.CallSwapState();
    }

}
