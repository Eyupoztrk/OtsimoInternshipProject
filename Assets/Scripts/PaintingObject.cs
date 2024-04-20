using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingObject : MonoBehaviour
{
    [SerializeField] private Bucket _bucket;
    
    // When Clicked Object
    private void OnMouseDown()
   {
       // "CanPaint" Allows Painting
       if (PaintManager.instance.CanPaint)
       {
           // Get color From Bucket and set Object Color
           gameObject.GetComponent<SpriteRenderer>().color = _bucket.color;
           
           // Remove all previously drawn lines and paints the entire canvas in one color
           RemoveAll(gameObject.GetComponent<Drawing>().LocalBrushes);
       }
         
   }

    // Actions to be taken when the Mouse Up
    private void OnMouseUp()
    {
        if (PaintManager.instance.CanPaint)
        {
            SoundManager.instance.PlaySound(SoundManager.instance.clickUpSound);
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            FxManager.instance.SetActiveFx(FxManager.instance.AfterPaintingFX,mousePos);
        }
        
    }

    /// <summary>
    /// Gets all drawn lines from Gameobject type List and deletes them
    /// </summary>
    /// <param name="list"></param>
    private void RemoveAll(List<GameObject> list)
    {
        foreach (var item in list)
        {
            Destroy(item);
        }
        list.Clear();
    }
}
