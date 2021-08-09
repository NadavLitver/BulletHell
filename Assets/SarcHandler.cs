using System.Collections;
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
        AudioManager.am.PlaySound(AudioManager.am.Sarc, .4f, true, 0.1f);
        m_anim.SetBool(openRefID, true);
    }
    public void Close()
    {
        m_anim.SetBool(openRefID, false);
    }

    public void Spawn(GameObject go)
    {
      //  Vector3 scale = go.transform.localScale;
        Instantiate(go, spawnTrans.position, Quaternion.identity);
    }

}
