using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Randomizer 
{
   public static int ReturnRandomNum(int MinRange, int MaxRange ) => Random.Range(MinRange, MaxRange);
   public static float ReturnRandomFloat(float MinRange, float MaxRange) => Random.Range(MinRange, MaxRange);
    public static int GetOneOrMinusOne() => Random.Range(0, 2) * 2 - 1;

    
}
