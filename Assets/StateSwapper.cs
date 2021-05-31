using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateSwapper : MonoBehaviour
{
    
    public LaserState laserState;
    public BulletPatternsState BulletPatternsState;
    public SummonState summonState;
    public BossIdleState idleState;

    private void Start()
    {
        SwapState(idleState);
    }
    public void SwapState(State state)
    {
        if(state == laserState)
        {
            BulletPatternsState.enabled = false;
            summonState.enabled = false;
            idleState.enabled = false;

        }
        else if(state == BulletPatternsState)
        {
            laserState.enabled = false;
            summonState.enabled = false;
            idleState.enabled = false;

        }
        else if(state == summonState)
        {
            laserState.enabled = false;
            BulletPatternsState.enabled = false;
            idleState.enabled = false;

        }
        else if(state == idleState)
        {
            laserState.enabled = false;
            BulletPatternsState.enabled = false;
            summonState.enabled = false;
        }
        else
        {
            Debug.LogError("boss dont know state");
        }
        state.enabled = true;
        
    }
}