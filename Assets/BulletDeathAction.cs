using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDeathAction : MonoBehaviour
{
    [SerializeField]
    Transform Parent;
    private void Awake()
    {
        Parent = transform.parent;
    }
    private void OnEnable()
    {
        StartCoroutine(SetParentBack());
    }
    private IEnumerator SetParentBack()
    {
        yield return new WaitForSeconds(0.5f);
        transform.parent = Parent;
        transform.localPosition = Vector3.zero;
        
    }
}
