using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummyOrb : MonoBehaviour
{
   public Vector2 velocity;
    private void FixedUpdate()
    {
        transform.Translate(velocity * Time.deltaTime);
    }
}
