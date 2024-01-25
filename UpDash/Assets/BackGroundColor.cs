using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BackGroundColor : MonoBehaviour
{
    public float startPosition;
    public Image bgImage;
    private int colorIndex = 0;
    
    void Update()
    {
        var difference = transform.position.y - startPosition;
        //bgImage.material.color =  UnityEngine.Color.HSVToRGB(colorIndex,48,95);
        
    }
}
