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

    public bool startDash = false;
    public Vector2 dirDash;
    
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
                
                if(Vector2.Distance(currentPosition, startTouchPosition) > swipeRange){
                    startDash = true;
                    //print("SWIPE");
                    //print((currentPosition - startTouchPosition).normalized);   
                    dirDash = (currentPosition - startTouchPosition).normalized; 
                    var angleInput = Mathf.Atan2(dirDash.x, dirDash.y) * Mathf.Rad2Deg; //FInd the better version of degrees that does have negative and use that
                    //print(angleInput);
                    stopTouch = true;
                    Check8Primary(angleInput);
                } 
                
            }
            
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            stopTouch = false;
            startDash = false;
            Vector2 Distance = endTouchPosition - startTouchPosition;
            if(Vector2.Distance(currentPosition, startTouchPosition) < tapRange)
            {
                print("Tap");
            }
        }

        
    }
    
    int[] primeAngles = new int[]{0, 45, 90, -180, -90, -45};
    private void Check8Primary(float angleIN){
        float closestValue = 10000;
        int closestIndex = 0;
        for (int i = 0; i < primeAngles.Length; i++) {
            var angleOut = angleIN - primeAngles[i];
            //print(angleOut+ "    --- " + i + "    -- " + primeAngles[i]);
            if(angleOut < closestValue){
                closestValue = angleOut;
                closestIndex = i;
            }
            
            
        }
        //print(primeAngles[closestIndex]);
        

    }

}


