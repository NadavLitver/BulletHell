using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class UIElement : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    bool mouseOver = false;
    private Button myButton;

    public RuneLight rl;


    public void Start()
    {
        myButton = GetComponent<Button>();
        myButton.onClick.AddListener(ButtonPress);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouseOver = true;
        //on hover
        rl.SetLight(50f, 0.25f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouseOver = false;
        //set light to idle light
        rl.SetLight(rl.idleIntensity, 2f);

    }

    public void ButtonPress()
    {
        // set light
        rl.SetLight(150f, 0.25f);
        // press logic
    }
}
