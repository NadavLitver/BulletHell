using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbHandler : MonoBehaviour
{
    public PlayerMovement player;

    public Material m_mat;

    private const string LiquidStrenghtREF = "_LiquidStr";
    private const string BounceSpeedREF = "_BouceSpeed";

    public float minVal;
    public float maxVal;
    private float curVal;

    private void Start()
    {
        curVal = player.hp;
    }

    private void Update()
    {
        if (curVal < player.hp)
        {
            curVal += Time.deltaTime * 1f;
        }
        else if (curVal > player.hp)
        {
            curVal -= Time.deltaTime * 1f;
        }

        m_mat.SetFloat(LiquidStrenghtREF, curVal);
    }












}
