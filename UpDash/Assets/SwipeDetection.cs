using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{

    private Vector2 startTouchPosition; 
    private Vector2 currentPosition; 
    private Vector2 endTouchPosition; 
    private bool stopTouch = false;
    public float swipeRange;
    public float tapRange;
    
    void Update()
    {
        Swipe();
    }
    public void Swipe(){

        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
        }
        
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            currentPosition = Input.GetTouch(0).position;
            Vector2 Distance = currentPosition - startTouchPosition;
            if( !stopTouch){
                print(Vector2.Distance(currentPosition, startTouchPosition));    
                stopTouch = true;       
            }
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            stopTouch = false;
            Vector2 Distance = endTouchPosition - startTouchPosition;
            if(Mathf.Abs(Distance.x) < tapRange && Mathf.Abs(Distance.y) < tapRange)
            {
                print("Tap");
            }
        }

        
    }

}


