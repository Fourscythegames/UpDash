using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    public static bool canSwipe = true;
    private Vector3 startTouchPosition; 
    private Vector3 currentPosition; 
    private Vector3 endTouchPosition; 
    private bool stopTouch = false;
    public float swipeRangeNormal;
    public float swipeRangeWall;
    public float swipeRange;
    public float tapRange;

    public bool holding;

    public bool startDash = false;
    public Vector2 dirDash;
    
    private LivePlayerStats LPS;

    private Vector2 SwipeDirection;

    public bool canSwipe2 = true;

    public ButtonActions actions;
    public GameObject towerFollows;

    public GameObject SwipeGuide;
    public GameObject SwipeGuideLil;

    
    void Start()
    {
        LPS = this.GetComponent<LivePlayerStats>();
        swipeRange = swipeRangeNormal;
        
    }
    void Update()
    {
        
        
        if(CameraSwitching.cameraPriorityState == 2){
            //towerFollows.GetComponent<TowerFollowScript>().TowerSwipe();
        }else{
            Swipe();
        }
       
        var worldPos1 = Camera.main.ScreenToWorldPoint(new Vector3(startTouchPosition.x, startTouchPosition.y, 10f));
        var woldPos2 = Camera.main.ScreenToWorldPoint(new Vector3(currentPosition.x, currentPosition.y, 10f));
        Debug.DrawLine(startTouchPosition, currentPosition, Color.red);

    }


    public void Swipe(){
        
        

        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began )
        {
            startTouchPosition = Input.GetTouch(0).position;
            SwipeGuide.transform.position = startTouchPosition;
            SwipeGuideLil.transform.position = startTouchPosition;
            
        }
        
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            currentPosition = Input.GetTouch(0).position;
            SwipeGuideLil.transform.position = currentPosition;
            
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
            
            LPS.dashing = false;
            
            
            Vector2 Distance = endTouchPosition - startTouchPosition;
            if(Vector2.Distance(currentPosition, startTouchPosition) < tapRange)
            {
                print("Tap");
                
                
            }
        }

        
    }
    

    
    
    

}


