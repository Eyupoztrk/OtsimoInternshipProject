using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brush : MonoBehaviour
{
    [SerializeField] private LineRenderer line;
    public LineRenderer Line
    {
        get
        {
            return line;
        }
    }
    [SerializeField] private float size;
    public float Size
    {
        set
        {
            size = value;
        }
        get
        {
            return size;
        }
    }
   


    private void Start()
    {
        // set line size when Brush active
        SetSize();
    }

    public void SetSize()
    {
        line.SetWidth(size,size);
    }
    
    /// <summary>
    /// Sets the colors of the lines by taking them from the Color Enum class
    /// </summary>
    /// <param name="color"></param>

    public void SetColor(ColorEnum.Colors color)
    {
        
        if (color.Equals(ColorEnum.Colors.red))
        {
            line.startColor = Color.red;
            line.endColor = Color.red;
        }
        
        else if (color.Equals(ColorEnum.Colors.blue))
        {
            line.startColor = Color.blue;
            line.endColor = Color.blue;
        }
        
        else if (color.Equals(ColorEnum.Colors.yellow))
        {
            line.startColor = Color.yellow;
            line.endColor = Color.yellow;
        }
        else if (color.Equals(ColorEnum.Colors.brown))
        {
            line.startColor = Color.grey;
            line.endColor = Color.grey;
        }
        else if (color.Equals(ColorEnum.Colors.black))
        {
            line.startColor = Color.black;
            line.endColor = Color.black;
        }
        else if (color.Equals(ColorEnum.Colors.cyan))
        {
            line.startColor = Color.cyan;
            line.endColor = Color.cyan;
        }
        else if (color.Equals(ColorEnum.Colors.green))
        {
            line.startColor = Color.green;
            line.endColor = Color.green;
        }  
        
        else if (color.Equals(ColorEnum.Colors.white))
        {
            line.startColor = Color.white;
            line.endColor = Color.white;
        }
        
        UIManager.instance.SetColor(UIManager.instance.sizeInfoCircle,line.startColor);
    }
}
