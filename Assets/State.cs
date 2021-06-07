using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    [SerializeField]
    private StateSwapper stateSwapper;
    [SerializeField]
    private Boss boss;
    protected int hpWhenEnterState;
    [SerializeField]
    protected State nextState;
    protected int damageToSwapState = 20;
    private void OnEnable()
    {
        
        hpWhenEnterState = boss.hp;
    }
    private void Update()
    {
        if (hpWhenEnterState >= boss.hp + damageToSwapState) 
        {
            CallSwapState(nextState);
        }
      
    }
    protected virtual void CallSwapState(State NextState)
    {
        stateSwapper.SwapState(NextState);
    }
  
}
