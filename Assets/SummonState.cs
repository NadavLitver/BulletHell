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
    [SerializeField]
    Transform[] LsummonPoints;
    [SerializeField]
    Transform[] RsummonPoints;


    public int amountOfEnemiesPerSummon;
    public float TimeBetweenEnemy;
    public float TimeToNextState = 10;


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
        //Transform summonPos = type == MummyType ? lSummonPoint : rSummonPoint;
        for (int i = 0; i < amountOfEnemiesPerSummon; i++)
        {
            for (int j = 0; j < LsummonPoints.Length; j++)
            {
                Instantiate(type, RsummonPoints[i].position, RsummonPoints[i].rotation, RsummonPoints[i]);
                Instantiate(type, LsummonPoints[i].position, LsummonPoints[i].rotation, LsummonPoints[i]);
                yield return new WaitForSeconds(TimeBetweenEnemy);
            }
            yield return new WaitForSeconds(TimeBetweenEnemy);
        }

        yield return new WaitForSeconds(TimeToNextState);
        CallSwapState(nextState);

     }

    protected override void CallSwapState(State NextState)
    {
        base.CallSwapState(NextState);
    }

}
