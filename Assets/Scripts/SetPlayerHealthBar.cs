﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetPlayerHealthBar : MonoBehaviour
{
    public Transform Follow;
    private static Slider slider;
    // Start is called before the first frame update
    void Start()
    {

        slider = GetComponent<Slider>();
        transform.position = Camera.main.WorldToScreenPoint(Follow.position);
    }

    // Update is called once per frame
    void Update()
    { 
        transform.position = new Vector2(Mathf.MoveTowards(transform.position.x, Camera.main.WorldToScreenPoint(Follow.position).x,300*Time.deltaTime),Camera.main.WorldToScreenPoint(Follow.position).y);
    }
    public static IEnumerator SetHP(int hp)
    {
        while(slider.value != hp)
        {
            slider.value = Mathf.MoveTowards(slider.value, hp, 0.15f);
            yield return new WaitForEndOfFrame();
        }
        yield break;
    }
}