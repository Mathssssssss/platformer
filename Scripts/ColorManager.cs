using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public static ColorManager Instance;

    // Color List
    public  Color[] CellColor;

    void Awake()
    {
        if(Instance == null)
        {
            Instance =this;
        }
    } 
}
