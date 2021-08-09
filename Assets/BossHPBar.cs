using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHPBar : MonoBehaviour
{
    [SerializeField] private Transform pivot;
    [SerializeField] private Boss bossRef;
    private float maxHP;
    private Quaternion targetRot;

    [SerializeField] private float lerpSpeed;

    [SerializeField] private SpriteRenderer bar_sr;

    [SerializeField] private Sprite defaultBar;
    [SerializeField] private Sprite goldenBar;

    private void Start()
    {
        maxHP = bossRef.hp;
        targetRot = Quaternion.Euler(0, 0, -180 + Mathf.Lerp(0, 180, bossRef.hp / maxHP));
        pivot.rotation = targetRot;
    }
    private void Update()
    {
        targetRot = Quaternion.Euler(0, 0, -180 + Mathf.Lerp(0, 180, bossRef.hp / maxHP));
        if (bossRef.hp <= 0)
        {
            targetRot = Quaternion.Euler(0, 0, 0);
        }
        pivot.rotation = targetRot;
        bar_sr.sprite = bossRef.isVulnerable ? defaultBar : goldenBar;
    }
}
