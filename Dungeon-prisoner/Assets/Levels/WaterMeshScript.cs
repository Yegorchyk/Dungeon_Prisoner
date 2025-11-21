using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMeshScript : MonoBehaviour
{
    public string sortingLayerName = string.Empty; //initialization before the methods
    public int orderInLayer = 0;
    public Renderer MyRenderer;



   


void SetSortingLayer()
    {
        if (sortingLayerName != string.Empty)
        {
            MyRenderer.sortingLayerName = sortingLayerName;
            MyRenderer.sortingOrder = orderInLayer;
        }
    }
    void Start()
    {
       
         SetSortingLayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
