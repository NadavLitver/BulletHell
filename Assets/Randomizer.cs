using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Randomizer 
{
   public static int ReturnRandomNum(int Range) => Random.Range(0, Range);
   public static float ReturnRandomFloat(float Range) => Random.Range(0, Range);
    public static int GetOneOrMinusOne() => Random.Range(0, 2) * 2 - 1;

    
}
