using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFifthPhase : State
{
    [SerializeField] private int amountOfPatterns = 5;

    [SerializeField] private float timeBetweenAttacks;
    [SerializeField] protected GameObject LwavePattern;
    [SerializeField] protected GameObject RwavePattern;
    [SerializeField] protected GameObject LlinePattern;
    [SerializeField] protected GameObject RlinePattern;
    [SerializeField] protected GameObject LZigZagPattern;
    [SerializeField] protected GameObject RZigZagPattern;
    [SerializeField] protected GameObject RCirclePattern;
    [SerializeField] protected GameObject LCirclePattern;
    [SerializeField] protected GameObject LxShapePattern;
    [SerializeField] protected GameObject RxShapePattern;
    protected override void StateOnEnable()
    {
        base.StateOnEnable();
        boss.isVulnerable = true;
        if(GameManager.gm.isSixPhaseReached)
          boss.TenPercentEvent.AddListener(CallSwapState);
        StartCoroutine(ChoosePattern());
    }
    IEnumerator ChoosePattern()
    {
        while (this.enabled)
        {
            yield return new WaitForSeconds(timeBetweenAttacks);
            StartCoroutine(PatternDelay(LwavePattern, RwavePattern));
            yield return new WaitForSeconds(timeBetweenAttacks * 3);
            StartCoroutine(PatternDelay(LlinePattern, RlinePattern));
            yield return new WaitForSeconds(timeBetweenAttacks * 3);
            StartCoroutine(PatternDelay(LZigZagPattern, RZigZagPattern));
            yield return new WaitForSeconds(timeBetweenAttacks * 3);
            StartCoroutine(PatternDelay(LCirclePattern, RCirclePattern));
            yield return new WaitForSeconds(timeBetweenAttacks * 3);
            StartCoroutine(PatternDelay(LxShapePattern, RxShapePattern));
            yield return new WaitForSeconds(timeBetweenAttacks * 3);
        }
    

    }
    IEnumerator PatternDelay(GameObject lP, GameObject rP)
    {
        Attack();
        lP.SetActive(true);
        yield return new WaitForSeconds(timeBetweenAttacks);
        lP.SetActive(false);
        rP.SetActive(true);
        yield return new WaitForSeconds(timeBetweenAttacks + 0.5f);
        rP.SetActive(false);
    }
    private void Attack()
    {
        animator.SetTrigger("Shoot");
        PlayAttackSound();
    }

    private void PlayAttackSound()
    {
        AudioManager.am.PlaySound(AudioManager.am.boss_Attack, 1);
    }
    protected override void CallSwapState()
    {
        base.CallSwapState();
    }
    private void OnDisable()
    {
        boss.TenPercentEvent.RemoveListener(CallSwapState);

        StopAllCoroutines();
    }
}
