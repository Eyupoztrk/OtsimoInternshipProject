using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.EventSystems;
using UnityEngine;


public class Drawing : MonoBehaviour
{
    private LineRenderer lineCopy;
    [HideInInspector] public List<GameObject> LocalBrushes;
    private Vector3 previousPosition;
    [SerializeField] private float minDistance;
    private bool isInObject;
    public float size;
    private Brush _brush;


    private void Start()
    {
        _brush = DrawManager.intance.activeBrush;
    }


    private void OnMouseDown()
    {
        //If stamping is not selected, you can perform these operations.
        if (!Stamp.instance.canUserStamp)
        {
            isInObject = true;
            SetBrush();
            DrawManager.intance.canDraw = true;
            var newLine = Instantiate(_brush.Line);
            lineCopy = newLine;
            DrawManager.intance.brushes.Push(lineCopy);
            LocalBrushes.Add(lineCopy.gameObject);
            previousPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        
    }

  private void OnMouseDrag()
   {
       // It works when you drag the mouse and calls the Draw() function if you can draw.
       if(DrawManager.intance.canDraw)
         Draw();
   }

  private void OnMouseExit()
  {
      //If the mouse leaves the drawing area, no drawing will be made.
      DrawManager.intance.canDraw = false;
  }

  private void OnMouseUp()
  {
      isInObject = false;
      SoundManager.instance.PlaySound(SoundManager.instance.clickUpSound);
      var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      FxManager.instance.SetActiveFx(FxManager.instance.AfterDrawingFX,mousePos);
  }

  private void OnMouseEnter()
  {
      // It works if it enters the drawing area again without the mouse up.
      if (isInObject)
      {
          SetBrush();
          DrawManager.intance.canDraw = true;
          var newLine = Instantiate(_brush.Line);
          lineCopy = newLine;
          DrawManager.intance.brushes.Push(lineCopy);
          LocalBrushes.Add(lineCopy.gameObject);
     
          previousPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      }
      
  }

  private void Draw()
   {
       // When dragged, it takes the mouse position and set it to currentPos
       Vector3 currentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
       currentPos.z = 0;

       if (lineCopy != null)
       {
           if(Vector3.Distance(currentPos, previousPosition) > minDistance)
           {
               lineCopy.positionCount++;
               lineCopy.SetPosition(lineCopy.positionCount-1,currentPos);
               previousPosition = currentPos;
           }
       }
      
    

   }
  

  public void SetBrush()
  {
      _brush = DrawManager.intance.activeBrush;
  }



}
