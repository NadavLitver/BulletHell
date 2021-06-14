using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPatternsState : State
{
    
    
    [SerializeField]private int amountOfPatterns = 1;

    [SerializeField]
    private ParticleSystem LwavePatternPrefab;
    [SerializeField]
    private ParticleSystem RwavePatternPrefab;

    public int amountOfWaves;
    public float TimeToNextState = 10;

    protected override void StateOnEnable()
    {
        base.StateOnEnable();
        ChoosePattern();
        LwavePatternPrefab.gameObject.SetActive(true);
        RwavePatternPrefab.gameObject.SetActive(true);
    }

    void ChoosePattern()
    {

        var curPatternIndex = Randomizer.ReturnRandomNum(amountOfPatterns);
        switch (curPatternIndex)
        {
            case 0:
                animator.SetTrigger("Shoot");
                StartCoroutine(WaveCoroutine());
                break;
            default:
                break;
        }
    }
  
    public void LWavePattern()
    {
        LwavePatternPrefab.Stop();

        LwavePatternPrefab.Play();

    }
    public void RWavePattern()
    {
        RwavePatternPrefab.Stop();


        RwavePatternPrefab.Play();

    }
    IEnumerator WaveCoroutine()
    {
        
        yield return new WaitForSeconds(0.2f);
        LWavePattern();
        yield return new WaitForSeconds(0.8f);
        RWavePattern();
        yield return new WaitForSeconds(TimeToNextState);
        CallSwapState(nextState);




    }
    protected override void CallSwapState(State NextState)
    {
        base.CallSwapState(NextState);
    }



    void TempPattern()
    {
        LwavePatternPrefab.gameObject.SetActive(false);
        RwavePatternPrefab.gameObject.SetActive(false);


    }
    private void OnDisable()
    {
        LwavePatternPrefab.gameObject.SetActive(false);
        RwavePatternPrefab.gameObject.SetActive(false);
        StopAllCoroutines();

    }


}
