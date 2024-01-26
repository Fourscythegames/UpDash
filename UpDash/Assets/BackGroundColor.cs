using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BackGroundColor : MonoBehaviour
{
    public float startPosition;
    private float lastPosition;
    public Image bgImage;
    public float colorIndexH = 0;
    private float colorIndexOutH;
    public float colorIndexS = 0;
    private float colorIndexOutS;
    public float colorIndexV = 0;
    private float colorIndexOutV;
    public int totalCycles;
    
    void FixedUpdate()
    {
        //var difference = (transform.position.y - startPosition)/100;
        var lastPosDif = (transform.position.y - lastPosition);
        lastPosition = transform.position.y;
        

        //print(difference);
        //print(lastPosDif);
        colorIndexH = colorIndexH + lastPosDif;
        if(colorIndexH >= 359){
            colorIndexH = 0;
            totalCycles += 1;
        }else if(colorIndexH <=0 ){
            colorIndexH = 360;
            totalCycles -= 1;
        }

        print(totalCycles);
        colorIndexOutH = colorIndexH / 360;
        //print(colorIndexOutH);
        colorIndexOutS = colorIndexS / 100;
        colorIndexOutV = (colorIndexV - (15*totalCycles)) / 100;
        bgImage.material.color =  UnityEngine.Color.HSVToRGB(colorIndexOutH,colorIndexOutS,colorIndexOutV);
        
    }
}
