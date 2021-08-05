using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamShake : MonoBehaviour
{
    public static CamShake instance;
    private CinemachineVirtualCamera m_cam;
    private float shakeTimer;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        m_cam = GetComponent<CinemachineVirtualCamera>();
    }
    public void callCamShake(float duration, float intensity)
    {
        StartCoroutine(camShakeCoru(duration, intensity));
    }
    private IEnumerator camShakeCoru(float duration, float intensity)
    {
        float currDurr = 0;
        Debug.Log("camshake start");
        while (currDurr < 1)
        {
            CinemachineBasicMultiChannelPerlin perlin = m_cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            currDurr += Time.deltaTime / duration;
            perlin.m_AmplitudeGain = Mathf.Lerp(intensity, 0, currDurr);
            yield return new WaitForEndOfFrame();
        }
        Debug.Log("camshake stop");
    }
}
