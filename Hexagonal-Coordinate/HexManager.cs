using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class HexManager : MonoBehaviour
{
    public int hexRange;

    private const float XOffSet = 1.02f;
    private const float ZOffSet = 0.88f;

    private List<Hex<float>> hexes = new List<Hex<float>>();
    public GameObject hexObject;

    private void Awake()
    {
        hexes = Hex<float>.GenerateHexagons(new Hex<float>(0f, 0f), hexRange);

        foreach (Hex<float> hex in hexes)
        {
            Vector3 position = new Vector3(hex.Q, 0, 0) * XOffSet +
                               new Vector3(0, 0, hex.R) * ZOffSet + 
                               Vector3.zero;

            Instantiate(hexObject, position, Quaternion.identity);
        }
    }

}
