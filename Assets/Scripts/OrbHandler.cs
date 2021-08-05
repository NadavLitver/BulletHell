using UnityEngine;
using System.Collections;

public class OrbHandler : MonoBehaviour
{
    public Material m_mat;

    // Liquid shader properties
    private const string LiquidStrenghtREF = "_LiquidStr";
    private const string BounceSpeedREF = "_BouceSpeed";


    [Range(-0.7f, 0.7f)] private float curVal;
    private float tempRange = 0.7f;

    private void Start()
    {
        GameManager.gm.CallDeactivateAndActiveGO(gameObject);
    }
    
    private void OnEnable()
    {
        curVal = 0.7f;
        m_mat.SetFloat(LiquidStrenghtREF, curVal);
    }
    private void Update()
    {
        SetLiquidBounce();
    }

    public void SetHP(float playerHP)
    {
        curVal = Mathf.Lerp(-0.7f, 0.7f, playerHP / 100);
        m_mat.SetFloat(LiquidStrenghtREF, curVal);
    }

    private void SetLiquidBounce()
    {
        m_mat.SetFloat(BounceSpeedREF, 1.5f);
    }





}
