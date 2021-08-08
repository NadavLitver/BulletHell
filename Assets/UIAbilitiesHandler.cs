using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAbilitiesHandler : MonoBehaviour
{
    public Image special_image;
    void Start()
    {
        GameManager.gm.CallDeactivateAndActiveGO(gameObject);
    }
}
