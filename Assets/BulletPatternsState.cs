using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPatternsState : State
{
    
    
    [SerializeField]private int amountOfPatterns =5;
    [SerializeField,Header("Wave Shooting Script")] GameObject LwavePattern;
    [SerializeField,Header("Wave Shooting Script")] GameObject RwavePattern;

    [SerializeField, Header("Line Shooting Script")] GameObject LlinePattern;
    [SerializeField, Header("Line Shooting Script")] GameObject RlinePattern;

    [SerializeField, Header("ZigZag Shooting Script")] GameObject LZigZagPattern;
    [SerializeField, Header("ZigZag Shooting Script")] GameObject RZigZagPattern;


    [SerializeField, Header("Circle Shooting Script")] GameObject LCirclePattern;
    [SerializeField, Header("Circle Shooting Script")] GameObject RCirclePattern;


    [SerializeField, Header("X Shooting Script")] GameObject LxShapePattern;
    [SerializeField, Header("X Shooting Script")] GameObject RxShapePattern;
    public float TimeToNextState = 15;

    public bool choosePattern = false;

    [SerializeField] private float timeBetweenAttacks;

    protected override void StateOnEnable()
    {
        base.StateOnEnable();
        if (!choosePattern)
        {
            ChoosePattern();
        }
        else
        {
            ManualPattern();
        }


    }

    void ChoosePattern()
    {
        animator.SetTrigger("Shoot");
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
            case 3:
                StartCoroutine(PatternDelay(LCirclePattern, RCirclePattern));
                break;
            case 4:
                StartCoroutine(PatternDelay(LxShapePattern, RxShapePattern));
                break;
            default:
                break;
        }
    }
    void ManualPattern()
    {
        animator.SetTrigger("Shoot");
        StartCoroutine(PatternDelay(LxShapePattern, RxShapePattern));
    }
  
    IEnumerator PatternDelay(GameObject lP, GameObject rP)
    {
        Attack();
        
        lP.SetActive(true); 
        yield return new WaitForSeconds(timeBetweenAttacks);
        
        Attack();

        lP.SetActive(false);
        rP.SetActive(true); 
        yield return new WaitForSeconds(timeBetweenAttacks);

        yield return new WaitForSeconds(0.5f);
        
        Attack();
        
        rP.SetActive(false);
        lP.SetActive(true);
        yield return new WaitForSeconds(timeBetweenAttacks);

        Attack();

        lP.SetActive(false);
        rP.SetActive(true);
        yield return new WaitForSeconds(timeBetweenAttacks);
        rP.SetActive(false);
        yield return new WaitForSeconds(TimeToNextState);
        CallSwapState();
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
        StopAllCoroutines();
    }


}
