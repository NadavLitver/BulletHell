using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateSwapper : MonoBehaviour
{
    
    public LaserState laserState;
    public BulletPatternsState BulletPatternsState;
    public SummonState summonState;
    public BossIdleState idleState;

    public State FirstState;
    private void Start()
    {
        SwapState(FirstState);
    }
    public void SwapState(State state)
    {
        if(state == laserState)
        {
            BulletPatternsState.enabled = false;
            summonState.enabled = false;
            idleState.enabled = false;
            Debug.Log("laserState");

        }
        else if(state == BulletPatternsState)
        {
            laserState.enabled = false;
            summonState.enabled = false;
            idleState.enabled = false;
            Debug.Log("BulletPatternsState");


        }
        else if(state == summonState)
        {
            laserState.enabled = false;
            BulletPatternsState.enabled = false;
            idleState.enabled = false;
            Debug.Log("summonState");

        }
        else if(state == idleState)
        {
            laserState.enabled = false;
            BulletPatternsState.enabled = false;
            summonState.enabled = false;
            Debug.Log("idleState");

        }
        else
        {
            Debug.LogError("boss dont know state");
        }
        state.enabled = true;
        
    }
}