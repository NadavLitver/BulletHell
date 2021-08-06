using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionHandler : MonoBehaviour
{
    public UnityEngine.Experimental.Rendering.Universal.Light2D m_light;
    public SpriteRenderer m_sr;
    private void Start()
    {
        Deactivate();
    }
    public void Activate()
    {
        m_sr.enabled = true;
        m_light.enabled = true;
    }
    public void Deactivate()
    {
        m_sr.enabled = false;
        m_light.enabled = false;
    }
}
