using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexManager : MonoBehaviour
{
    public int hexRange;
    private List<Hex<float>> hexes = new List<Hex<float>>();
    public GameObject hexObject;

    private void Awake()
    {
        hexes = Hex<float>.GenerateHexagons(new Hex<float>(0f, 0f), hexRange);
        
        for(int i = 0; i < hexes.Count; i++)
        {
            Vector3 position = new Vector3(hexes[i].Q, 0, hexes[i].R);
            Instantiate(hexObject, position, Quaternion.identity);
        }
    }
}
