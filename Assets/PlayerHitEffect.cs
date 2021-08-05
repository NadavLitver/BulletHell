using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitEffect : MonoBehaviour
{
    private SpriteRenderer m_sprite;
    private void Start()
    {
        m_sprite = GetComponent<SpriteRenderer>();
    }
    public void CallHitEffect()
    {
        StartCoroutine(HitEffect());
    }
    private IEnumerator HitEffect()
    {
        float currDurr = 0;
        float duration = .3f;
        CamShake.instance.callCamShake(duration, 1);
        while (currDurr < 1)
        {
            m_sprite.color = Color.Lerp(Color.black, Color.white, currDurr);
            currDurr += Time.deltaTime / duration;
            yield return new WaitForEndOfFrame();
        }
        m_sprite.color = Color.white;

    }
}
