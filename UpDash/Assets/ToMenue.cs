using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToMenue : MonoBehaviour
{
    
    public GameObject backpanel;
    public void ToMenu(){
        LeanTween.moveLocal(backpanel, new Vector3(0,0,0), .75f).setEase(LeanTweenType.easeInOutCubic);
        SwipeDetection.canSwipe = false;
    }
}
