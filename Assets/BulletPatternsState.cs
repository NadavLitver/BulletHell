using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPatternsState : State
{
    
    
    [SerializeField]private int amountOfPatterns = 1;
    [SerializeField,Header("WavePatternScript")] GameObject LwavePattern;
    [SerializeField, Header("WavePatternScript")] GameObject RwavePattern;



    public float TimeToNextState = 10;

    protected override void StateOnEnable()
    {
        base.StateOnEnable();
        ChoosePattern();
   

    }

    void ChoosePattern()
    {

        var curPatternIndex = Randomizer.ReturnRandomNum(amountOfPatterns);
        switch (curPatternIndex)
        {
            case 0:
                animator.SetTrigger("Shoot");
                StartCoroutine(StateDelay());
                break;
            default:
                break;
        }
    }
  
  
    IEnumerator StateDelay()
    {
        LwavePattern.SetActive(true);
        yield return new WaitForSeconds(0.8f);
        LwavePattern.SetActive(false);
        RwavePattern.SetActive(true);
        yield return new WaitForSeconds(0.8f);
        RwavePattern.SetActive(false);

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
