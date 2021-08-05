using UnityEngine;

public class OrbHandler : MonoBehaviour
{
    public PlayerMovement player;
    public Material m_mat;

    // Liquid shader properties
    private const string LiquidStrenghtREF = "_LiquidStr";
    private const string BounceSpeedREF = "_BouceSpeed";


    [Range(-0.7f, 0.7f)] private float curVal;

    private void Start()
    {
        // Set current hp value to player hp (max hp)
        curVal = 0.7f;
    }

    private void Update()
    {
        SetHP();
        SetLiquidBounce();
    }

    private void SetHP()
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

    private void SetLiquidBounce()
    {
        if (curVal <= 15f)
        {
            m_mat.SetFloat(BounceSpeedREF, 1.5f);

        }
    }





}
