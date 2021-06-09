using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepEffectHandler : MonoBehaviour
{
    public GameObject step;
    public void PlayWithOffset(Vector3 offset)
    {
        Instantiate(step, transform.position + offset, Quaternion.identity);
    }
}
