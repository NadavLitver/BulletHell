using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    [Header("Time To Live"), SerializeField]
    float TTL;
    private void OnEnable()
    {
        StartCoroutine(SelfDestruct());
    }
    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(TTL);
        Destroy(gameObject);
    }
}
