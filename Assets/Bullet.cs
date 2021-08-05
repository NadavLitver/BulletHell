using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector2 selfDir;
    [SerializeField]
    internal float speed;
    [SerializeField,Header("Time To Live")]
    private float TTL = 10;
    private void OnEnable()
    {
        Invoke("SelfDestroy", TTL);
    }
    private void FixedUpdate()
    {
        transform.Translate(selfDir * speed * Time.fixedDeltaTime);
    }
    public void SetMovement(Vector2 dir)
    {
        selfDir = dir;
    }
    void SelfDestroy()
    {
        gameObject.SetActive(false);
    }
}
