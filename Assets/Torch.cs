using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    Animator m_anim;

    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;
    private void Awake()
    {
        m_anim = GetComponent<Animator>();
        m_anim.speed = Random.Range(minSpeed, maxSpeed);
    }


}
