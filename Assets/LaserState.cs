using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserState : State
{
    protected override void StateOnEnable()
    {
        base.StateOnEnable();
        animator.SetTrigger("Laser");
    }
    protected override void CallSwapState(State NextState)
    {
        base.CallSwapState(NextState);
    }
}
