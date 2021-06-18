using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetPlayerHealthBar : MonoBehaviour
{
    public Transform Follow;
    public float healthBarSpeed;
    private static Slider slider;
    // Start is called before the first frame update
    private void Awake()
    {
       

    }
    void Start()
    {
       
        slider = GetComponent<Slider>();
        transform.position = Camera.main.WorldToScreenPoint(Follow.position);
    }

    // Update is called once per frame
    void Update()
    { 
        transform.position = new Vector2(Mathf.MoveTowards(transform.position.x, Camera.main.WorldToScreenPoint(Follow.position).x, healthBarSpeed * Time.deltaTime),Camera.main.WorldToScreenPoint(Follow.position).y);
    }
    public static IEnumerator SetHPCorou(int hp)
    {
        while(slider.value != hp)
        {
            slider.value = Mathf.MoveTowards(slider.value, hp, 0.25f);
            yield return new WaitForEndOfFrame();
        }
        yield break;
    }
  
}
