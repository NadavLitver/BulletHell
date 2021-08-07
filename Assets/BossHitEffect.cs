using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHitEffect : MonoBehaviour
{
    private const string FadeRefID = "_Fade";
    private const string ColorRefID = "_Color";
    private const string MultiplierRefID = "_Multiplier";

    [SerializeField] private Color IdleColor;
    [SerializeField] private Color HitColor;
    private float IdleMultiplier = 1;
    [SerializeField] private float HitMultiplier;

    [SerializeField] private SpriteRenderer m_sr;
    void Start()
    {
        m_sr.material.SetFloat(FadeRefID, 1);
    }
    public void TakeDamage(float Damage)
    {
        StartCoroutine(TakeDamageCoru(Damage));
    }
    private IEnumerator TakeDamageCoru(float Damage)
    {
        float currDurr = 0;
        while (currDurr < 1)
        {
            currDurr += Time.deltaTime / 0.2f;
            m_sr.material.SetFloat(MultiplierRefID, Mathf.Lerp(HitMultiplier, IdleMultiplier, currDurr));
            m_sr.material.SetColor(ColorRefID, Color.Lerp(HitColor, IdleColor, currDurr));
            yield return new WaitForEndOfFrame();
        }

        m_sr.material.SetFloat(MultiplierRefID, IdleMultiplier);
        m_sr.material.SetColor(ColorRefID, IdleColor);
    }
}
