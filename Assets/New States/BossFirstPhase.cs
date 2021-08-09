using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFirstPhase : State
{
    [SerializeField] private int amountOfPatterns = 3;

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
        boss.isVulnerable = true;
        base.StateOnEnable();
        StartCoroutine(ChoosePattern());
        boss.EightyPercentEvent.AddListener(CallSwapState);
        
    }
    IEnumerator ChoosePattern()
    {
        Choose();
        yield return new WaitForSeconds(timeBetweenAttacks * 2);
        Choose();
        yield return new WaitForSeconds(timeBetweenAttacks * 2);
        Choose();

        void Choose()
        {
            var curPatternIndex = Randomizer.ReturnRandomNum(0, amountOfPatterns);
            switch (curPatternIndex)
            {
                case 0:
                    StartCoroutine(PatternDelay(LwavePattern, RwavePattern));
                    break;
                case 1:
                    StartCoroutine(PatternDelay(LlinePattern, RlinePattern));
                    break;
                case 2:
                    StartCoroutine(PatternDelay(LZigZagPattern, RZigZagPattern));
                    break;
                //case 3:
                //    StartCoroutine(PatternDelay(LCirclePattern, RCirclePattern));
                //    break;
                //case 4:
                //    StartCoroutine(PatternDelay(LxShapePattern, RxShapePattern));
                //    break;
                default:
                    break;
            }
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
        boss.EightyPercentEvent.RemoveListener(CallSwapState);
          StopAllCoroutines();
    }
}