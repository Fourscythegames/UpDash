using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TowerFollowScript : MonoBehaviour
{
    
    public bool touchingScreen;

    private Vector3 startTouchPosition; 
    private Vector3 currentPosition; 
    private float slowed;
    private Vector3 lastframe;

    public float speed;
    public float zeroXValue;
    public float damping;
    public GameObject player;

   
    void Update()
    {
        TowerSelectControl();
    }
    public void resetPosToPlayer(){
        this.transform.position = new Vector2(this.transform.position.x, player.transform.position.y);
        lastframe = new Vector2(this.transform.position.x, player.transform.position.y);
    }
    public void TowerSelectControl(){//this func hadles the swipe movement for the level select screen.
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began )
        {
            touchingScreen = true;
            startTouchPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 10f));
        }
        

        if(touchingScreen){
            currentPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 10f));

            var offset = startTouchPosition - currentPosition;
            var after = new Vector3(zeroXValue,(this.transform.position.y + offset.y),-10);

            if(offset.y > 0.01 || offset.y < -0.01){
                
                this.transform.position = Vector3.Lerp(this.transform.position, after, Time.deltaTime * speed);
            }
        }else if(touchingScreen == false){
            slowed = Mathf.Lerp(slowed, 0, Time.deltaTime * damping);
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + slowed, this.transform.position.z);
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            touchingScreen = false;
            slowed = (this.transform.position - lastframe).y;
            
           
        }
        //print(this.transform.position - lastframe);
        lastframe = this.transform.position;
    }
}
