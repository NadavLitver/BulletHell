using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StepEffectHandler : MonoBehaviour
{
    public GameObject step;

    [SerializeField] private Transform pivotMid;
    [SerializeField] private Transform pivotLeft;
    [SerializeField] private Transform pivotRight;


    private Vector3 rotation = new Vector3(60f,0f,0f);
    public void PlayMid()
    {
        Instantiate(step, pivotMid.position, Quaternion.Euler(rotation));
    }
    public void PlayLeft()
    {
        Instantiate(step, pivotLeft.position, Quaternion.Euler(rotation));
    }
    public void PlayRight()
    {
        Instantiate(step, pivotRight.position, Quaternion.Euler(rotation));
    }
}
