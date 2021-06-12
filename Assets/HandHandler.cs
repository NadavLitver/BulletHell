using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandHandler : MonoBehaviour
{
    [SerializeField]
    Transform FirePoint;

    private void Update()
    {
        transform.rotation = new Quaternion(FirePoint.rotation.x, FirePoint.rotation.y, -FirePoint.rotation.z + 90f,FirePoint.rotation.w);
    }

}
