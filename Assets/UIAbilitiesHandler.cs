using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAbilitiesHandler : MonoBehaviour
{
    void Start()
    {
        GameManager.gm.CallDeactivateAndActiveGO(gameObject);
    }
}
