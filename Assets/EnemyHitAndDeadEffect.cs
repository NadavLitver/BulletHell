﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitAndDeadEffect : MonoBehaviour
{
    private const string FadeRefID = "_Fade";
    private const string ColorRefID = "_Color";
    private const string MultiplierRefID = "_Multiplier";

    [SerializeField] private GameObject m_ps;
    [SerializeField] private Color IdleColor;
    [SerializeField] private Color HitColor;
    private float IdleMultiplier = 1;
    [SerializeField] private float HitMultiplier;

    [SerializeField] private SpriteRenderer m_sr;
    [SerializeField] UnityEngine.Experimental.Rendering.Universal.Light2D m_light;
    void Start()
    {
        m_ps.SetActive(false);
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
            m_light.intensity = Mathf.Lerp(Damage, 0, currDurr);
            m_sr.material.SetFloat(MultiplierRefID, Mathf.Lerp(HitMultiplier, IdleMultiplier, currDurr));
            m_sr.material.SetColor(ColorRefID, Color.Lerp(HitColor, IdleColor, currDurr));
            yield return new WaitForEndOfFrame();
        }

        m_sr.material.SetFloat(MultiplierRefID, IdleMultiplier);
        m_sr.material.SetColor(ColorRefID, IdleColor);
    }
    public void OnDeath()
    {
        StartCoroutine(OnDeathCoru());
    }
    private IEnumerator OnDeathCoru()
    {
        transform.parent = null;
        m_ps.SetActive(true);
        m_ps.transform.parent = null;
        m_sr.material.SetFloat(MultiplierRefID, IdleMultiplier);
        m_sr.material.SetColor(ColorRefID, IdleColor);
        float currDurr = 0;
        while (currDurr < 1)
        {
            currDurr += Time.deltaTime / 0.5f;
            m_light.intensity = Mathf.Lerp(100, 0, currDurr);
            m_sr.material.SetFloat(FadeRefID, Mathf.Lerp(1, 0, currDurr));
            yield return new WaitForEndOfFrame();
        }
        Destroy(gameObject);
    }
}
