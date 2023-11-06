using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Hex<T>
{
    public T Q { get; }
    public T R { get; }

    public Hex(T q, T r)
    {
        Q = q;
        R = r;
    }

    public static List<Hex<float>> GenerateHexagons(Hex<float> center, int range)
    {
        List<Hex<float>> results = new List<Hex<float>>();

        for (int q = -range; q <= range; q++)
        {
            float r1 = Math.Max(-range, -q - range);
            float r2 = Math.Min(range, -q + range);

            for (float r = r1; r <= r2; r++)
            {
                float t = CalculateDiagonal(q, r);
                Hex<float> hex = new Hex<float>(t, r);
                results.Add(HexAdd(center, hex));
            }
        }

        return results;
    }

    private static float CalculateDiagonal(float q, float r)
    {
        return q + (r * 0.5f);
    }

    public static Hex<float> HexAdd(Hex<float> a, Hex<float> b)
    {
        return new Hex<float>(a.Q + b.Q, a.R + b.R);
    }
}