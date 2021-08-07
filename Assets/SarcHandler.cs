﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SarcHandler : MonoBehaviour
{
    private const string openRefID = "IsOpen";

    [SerializeField] private Animator m_anim;

    [SerializeField] private Transform spawnTrans;

    private void Start()
    {
        Close();
    }

    public void Open()
    {
        m_anim.SetBool(openRefID, true);
    }
    public void Close()
    {
        m_anim.SetBool(openRefID, false);
    }

    public void Spawn(GameObject go)
    {
        Instantiate(go, spawnTrans.position, Quaternion.identity, transform);
    }

}