using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HMatrix2D
{
    public float[,] entries { get; set; } = new float[3, 3];

    public HMatrix2D()
    {
        entries = new float[3, 3];
    }

    public HMatrix2D(float[,] multiArray)
    {
        for (int y = 0; y < 3; y++) // Row
        {
            for (int x = 0; x < 3; x++) // Column
            {
                entries[y,x] = multiArray[x,y]; // set the value of entries to value of multiArray
            }
        }
    }

    public HMatrix2D(float m00, float m01, float m02,
             float m10, float m11, float m12,
             float m20, float m21, float m22)
    {
        entries = new float[3, 3];

        entries[0, 0] = m00;
        entries[0, 1] = m01;
        entries[0, 2] = m02;

        entries[1, 0] = m10;
        entries[1, 1] = m11;
        entries[1, 2] = m12;

        entries[2, 0] = m20;
        entries[2, 1] = m21;
        entries[2, 2] = m22;

    }

    public static HMatrix2D operator +(HMatrix2D left, HMatrix2D right)
    {
        HMatrix2D result = new HMatrix2D();

        for (int y = 0; y < 3; y++) // Row
        {
            for (int x = 0; x < 3; x++) // Column
            {
                result.entries[y,x] = left.entries[y,x] + right.entries[y,x];
            }
        }
        return result;
    }

    public static HMatrix2D operator -(HMatrix2D left, HMatrix2D right)
    {
        HMatrix2D result = new HMatrix2D();

        for (int y = 0; y < 3; y++) // Row
        {
            for (int x = 0; x < 3; x++) // Column
            {
                result.entries[y, x] = left.entries[y, x] - right.entries[y, x];
            }
        }
        return result;
    }

    public static HMatrix2D operator *(HMatrix2D left, float scalar)
    {
        HMatrix2D result = new HMatrix2D();

        for (int y = 0; y < 3; y++) // Row
        {
            for (int x = 0; x < 3; x++) // Column
            {
                result.entries[y, x] = left.entries[y, x] * scalar;
            }
        }
        return result;
    }

    //// Note that the second argument is a HVector2D object
    ////
    public static HVector2D operator *(HMatrix2D left, HVector2D right)
    {
        return new HVector2D
        (
            left.entries[0, 0] * right.x + left.entries[1, 0] * right.y + left.entries[2, 0],
            left.entries[0, 1] * right.x + left.entries[1, 1] * right.y + left.entries[2, 1]
        );
    }

    //// Note that the second argument is a HMatrix2D object
    ////
    public static HMatrix2D operator *(HMatrix2D left, HMatrix2D right)
    {
        return new HMatrix2D
        (
            left.entries[0, 0] * right.entries[0, 0] + left.entries[0, 1] * right.entries[1, 0] + left.entries[0, 2] * right.entries[2, 0],
            left.entries[0, 0] * right.entries[0, 1] + left.entries[0, 1] * right.entries[1, 1] + left.entries[0, 2] * right.entries[2, 1],
            left.entries[0, 0] * right.entries[0, 2] + left.entries[0, 1] * right.entries[1, 2] + left.entries[0, 2] * right.entries[2, 2],

            left.entries[1, 0] * right.entries[0, 0] + left.entries[1, 1] * right.entries[1, 2] + left.entries[1, 2] * right.entries[2, 2],
            left.entries[1, 0] * right.entries[0, 2] + left.entries[1, 1] * right.entries[1, 2] + left.entries[1, 2] * right.entries[2, 2],
            left.entries[1, 0] * right.entries[0, 2] + left.entries[1, 1] * right.entries[1, 2] + left.entries[1, 2] * right.entries[2, 2],

            left.entries[2, 0] * right.entries[0, 0] + left.entries[2, 1] * right.entries[1, 2] + left.entries[2, 2] * right.entries[2, 2],
            left.entries[2, 0] * right.entries[0, 2] + left.entries[2, 1] * right.entries[1, 2] + left.entries[2, 2] * right.entries[2, 2],
            left.entries[2, 0] * right.entries[0, 2] + left.entries[2, 1] * right.entries[1, 2] + left.entries[2, 2] * right.entries[2, 2]
        );
    }

    public static bool operator ==(HMatrix2D left, HMatrix2D right)
    {
        for (int y = 0; y < 3; y++) // Row
        {
            for (int x = 0; x < 3; x++) // Column
            {
                if (left.entries[y,x] != right.entries[y,x]) 
                { 
                    return false; 
                }
            } 
        }
        return true;
    }

    public static bool operator !=(HMatrix2D left, HMatrix2D right)
    {
        return !(left == right);
    }

    //public override bool Equals(object obj)
    //{
    //    // your code here
    //}

    //public override int GetHashCode()
    //{
    //    // your code here
    //}

    //public HMatrix2D transpose()
    //{
    //    return // your code here
    //}

    //public float getDeterminant()
    //{
    //    return // your code here
    //}

    public void setIdentity()
    {
        for (int y = 0; y < 3; y++) // Row
        {
            for (int x = 0; x < 3; x++) // Column
            {
                if (x == y)
                {
                    entries[y,x] = 1;
                }
                else 
                {
                    entries[y,x] = 0;
                }
            }
        }
    }

    public void setTranslationMat(float transX, float transY)
    {
        // your code here
    }

    public void setRotationMat(float rotDeg)
    {
        // your code here
    }

    public void setScalingMat(float scaleX, float scaleY)
    {
        // your code here
    }

    public void Print()
    {
        string result = "";
        for (int r = 0; r < 3; r++)
        {
            for (int c = 0; c < 3; c++)
            {
                result += entries[r, c] + "  ";
            }
            result += "\n";
        }
        Debug.Log(result);
    }
}
