using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.EventSystems;
using UnityEngine;


public class Drawing : MonoBehaviour
{
    private LineRenderer lineCopy;
    public List<GameObject> LocalBrushes;
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

            /* lineCopy.sortingOrder = DrawManager.intance.sortingLayerCounter + 1;
             DrawManager.intance.sortingLayerCounter++;*/
        }
        
    }

  private void OnMouseDrag()
   {
      
       Debug.Log("drawwing");
       if(DrawManager.intance.canDraw)
         Draw();
   }

  private void OnMouseExit()
  {
      
      DrawManager.intance.canDraw = false;
  }

  private void OnMouseUp()
  {
      isInObject = false;
  }

  private void OnMouseEnter()
  {
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

  public void SetLine(LineRenderer line)
  {
      lineCopy = line;
  }

  public void SetBrush()
  {
      _brush = DrawManager.intance.activeBrush;
  }



}
