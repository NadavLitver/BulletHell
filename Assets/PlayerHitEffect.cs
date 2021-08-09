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
        m_sprite.color = Color.Lerp(Color.black, Color.white, currDurr);
        AudioManager.am.PlaySound(AudioManager.am.player_Hit, 0.5f);
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(0.1f);
        Time.timeScale = 1;
        while (currDurr < 1)
        {
            currDurr += Time.deltaTime / duration;
            m_sprite.color = Color.Lerp(Color.black, Color.white, currDurr);
            yield return new WaitForEndOfFrame();
        }
        m_sprite.color = Color.white;

    }
}
