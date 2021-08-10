using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    [SerializeField]
    private StateSwapper stateSwapper;
    [SerializeField]
    protected Animator animator;
    [SerializeField]
    protected Boss boss;
    protected int hpWhenEnterState;
    [SerializeField]
    protected State nextState;
  



    private  void OnEnable()
    {
        stateSwapper = GetComponent<StateSwapper>();
        StateOnEnable();
    }
    protected virtual void StateOnEnable()
    {
      

    }
    private void Update()
    {
        if (GameManager.gm.isPaused)
        {
            return;
        }

    }
    protected virtual void CallSwapState()
    {
        stateSwapper.SwapState(nextState);
    }
  
}
