using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class StampedObject : MonoBehaviour
{
    /// <summary>
    /// It works for the object to be stamped, and when that object is clicked,
    /// it copies the object there according to the mouse position.
    /// </summary>
    private void OnMouseDown()
    {
        if (Stamp.instance.canUserStamp)
        {
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;

           var stamp = Instantiate(Stamp.instance.activeStamp, mousePos, quaternion.identity);
           stamp.GetComponent<SpriteRenderer>().sortingOrder++;
        }
        
       
    }
}
