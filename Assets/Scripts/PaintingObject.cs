using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingObject : MonoBehaviour
{
    [SerializeField] private Bucket _bucket;
    private void OnMouseDown()
   {
       if (PaintManager.instance.CanPaint)
       {
           gameObject.GetComponent<SpriteRenderer>().color = _bucket.color;
           RemoveAll(gameObject.GetComponent<Drawing>().LocalBrushes);
       }
         
   }

    private void RemoveAll(List<GameObject> list)
    {
        foreach (var item in list)
        {
            Destroy(item);
            
        }
        list.Clear();
    }
}
