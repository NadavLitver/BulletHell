using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCursorOnScreen : MonoBehaviour
{

    private float targetScale = 1.2f;
    private float idleScale = 1;

    private void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Input.mousePosition;
        transform.rotation = Quaternion.Euler(0, 0, Vector2.Distance(Vector2.zero, transform.position) * 0.2f);
    }
    public void Shoot()
    {
        
    }
    private IEnumerator ShootCoru()
    {
        float currDurr = 0;
        float duration = 0.2f;
        while (currDurr < 1)
        {
            currDurr += Time.deltaTime / (duration / 2);
            transform.localScale = Vector3.one * Mathf.Lerp(idleScale, targetScale, currDurr);
            yield return new WaitForEndOfFrame();
        }
        while (currDurr > 0)
        {
            currDurr -= Time.deltaTime / (duration / 2);
            transform.localScale = Vector3.one * Mathf.Lerp(idleScale, targetScale, currDurr);
            yield return new WaitForEndOfFrame();
        }
    }
}
