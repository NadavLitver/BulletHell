using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExample : LiveBody
{
    protected override void AfterTakeDamage()
    {
        this.GetComponent<SpriteRenderer>().color = Color.red;
    }
}
