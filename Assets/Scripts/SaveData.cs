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
    private int saveCounter = 0;

    private void Start()
    {
        //Loading saved data if continue button is pressed
        if (OpenSceneManager.instance.isContinue)
        {
            // With SceneIndex we understand which scene it comes from
            Load(OpenSceneManager.instance.sceneIndex);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Save(1);
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            Load(0);
        }
    }
    

    public void Save(int sceneIndex)
    {
        SaveLine(sceneIndex);
        SetPaintColor(sceneIndex);
    }

    private void Load(int sceneIndex)
    {
        LoadLine(sceneIndex);
        LoadPaintColor(sceneIndex);
    }

    private void SaveLine(int sceneIndex)
    {
        _lineRenderers = GameObject.FindGameObjectsWithTag("brush").ToList();

        foreach (var item in _lineRenderers)
        {
            int positionCount = item.GetComponent<LineRenderer>().positionCount;
            for (int i = 0; i < item.GetComponent<LineRenderer>().positionCount; i++)
            {
               
                PlayerPrefs.SetFloat(saveCounter + "LinePositionX_" + i +""+sceneIndex, item.GetComponent<LineRenderer>().GetPosition(i).x);
                PlayerPrefs.SetFloat(saveCounter + "LinePositionY_" + i +""+sceneIndex, item.GetComponent<LineRenderer>().GetPosition(i).y);
                PlayerPrefs.SetFloat(saveCounter + "LinePositionZ_" + i +""+sceneIndex, item.GetComponent<LineRenderer>().GetPosition(i).z);

            }
            PlayerPrefs.SetInt(saveCounter +"LinePositionCount" +""+sceneIndex, positionCount);
            SaveColor(saveCounter+"color"+""+sceneIndex,item.GetComponent<LineRenderer>().startColor);
            PlayerPrefs.SetFloat(saveCounter + "size" +""+sceneIndex,item.GetComponent<LineRenderer>().startWidth);
            PlayerPrefs.Save();
            saveCounter++;

        }

        PlayerPrefs.SetInt("lineAmount" +""+sceneIndex, saveCounter);
        saveCounter = 0;



    }
    
    private void LoadLine(int sceneIndex)
    {
        if (PlayerPrefs.HasKey("lineAmount" +""+sceneIndex))
        {
            var lineAmount = PlayerPrefs.GetInt("lineAmount" +""+sceneIndex);
            print(lineAmount);
            for (int j = 1; j < lineAmount; j++)
            {
                var _brush =Instantiate(Brush);
                var line = _brush.GetComponent<LineRenderer>();
                line.SetWidth(PlayerPrefs.GetFloat(j + "size" +""+sceneIndex),PlayerPrefs.GetFloat(j + "size" +""+sceneIndex));
                _brush.GetComponent<Brush>().Size =PlayerPrefs.GetFloat(j + "size" +""+sceneIndex);

                print("start: " +PlayerPrefs.GetFloat(j+"size" +""+sceneIndex));
            
                int positionCount = PlayerPrefs.GetInt(j +"LinePositionCount" +""+sceneIndex);
                Vector3[] positions = new Vector3[positionCount];
            
                for (int i = 0; i < positionCount; i++)
                {
                    float x = PlayerPrefs.GetFloat(j+"LinePositionX_" + i +""+sceneIndex);
                    float y = PlayerPrefs.GetFloat(j+"LinePositionY_" + i +""+sceneIndex);
                    float z = PlayerPrefs.GetFloat(j+"LinePositionZ_" + i +""+sceneIndex);
                    positions[i] = new Vector3(x, y, z);
                }
            
                line.positionCount = positionCount;
                line.SetPositions(positions);
                line.startColor = GetColor(j + "color" +""+sceneIndex);
                line.endColor = GetColor(j + "color" +""+sceneIndex);
                print(PlayerPrefs.GetFloat(j+"size") +""+sceneIndex);
                

            }
            
        }
        
        
        
    }

    private void SaveColor(string value,Color color)
    {
        
        if(color.Equals(Color.blue))
            PlayerPrefs.SetString(value,"blue" );
        else if(color.Equals(Color.red))
            PlayerPrefs.SetString(value,"red" );
        else if(color.Equals(Color.yellow))
            PlayerPrefs.SetString(value,"yellow" );
        else if(color.Equals(Color.green))
            PlayerPrefs.SetString(value,"green" );
        else if(color.Equals(Color.gray))
            PlayerPrefs.SetString(value,"brown" );
        else if(color.Equals(Color.cyan))
            PlayerPrefs.SetString(value,"cyan" );
        else if(color.Equals(Color.black))
            PlayerPrefs.SetString(value,"black" );
        else if(color.Equals(Color.white))
            PlayerPrefs.SetString(value,"white" );
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

    private void SetPaintColor(int sceneIndex)
    {
        _paintingObject = GameObject.FindGameObjectsWithTag("paintingObject").ToList();
        var colorCouter = 0;

        foreach (var item in _paintingObject)
        {
            SaveColor(colorCouter+"paintingObjectColor"+""+sceneIndex,item.GetComponent<SpriteRenderer>().color);
            colorCouter++;
        }
        
    }

    private void LoadPaintColor(int sceneIndex)
    {
        _paintingObject = GameObject.FindGameObjectsWithTag("paintingObject").ToList();
        var colorCouter = 0;
        foreach (var item in _paintingObject)
        {

            item.GetComponent<SpriteRenderer>().color = GetColor(colorCouter + "paintingObjectColor" +""+sceneIndex);
            colorCouter++;
        }
        
    }
    
    
}
