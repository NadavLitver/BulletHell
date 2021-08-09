using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserState : State
{
    [SerializeField] float timeBetweenLasers;
    protected override void StateOnEnable()
    {
        base.StateOnEnable();
        boss.ThirtyPercentEvent.AddListener(CallSwapState);
    }
   IEnumerator RepeatLaser()
    {
        animator.SetTrigger("Laser");
        yield return new WaitForSeconds(timeBetweenLasers);
        animator.SetTrigger("Laser");
        yield return new WaitForSeconds(timeBetweenLasers);
        animator.SetTrigger("Laser");

        yield return new WaitForSeconds(timeBetweenLasers);
        CallSwapState();

    }
    protected override void CallSwapState()
    {
        base.CallSwapState();
    }
}
