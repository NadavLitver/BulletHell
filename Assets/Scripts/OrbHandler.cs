using UnityEngine;
using System.Collections;

public class OrbHandler : MonoBehaviour
{
    public Material m_mat;

    // Liquid shader properties
    private const string LiquidStrenghtREF = "_LiquidStr";
    private const string BounceSpeedREF = "_BouceSpeed";


    [Range(-1f, 0.85f)] private float curVal;
    [Range(-1f, 0.85f)] private float targetVal;

    public PlayerMovement playerRef;

    [SerializeField] private float LerpSpeed;
        
    private void Start()
    {
        GameManager.gm.CallDeactivateAndActiveGO(gameObject);
    }
    private void OnEnable()
    {
        SetLiquidBounce();
        SetHP(playerRef.hp);
    }

    public void SetHP(float playerHP)
    {
        curVal = m_mat.GetFloat(LiquidStrenghtREF);
        SetLiquidBounce();
        targetVal = Mathf.Lerp(-1f, 0.85f, playerHP / 100);
        m_mat.SetFloat(LiquidStrenghtREF, curVal);
        StopAllCoroutines();
        StartCoroutine(SetHPCoru());
    }
    private IEnumerator SetHPCoru()
    {
        float currDurr = 0;
        float lerpSpeed = 0.25f;
        while (currDurr < 1)
        {
            currDurr += Time.deltaTime / lerpSpeed;
            m_mat.SetFloat(LiquidStrenghtREF, Mathf.Lerp(curVal, targetVal, currDurr));
            yield return new WaitForEndOfFrame();
        }
    }
    private void SetLiquidBounce()
    {
        m_mat.SetFloat(BounceSpeedREF, 1.5f);
    }





}
