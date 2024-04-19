using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    [SerializeField] private List<GameObject> _lineRenderers;
    [SerializeField] private List<GameObject> _paintingObject;
    [SerializeField] private GameObject Brush;
    

    //private LineRenderer lineRenderer;
    private int saveCounter = 0;

   // public List<Vector3> positionsDict = new List<Vector3>();
     //Dictionary<int, Vector3> positions = new Dictionary<int, Vector3>();
     private Datas data;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Save();
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            Load();
        }
    }

    private void Save()
    {
        SaveLine();
        SetPaintColor();
    }

    private void Load()
    {
        LoadLine();
        LoadPaintColor();
    }

    private void SaveLine()
    {
        _lineRenderers = GameObject.FindGameObjectsWithTag("brush").ToList();

        foreach (var item in _lineRenderers)
        {
            int positionCount = item.GetComponent<LineRenderer>().positionCount;
            for (int i = 0; i < item.GetComponent<LineRenderer>().positionCount; i++)
            {
               
                PlayerPrefs.SetFloat(saveCounter + "LinePositionX_" + i, item.GetComponent<LineRenderer>().GetPosition(i).x);
                PlayerPrefs.SetFloat(saveCounter + "LinePositionY_" + i, item.GetComponent<LineRenderer>().GetPosition(i).y);
                PlayerPrefs.SetFloat(saveCounter + "LinePositionZ_" + i, item.GetComponent<LineRenderer>().GetPosition(i).z);

            }
            PlayerPrefs.SetInt(saveCounter +"LinePositionCount", positionCount);
            SaveColor(saveCounter+"color",item.GetComponent<LineRenderer>().startColor);
            PlayerPrefs.SetFloat(saveCounter + "size",item.GetComponent<LineRenderer>().startWidth);
            PlayerPrefs.Save();
            saveCounter++;

        }

        PlayerPrefs.SetInt("lineAmount", saveCounter);
        saveCounter = 0;



    }
    
    private void LoadLine()
    {
        if (PlayerPrefs.HasKey("lineAmount"))
        {
            var lineAmount = PlayerPrefs.GetInt("lineAmount");
            print(lineAmount);
            for (int j = 1; j < lineAmount; j++)
            {
                var _brush =Instantiate(Brush);
                var line = _brush.GetComponent<LineRenderer>();
                //line.SetWidth(PlayerPrefs.GetFloat(j + "size"),PlayerPrefs.GetFloat(j + "size"));
                line.SetWidth(PlayerPrefs.GetFloat(j + "size"),PlayerPrefs.GetFloat(j + "size"));
                _brush.GetComponent<Brush>().Size =PlayerPrefs.GetFloat(j + "size");

                print("start: " +PlayerPrefs.GetFloat(j+"size"));
            
                int positionCount = PlayerPrefs.GetInt(j +"LinePositionCount");
                Vector3[] positions = new Vector3[positionCount];
            
                for (int i = 0; i < positionCount; i++)
                {
                    float x = PlayerPrefs.GetFloat(j+"LinePositionX_" + i);
                    float y = PlayerPrefs.GetFloat(j+"LinePositionY_" + i);
                    float z = PlayerPrefs.GetFloat(j+"LinePositionZ_" + i);
                    positions[i] = new Vector3(x, y, z);
                }
            
                line.positionCount = positionCount;
                line.SetPositions(positions);
                line.startColor = GetColor(j + "color");
                line.endColor = GetColor(j + "color");
                print(PlayerPrefs.GetFloat(j+"size"));
                

            }
            
        }
        
        
        
    }

    private void SaveColor(string value,Color color)
    {
        
        if(color.Equals(Color.blue))
            PlayerPrefs.SetString(value,"blue");
        else if(color.Equals(Color.red))
            PlayerPrefs.SetString(value,"red");
        else if(color.Equals(Color.yellow))
            PlayerPrefs.SetString(value,"yellow");
        else if(color.Equals(Color.green))
            PlayerPrefs.SetString(value,"green");
        else if(color.Equals(Color.gray))
            PlayerPrefs.SetString(value,"brown");
        else if(color.Equals(Color.cyan))
            PlayerPrefs.SetString(value,"cyan");
        else if(color.Equals(Color.black))
            PlayerPrefs.SetString(value,"black");
        else if(color.Equals(Color.white))
            PlayerPrefs.SetString(value,"white");
    }
    
    private Color GetColor(string value)
    {
        var color = PlayerPrefs.GetString(value);
        if (color.Equals("blue"))
            return Color.blue;
        else if (color.Equals("red"))
            return Color.red;
        else if (color.Equals("yellow"))
            return Color.yellow;
        else if (color.Equals("green"))
            return Color.green;
        else if (color.Equals("brown"))
            return Color.gray;
        else if (color.Equals("cyan"))
            return Color.cyan;
        else if (color.Equals("black"))
            return Color.black;
        else if (color.Equals("white"))
            return Color.white;
        else
        {
            return Color.white;
        }
    }

    private void SetPaintColor()
    {
        _paintingObject = GameObject.FindGameObjectsWithTag("paintingObject").ToList();
        var colorCouter = 0;

        foreach (var item in _paintingObject)
        {
            SaveColor(colorCouter+"paintingObjectColor",item.GetComponent<SpriteRenderer>().color);
        }
        
    }

    private void LoadPaintColor()
    {
        _paintingObject = GameObject.FindGameObjectsWithTag("paintingObject").ToList();
        var colorCouter = 0;
        foreach (var item in _paintingObject)
        {

            item.GetComponent<SpriteRenderer>().color = GetColor(colorCouter + "paintingObjectColor");
        }
        
    }
    
    
}
