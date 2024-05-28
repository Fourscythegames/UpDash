using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFollowScript : MonoBehaviour
{
    //public List<GameObject> towerNodes = new List<GameObject>();
    private GameObject selectedNode;
    public float zeroXValue;

    private bool fingerON;

    public float speed;

    private Vector3 offset;
    private float slowed;


    private Vector3 lastframe;
    public bool once;
    public float damping;
    private bool lockedON;

    private Vector3 startTouchPosition; 
    private Vector3 currentPosition; 

    public GameObject towerFollow;
    public Vector3 lockPos;
    
    private bool here;

    private bool allreadyletgo;
    private float velLast;
    private string closestNode;
        
    public void TowerSwipe(){
        if(!once){
            once = true;
            lastframe = towerFollow.transform.position;
        }
        
        // Debug.DrawLine(towerStartpos, new Vector3(towerStartpos.x + 300, towerStartpos.y, towerStartpos.z), Color.red);
        // Debug.DrawLine(new Vector3(towerStartpos.x, towerStartpos.y + change, towerStartpos.z), new Vector3(towerStartpos.x + 300, towerStartpos.y + change, towerStartpos.z), Color.red);
        //print(offset + " foof");
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began )
        {
            //startTouchPosition = Input.GetTouch(0).position;
            //print("Vel" + velLast + "alll" + allreadyletgo);
            if(velLast  > 0.01f && allreadyletgo){
                //print(Vector3.Distance(towerFollow.transform.position, lastframe));
                currentPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 10f));
                lastframe = towerFollow.transform.position;
                //print("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
                
            }
            startTouchPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 10f));
            offset = startTouchPosition - currentPosition;
            //print(offset);
            here = true;
            fingerON = true;
            lockedON = false;
            allreadyletgo = false;

        }
        if(fingerON && !here){
            //print("Holding");
            currentPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 10f));
            
            offset = startTouchPosition - currentPosition;
            //print(offset + " KASDKSADKASDK" + velLast);
            
            var after = new Vector3(zeroXValue,(towerFollow.transform.position.y + offset.y),-10);
            if(offset.y > 0.01 || offset.y < -0.01){
                //print("YUP SRILL HERE");
                towerFollow.transform.position = Vector3.Lerp(towerFollow.transform.position, after, Time.deltaTime * speed);
            }
            
        }
            
        
        here = false;
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            fingerON = false;
            slowed = (towerFollow.transform.position - lastframe).y;
            allreadyletgo = true;
        }
        
        if(!fingerON && lockedON == false){
            //print(slowed + " jdafsofja");
            slowed = Mathf.Lerp(slowed, 0, Time.deltaTime * damping);


            
            //print(slowed);
            towerFollow.transform.position = new Vector3(towerFollow.transform.position.x, towerFollow.transform.position.y + slowed, towerFollow.transform.position.z);
        }
        if(Mathf.Abs(slowed) < 0.05){
            //lockedON = true;
            // float dis = 1000000;
            // foreach (var item in towerNodes)
            // {
            //     var dist = Vector3.Distance(towerFollow.transform.position,item.transform.position);
            //     if(dist < dis){
            //         dis = dist;
            //         //lockPos = new Vector3(zeroXValue, item.transform.position.y, item.transform.position.z);
            //         closestNode = item.name;
            //     }
            // }
            
        }
        
        
        // if(lockedON && !fingerON){
            
            
        //     towerFollow.transform.position = Vector3.Lerp(towerFollow.transform.position, lockPos, Time.deltaTime * speed);
        //     if(Vector3.Distance(towerFollow.transform.position, lockPos) < 0.07){
        //         lockedON = false;
        //     }
        // }
        velLast = Vector3.Distance(towerFollow.transform.position, lastframe);
        lastframe = towerFollow.transform.position;
        
    }
    public void ZeroINOnPos(GameObject gameObject1){
        this.transform.position = new Vector3(zeroXValue, gameObject1.transform.position.y, gameObject1.transform.position.z);
        
    }
    

}
