using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateSwapper : MonoBehaviour
{
    
    public BossFirstPhase firstPhase;
    public BossSecondPhase secondPhase;
    public BossThirdPhase thirdPhase;
    public BossFourthPhase fourthPhase;
    public BossFifthPhase fifthPhase;
    public BossSixPhase sixPhase;




    private State FirstState;
    private void Start()
    {
        FirstState = firstPhase;
        Invoke("SetFirstState", 5f);
    }
    void SetFirstState()
    {
        SwapState(FirstState);
        
    }
    public void SwapState(State state)
    {
        AudioManager.am.PlaySound(AudioManager.am.boss_swapState, 1);
        if (state == firstPhase)
        {
            firstPhase.enabled = true;
            secondPhase.enabled = false;
            thirdPhase.enabled = false;
            fourthPhase.enabled = false;
            fifthPhase.enabled = false;
            sixPhase.enabled = false;



        }
        else if (state == secondPhase)
        {

            firstPhase.enabled = false;
            secondPhase.enabled = true;
            thirdPhase.enabled = false;
            fourthPhase.enabled = false;
            fifthPhase.enabled = false;
            sixPhase.enabled = false;


        }
        else if (state == thirdPhase)
        {

            firstPhase.enabled = false;
            secondPhase.enabled = false;
            thirdPhase.enabled = true;
            fourthPhase.enabled = false;
            fifthPhase.enabled = false;
            sixPhase.enabled = false;

        }
        else if (state == fourthPhase)
        {
            firstPhase.enabled = false;
            secondPhase.enabled = false;
            thirdPhase.enabled = false;
            fourthPhase.enabled = true;
            fifthPhase.enabled = false;
            sixPhase.enabled = false;
        }
        else if (state == fifthPhase)
        {

            firstPhase.enabled = false;
            secondPhase.enabled = false;
            thirdPhase.enabled = false;
            fourthPhase.enabled = false;
            fifthPhase.enabled = true;
            sixPhase.enabled = false;
        } else if (state == sixPhase)
        {

            firstPhase.enabled = false;
            secondPhase.enabled = false;
            thirdPhase.enabled = false;
            fourthPhase.enabled = false;
            fifthPhase.enabled = false;
            sixPhase.enabled = true;

        }
        else { Debug.LogError("boss dont know state"); }
            


    }
}