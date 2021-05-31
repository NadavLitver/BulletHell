using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    private StateSwapper stateSwapper;

    private void Start()
    {
        stateSwapper = GetComponent<StateSwapper>();
    }
    protected virtual void CallSwapState(State NextState)
    {
        stateSwapper.SwapState(NextState);
    }
  
}
