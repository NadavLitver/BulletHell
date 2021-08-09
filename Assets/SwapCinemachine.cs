using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SwapCinemachine : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera thisCam;

    private void Start()
    {
        Invoke("Swap",2);
    }
    void Swap()
    {
        thisCam.Priority = 0;
    }
}
