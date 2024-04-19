using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public  class UIManager : MonoBehaviour
{

    public static UIManager instance;

    private void Awake()
    {
        instance = this;
    }

    public GameObject ColorPanel;
    public bool isColorPanelOpen;
    public GameObject sizeInfoCircle;
    public GameObject brushObject;
    public Image penImage;
    public Image BucketImage;
    public Image EraserImage;
    public void SetActivePanel(GameObject panel, bool active)
    {
        if (active)
            panel.SetActive(true);
        else
            panel.SetActive(false);
    }

    public void OpenColorPanel()
    {
        isColorPanelOpen = !isColorPanelOpen;
        SetActivePanel(ColorPanel,isColorPanelOpen);
    }

    public void SetColor(GameObject obj,Color color)
    {
        if(obj.GetComponent<RawImage>() != null)
           obj.GetComponent<RawImage>().color = color; 
        else if(obj.GetComponent<SpriteRenderer>() != null)
           obj.GetComponent<SpriteRenderer>().color = color;
    }

    public void SetImage(GameObject obj,Image image)
    {
        obj.GetComponent<Image>().sprite = image.sprite;
    }
    

    

}
