using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleBulletHandler : MonoBehaviour
{
    [SerializeField]
    float rotationSpeed = 50;

    public Vector2 dir;
    public float speed;
    [SerializeField, Header("Time To Live")]
    private float TTL = 10;
    private void OnEnable()
    {
        StartCoroutine(SelfDestroy());
        if (GameManager.gm.isBulletSpeedDoubled)
            speed *= 1.5f;
          
    }
        // Update is called once per frame
    void FixedUpdate()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z + Time.time * rotationSpeed), 40f);
        transform.position += new Vector3(dir.x * speed, dir.y * speed) * Time.fixedDeltaTime;
    }
     IEnumerator SelfDestroy()
     {
        yield return new WaitForSeconds(TTL);
        Destroy(gameObject);

     }

}
