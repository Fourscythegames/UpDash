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

    public bool holding;

    public bool startDash = false;
    public Vector2 dirDash;
    
    private LivePlayerStats LPS;
    
    void Start()
    {
        LPS = this.GetComponent<LivePlayerStats>();
    }
    void Update()
    {
        Swipe();
    }


    public void Swipe(){

        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began )
        {
            startTouchPosition = Input.GetTouch(0).position;
        }
        
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            currentPosition = Input.GetTouch(0).position;
            Vector2 Distance = currentPosition - startTouchPosition;
            if(stopTouch == true && startDash == true){
                startDash = false;
            }
            if( !stopTouch){
                
                if(Vector2.Distance(currentPosition, startTouchPosition) > swipeRange && LPS.dashCount - 1 >= 0){
                    startDash = true;
                    holding = false;
                    LPS.dashCount = LPS.dashCount - 1;
                    LPS.dashing = true;
                    //print("SWIPE");
                    //print((currentPosition - startTouchPosition).normalized);   
                    dirDash = (currentPosition - startTouchPosition).normalized; 
                    var angleInput = Mathf.Atan2(dirDash.x, dirDash.y) * Mathf.Rad2Deg; //FInd the better version of degrees that does have negative and use that
                    //print(angleInput);
                    stopTouch = true;
                    
                } else if(Vector2.Distance(currentPosition, startTouchPosition) < swipeRange) {
                    //print("Holding");
                    holding = true;
                }
                
            }
            
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            stopTouch = false;
            startDash = false;
            holding = false;
            LPS.dashing = false;
            Vector2 Distance = endTouchPosition - startTouchPosition;
            if(Vector2.Distance(currentPosition, startTouchPosition) < tapRange)
            {
                print("Tap");
            }
        }

        
    }
    
    

}


