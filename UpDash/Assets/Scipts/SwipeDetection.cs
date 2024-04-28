using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    public static bool canSwipe = true;
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

    private Vector2 SwipeDirection;

    public bool canSwipe2 = true;

    public ButtonActions actions;
    
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
            if(canSwipe){
                
                Vector2 Distance = currentPosition - startTouchPosition;
            }
            
            if(stopTouch == true && startDash == true){
                startDash = false;
            }
            if( !stopTouch){
                
                if(Vector2.Distance(currentPosition, startTouchPosition) > swipeRange && LPS.dashCount - 1 >= 0){
                    
                    holding = false;
                    //print("SWIPE");
                    stopTouch = true;
                    
                    if(canSwipe && canSwipe2){
                        startDash = true;
                        LPS.dashCount = LPS.dashCount - 1;
                        LPS.dashing = true;
                        dirDash = (currentPosition - startTouchPosition).normalized; 
                        var angleInput = Mathf.Atan2(dirDash.x, dirDash.y) * Mathf.Rad2Deg;
                        canSwipe2 = false;
                    }else if(!canSwipe){
                        SwipeDirection = (currentPosition-startTouchPosition).normalized;
                        if(Mathf.Abs(SwipeDirection.x) > Mathf.Abs(SwipeDirection.y)){
                            if(SwipeDirection.x <= 0 ){
                                print("LEFT");
                            }else{
                                print("RIGHT");
                            }
                        }else{
                            if(SwipeDirection.y <= 0 ){
                                print("DOWN");
                            }else{
                                print("UP");
                                //actions.ToLevels();
                            }
                        }
                    }
                    
                    
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
            canSwipe2 = true;
            holding = false;
            if(canSwipe){
                LPS.dashing = false;
            }
            
            Vector2 Distance = endTouchPosition - startTouchPosition;
            if(Vector2.Distance(currentPosition, startTouchPosition) < tapRange)
            {
                print("Tap");
                
                
            }
        }

        
    }
    
    

}


