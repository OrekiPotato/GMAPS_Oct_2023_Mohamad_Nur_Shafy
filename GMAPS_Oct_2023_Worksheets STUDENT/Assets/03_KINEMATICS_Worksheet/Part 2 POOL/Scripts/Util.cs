using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util
{
    public static float FindDistance(HVector2D p1, HVector2D p2)
    {
        float deltaX = p2.x - p1.x;
        float deltaY = p2.y - p1.y; 

        return Mathf.Sqrt(deltaX * deltaX + deltaY * deltaY);
    }
}

