using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPatternsState : State
{
    
    
    [SerializeField]private int amountOfPatterns = 3;
    [SerializeField,Header("Wave Shooting Script")] GameObject LwavePattern;
    [SerializeField,Header("Wave Shooting Script")] GameObject RwavePattern;

    [SerializeField, Header("Line Shooting Script")] GameObject LlinePattern;
    [SerializeField, Header("Line Shooting Script")] GameObject RlinePattern;

    [SerializeField, Header("ZigZag Shooting Script")] GameObject LZigZagPattern;
    [SerializeField, Header("ZigZag Shooting Script")] GameObject RZigZagPattern;
    public float TimeToNextState = 10;

    protected override void StateOnEnable()
    {
        base.StateOnEnable();
        ChoosePattern();
   

    }

    void ChoosePattern()
    {

        var curPatternIndex = Randomizer.ReturnRandomNum(0,amountOfPatterns);
        switch (curPatternIndex)
        {
            case 0:
                animator.SetTrigger("Shoot");
                StartCoroutine(StateDelay(LwavePattern, RwavePattern));
                break;
            case 1:
                animator.SetTrigger("Shoot");
                StartCoroutine(StateDelay(LlinePattern, RlinePattern));
                break;
            case 2:
                animator.SetTrigger("Shoot");
                StartCoroutine(StateDelay(LZigZagPattern, RZigZagPattern));
                break;
            default:
                break;
        }
    }
  
  
    IEnumerator StateDelay(GameObject lP, GameObject rP)
    {
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
