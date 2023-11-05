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

    public static Hex<float> HexDirection(List<Hex<float>> hexes, int direction)
    {
        if (direction >= 0 && direction < hexes.Count)
        {
            return hexes[direction];
        }
        else
        {
            throw new ArgumentOutOfRangeException("direction", "Invalid direction value");
        }
    }

    public static List<Hex<float>> GenerateHexagons(Hex<float> center, int range)
    {
        List<Hex<float>> results = new List<Hex<float>>();

        // Define constants for better clarity
        float sqrt3 = (float)Math.Sqrt(3);
        float hexSize = 0.6f;

        for (float q = -range, v = -range; v <= range + sqrt3 * hexSize; v += sqrt3 * (hexSize))
        {
            float check = Math.Max(-3f, ((3f / 4f * sqrt3 * (0.7f)) * (-v  - range)));
            float r1 = (check != -range) ? (3f / 4f * sqrt3 * (0.7f)) * (-v - range) : Math.Max(-2.835f, -v - range);
            float r2 = Math.Min(range, -v + range);

            q += (check != -range) ? sqrt3 * (hexSize / 2f) : sqrt3 * (hexSize);

            for (float r = r1, t = q; r <= r2 + 0.165f; r += (3f / 4f) * sqrt3 * 0.7f, t += sqrt3 * (hexSize / 2f))
            {
                results.Add(HexAdd(center, new Hex<float>(t, r)));
            }
        }

        return results;
    }

    // Check what the current hex's neightbor`
    public static Hex<float> HexNeighbor(List<Hex<float>> hexes, Hex<float> currentHex, int direction)
    {
        return HexAdd(currentHex, HexDirection(hexes, direction));
    }

    // Check if both hex is equal
    public static bool HexEquality(Hex<float> a, Hex<float> b)
    {
        return a.Equals(b);
    }

    public static Hex<float> HexAdd(Hex<float> a, Hex<float> b)
    {
        return new Hex<float>(a.Q + b.Q, a.R + b.R);
    }

    public static Hex<float> HexSubtract(Hex<float> a, Hex<float> b)
    {
        return new Hex<float>(a.Q - b.Q, a.R - b.R);
    }

    public static Hex<float> HexMultiply(Hex<float> a, Hex<float> b)
    {
        return new Hex<float>(a.Q * b.Q, a.R * b.R);
    }

    // Returns the distance of hex a and b
    public static float HexDistance(Hex<float> a, Hex<float> b)
    {
        Hex<float> hex = HexSubtract(a, b);
        return (Math.Abs(hex.Q) + Math.Abs(hex.Q + hex.R) + Math.Abs(hex.R)) / 2;
    }
}