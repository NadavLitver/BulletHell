using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPatternsState : State
{
    
    
    [SerializeField]private int amountOfPatterns = 4;
    [SerializeField,Header("Wave Shooting Script")] GameObject LwavePattern;
    [SerializeField,Header("Wave Shooting Script")] GameObject RwavePattern;

    [SerializeField, Header("Line Shooting Script")] GameObject LlinePattern;
    [SerializeField, Header("Line Shooting Script")] GameObject RlinePattern;

    [SerializeField, Header("ZigZag Shooting Script")] GameObject LZigZagPattern;
    [SerializeField, Header("ZigZag Shooting Script")] GameObject RZigZagPattern;


    [SerializeField, Header("Circle Shooting Script")] GameObject LCirclePattern;
    [SerializeField, Header("ZigZag Shooting Script")] GameObject RCirclePattern;
    public float TimeToNextState = 10;

    public bool choosePattern = false;

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

        var curPatternIndex = Randomizer.ReturnRandomNum(0,amountOfPatterns);
        switch (curPatternIndex)
        {
            case 0:
                animator.SetTrigger("Shoot");
                StartCoroutine(PatternDelay(LwavePattern, RwavePattern));
                break;
            case 1:
                animator.SetTrigger("Shoot");
                StartCoroutine(PatternDelay(LlinePattern, RlinePattern));
                break;
            case 2:
                animator.SetTrigger("Shoot");
                StartCoroutine(PatternDelay(LZigZagPattern, RZigZagPattern));
                break;
            case 3:
                animator.SetTrigger("Shoot");
                StartCoroutine(PatternDelay(LCirclePattern, RCirclePattern));
                break;
            default:
                break;
        }
    }
    void ManualPattern()
    {
        animator.SetTrigger("Shoot");
        StartCoroutine(PatternDelay(LCirclePattern, RCirclePattern));
    }
  
    IEnumerator PatternDelay(GameObject lP, GameObject rP)
    {
        lP.SetActive(true);
        yield return new WaitForSeconds(1.2f);
        lP.SetActive(false);
        rP.SetActive(true);
        yield return new WaitForSeconds(1.2f);
        rP.SetActive(false);

        yield return new WaitForSeconds(0.5f);
        animator.SetTrigger("Shoot");


        lP.SetActive(true);
        yield return new WaitForSeconds(1.2f);
        lP.SetActive(false);
        rP.SetActive(true);
        yield return new WaitForSeconds(1.2f);
        rP.SetActive(false);
        yield return new WaitForSeconds(TimeToNextState);
        CallSwapState(nextState);




    }
    protected override void CallSwapState(State NextState)
    {
        base.CallSwapState(NextState);
    }



    void TempPattern()
    {
       


    }
    private void OnDisable()
    {
     
        StopAllCoroutines();

    }


}
