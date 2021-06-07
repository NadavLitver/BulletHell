using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPatternsState : State
{
    public GameObject wavePatternPrefab;
    
    [SerializeField]private int amountOfPatterns = 2;

    private void Start()
    {
        ChoosePattern();
    }

    void ChoosePattern()
    {
        var curPatternIndex = Randomizer.ReturnRandomNum(amountOfPatterns);
        switch (curPatternIndex)
        {
            case 0:
                WavePattern();
                break;
            case 1:
                TempPattern();
                break;
            default:
                break;
        }
    }
    protected override void CallSwapState(State NextState)
    {
        base.CallSwapState(NextState);
    }



    void WavePattern()
    {
        wavePatternPrefab.SetActive(true);
    }
    void TempPattern()
    {
        wavePatternPrefab.SetActive(false);

    }
    private void OnDisable()
    {
        wavePatternPrefab.SetActive(false);
    }

}
