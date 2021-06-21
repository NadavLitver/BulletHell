using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBlink : MonoBehaviour
{
    [SerializeField] private SpriteRenderer m_sprite;
    [SerializeField] private UnityEngine.Experimental.Rendering.Universal.Light2D m_light;
    public void Blink(float intensity, float lerpSpeed)
    {
        StartCoroutine(BlinkCoru(intensity, lerpSpeed));
    }
    private IEnumerator BlinkCoru(float intensity, float lerpSpeed)
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
        yield return null;
    }
}
