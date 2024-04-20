using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class FxManager : MonoBehaviour
{
    public static FxManager instance;

    private void Awake()
    {
        instance = this;
    }

    public GameObject AfterDrawingFX;
    public GameObject AfterPaintingFX;

    public void SetActiveFx(GameObject obj,Vector2 position)
    {
        var clone = Instantiate(obj, position, quaternion.identity);
        StartCoroutine(RemoveFx(clone));
    }

    IEnumerator RemoveFx(GameObject obj)
    {
        yield return new WaitForSeconds(3f);
        Destroy(obj);
    }
}
