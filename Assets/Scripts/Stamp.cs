using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamp : MonoBehaviour
{
    public static Stamp instance;

    private void Awake()
    {
        instance = this;
    }

    public GameObject activeStamp;
    public bool canUserStamp;

    public void SetStamp( )
    {
        if (canUserStamp)
        {
            var clicedObject = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
            var stampObject = clicedObject.transform.GetChild(0);
            var image = stampObject.GetComponent<Image>().sprite;
            activeStamp.GetComponent<SpriteRenderer>().sprite = image;
        
            UIManager.instance.isStampPanelOpen = true;
            UIManager.instance.OpenStampPanel();
            UIManager.instance.brushObject.GetComponent<Image>().sprite = activeStamp.GetComponent<SpriteRenderer>().sprite;
        
            DrawManager.intance.canDraw = false;
            DrawManager.intance.canUseEraser = false;
            PaintManager.instance.CanPaint = false;
        }
       
       
    }

    public void OpenStampPanel()
    {
        //UIManager.instance.isStampPanelOpen = true;
        canUserStamp = true;
        
        UIManager.instance.OpenStampPanel();
    }
}
