using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFourthPhase : State
{
    [SerializeField] float timeBetweenLasers;
    protected override void StateOnEnable()
    {
        base.StateOnEnable();
        boss.ThirtyPercentEvent.AddListener(CallSwapState);
        boss.isVulnerable = false;
        StartCoroutine(RepeatLaser());
    }
    IEnumerator RepeatLaser()
    {
        animator.SetTrigger("Laser");
        yield return new WaitForSeconds(timeBetweenLasers);
        animator.SetTrigger("Laser");
        yield return new WaitForSeconds(timeBetweenLasers);
        animator.SetTrigger("Laser");
        boss.isVulnerable = true;

        yield return new WaitForSeconds(timeBetweenLasers);
        CallSwapState();

    }
    protected override void CallSwapState()
    {
        base.CallSwapState();
    }
    private void OnDisable()
    {
        boss.ThirtyPercentEvent.RemoveListener(CallSwapState);

        StopAllCoroutines();
    }
}
