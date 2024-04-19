using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class StampedObject : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (Stamp.instance.canUserStamp)
        {
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;

           var stamp = Instantiate(Stamp.instance.activeStamp, mousePos, quaternion.identity);
           stamp.GetComponent<SpriteRenderer>().sortingOrder++;
           // stamp.GetComponent<SpriteRenderer>().sortingOrder = DrawManager.intance.brushes.Peek().GetComponent<LineRenderer>().sortingOrder +1;
        }
        
       
    }
}
