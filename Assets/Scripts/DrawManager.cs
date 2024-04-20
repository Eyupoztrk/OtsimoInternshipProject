using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawManager : MonoBehaviour
{
   public static DrawManager intance;

   private void Awake()
   {
      intance = this;
   }

   
  
   public Stack<LineRenderer> brushes = new Stack<LineRenderer>();
   public GameObject[] brushess;
   public Brush activeBrush;
   public bool canUseEraser;
   public bool canDraw;
   public bool ClickedEraserButton;
   private string activeColorOfBrush;
   public int sortingLayerCounter = 1;
   public RawImage brushSizeImage;

   
   
   /// <summary>
   /// When we want to change the color of the line to be drawn,
   /// we use this function according to the color parameter.
   /// </summary>
   /// <param name="color"></param>
   public void SetBrushColor(string color)
   {
     activeColorOfBrush = color;
     canUseEraser = false;
     UIManager.instance.isColorPanelOpen = true;
     UIManager.instance.OpenColorPanel();
     
      if(color.Equals("blue"))
        activeBrush.SetColor(ColorEnum.Colors.blue);
      else if(color.Equals("red"))
        activeBrush.SetColor(ColorEnum.Colors.red);
      else if(color.Equals("yellow"))
        activeBrush.SetColor(ColorEnum.Colors.yellow);
      else if(color.Equals("green"))
        activeBrush.SetColor(ColorEnum.Colors.green);
      else if(color.Equals("brown"))
        activeBrush.SetColor(ColorEnum.Colors.brown);
      else if(color.Equals("cyan"))
        activeBrush.SetColor(ColorEnum.Colors.cyan);
      else if(color.Equals("black"))
        activeBrush.SetColor(ColorEnum.Colors.black); 
      else if(color.Equals("white"))
        activeBrush.SetColor(ColorEnum.Colors.white);
   }

   public void IncreaseSizeOfBrush()
   {
     if (activeBrush.Size < 1.0f)
     {
       activeBrush.Size = activeBrush.Size + 0.1f;
       activeBrush.SetSize();
       var size = brushSizeImage.rectTransform.localScale;
       brushSizeImage.rectTransform.localScale = new Vector3(size.x +0.1f,size.y + 0.1f,size.z +0.1f);
     }
        
   }

   public void DecreaseSizeOfBrush()
   {
     if (activeBrush.Size > 0.1f)
     {
       activeBrush.Size = activeBrush.Size - 0.1f;
       activeBrush.SetSize();
       var size = brushSizeImage.rectTransform.localScale;
       brushSizeImage.rectTransform.localScale = new Vector3(size.x -0.1f,size.y - 0.1f,size.z -0.1f);
     }
       
   }

   
   /// <summary>
   /// It sets the eraser, if we can use the eraser, that is,
   /// if the eraser is selected, the active Brush color will be white and it will paint the canvas white.
   /// </summary>
   public void SetEraser()
   {
     canUseEraser = !canUseEraser;

     if (canUseEraser)
     {
       UIManager.instance.SetImage(UIManager.instance.brushObject,UIManager.instance.EraserImage);
       PaintManager.instance.CanPaint = false;
       Stamp.instance.canUserStamp = false;
       activeBrush.SetColor(ColorEnum.Colors.white);
       
     }
     else
     {
       UIManager.instance.SetImage(UIManager.instance.brushObject,UIManager.instance.penImage);
       SetBrushColor(activeColorOfBrush);
       
     }
   }

   
   // Allows us to draw and deactivates other drawing tools
   public void SetPen()
   {
     UIManager.instance.SetImage(UIManager.instance.brushObject,UIManager.instance.penImage);
     PaintManager.instance.CanPaint = false;
     Stamp.instance.canUserStamp = false;
     canDraw = true;
     Stamp.instance.canUserStamp = false;
     
   }

   public void Undo()
   {
     
     //It takes the lines in the stack and deletes the last one every time this function is called.
     if(brushes.Count != 0)
       Destroy(brushes.Pop().gameObject);
   }

   public void RemoveAll()
   {
     foreach (var item in brushes)
     {
       Destroy(brushes.Pop().gameObject);
     }
   }

   
   
   


}
