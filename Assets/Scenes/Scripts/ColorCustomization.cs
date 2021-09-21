using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ColorCustomization : MonoBehaviour
{
    public Color[] colors;
    public Material car;
    public void ChangeColors(int ColorIndex)
    {
        car.color = colors[ColorIndex];
    }
}
