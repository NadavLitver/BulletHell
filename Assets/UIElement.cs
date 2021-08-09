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

    public Transform rs;
    public bool canRotate;
    public float rotationSpeed;

    public float hoverIntensity;



    public void Start()
    {
        myButton = GetComponent<Button>();
        myButton.onClick.AddListener(ButtonPress);
    }

    private void Update()
    {
        if (mouseOver && canRotate)
        {
            rs.rotation = Quaternion.RotateTowards(rs.rotation, Quaternion.Euler(rs.rotation.x, rs.rotation.y, rs.rotation.z + Time.time * rotationSpeed), 90f);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouseOver = true;
        rl.SetLight(hoverIntensity, 0.25f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouseOver = false;
        //set light to idle light
        rl.SetLight(rl.idleIntensity, 0.25f);

    }

    public void ButtonPress()
    {
        // set light
        rl.SetLight(150f, 0.25f);
        // press logic
    }
}
