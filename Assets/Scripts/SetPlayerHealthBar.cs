using System.Collections;
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
    }

    // Update is called once per frame
    void Update()
    { 
        transform.position = Camera.main.WorldToScreenPoint(Follow.position);
        
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
