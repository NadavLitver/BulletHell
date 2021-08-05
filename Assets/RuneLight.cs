using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneLight : MonoBehaviour
{
    [SerializeField] private UnityEngine.Experimental.Rendering.Universal.Light2D m_light;
    public float idleIntensity;

    private void OnEnable()
    {
        SetLight(idleIntensity, 1f);
    }
    public void PlayRuneAnim(float intensity, float lerpSpeed)
    {
        StopAllCoroutines();
        StartCoroutine(PlayRuneAnimCoru(intensity, lerpSpeed));
    }

    private IEnumerator PlayRuneAnimCoru(float intensity, float lerpSpeed)
    {
        m_light.intensity = intensity;
        float currDurr = 0;
        while (m_light.intensity > 0)
        {
            currDurr += Time.deltaTime / lerpSpeed;
            m_light.intensity = Mathf.Lerp(m_light.intensity, 0, currDurr);
            yield return new WaitForEndOfFrame();
        }
        m_light.intensity = 0;
    }
    public void SetLight(float Intensity, float lerpSpeed)
    {
        StopAllCoroutines();
        StartCoroutine(setLightCoru(Intensity, lerpSpeed));
    }
    private IEnumerator setLightCoru(float intensity, float lerpSpeed)
    {
        float currdurr = 0f;
        while (currdurr < 1)
        {
            currdurr += Time.deltaTime / lerpSpeed;
            m_light.intensity = Mathf.Lerp(m_light.intensity, intensity, currdurr);
            yield return new WaitForEndOfFrame();
        }

    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }
    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
