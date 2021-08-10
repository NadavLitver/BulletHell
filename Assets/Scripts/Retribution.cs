using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Retribution : Ability
{
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            Destroy(gameObject);
        }
    }
}
