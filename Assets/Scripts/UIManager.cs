using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    TextMeshProUGUI[] GameTexts;
    public static UIManager uiManagerInstace;
        private void Awake()
        {
         uiManagerInstace = this;
        }
}
