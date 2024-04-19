using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintManager : MonoBehaviour
{
    public static PaintManager instance;

    private void Awake()
    {
        instance = this;
    }

    public Bucket activeBucket;
    private string activeColorOfBrush;
    public bool CanPaint;
    
    
    public void SetBrushColor(string color)
    {
        UIManager.instance.isColorPanelOpen = true;
        UIManager.instance.OpenColorPanel();

        if (color.Equals("blue"))
            activeBucket.color = Color.blue;
        else if (color.Equals("red"))
            activeBucket.color = Color.red;
        else if (color.Equals("yellow"))
            activeBucket.color = Color.yellow;
        else if (color.Equals("green"))
            activeBucket.color = Color.green;
        else if (color.Equals("brown"))
            activeBucket.color = Color.gray;
        else if (color.Equals("cyan"))
            activeBucket.color = Color.cyan;
        else if (color.Equals("black"))
            activeBucket.color = Color.black;
        else if (color.Equals("white"))
            activeBucket.color = Color.white;
        
        UIManager.instance.SetColor(UIManager.instance.sizeInfoCircle,activeBucket.color);

    }

    public void Paint()
    {
        CanPaint = !CanPaint;
        if (!CanPaint)
        {
            DrawManager.intance.canDraw = true;
        }
        else
        {
            UIManager.instance.SetImage(UIManager.instance.brushObject,UIManager.instance.BucketImage);
            DrawManager.intance.canUseEraser = false;
            DrawManager.intance.canDraw = false;
        }
    }

}
