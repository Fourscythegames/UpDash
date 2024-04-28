using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabAbility : MonoBehaviour
{
    [SerializeField] SwipeDetection swipeDetection;
    [SerializeField] PlayerChecks playerChecks;


    private bool touchHolding;

    
    private LivePlayerStats LPS;


    void Start()
    {
        LPS = this.GetComponent<LivePlayerStats>();
    }
    void LateUpdate()
    {
        touchHolding = swipeDetection.holding;
        
        if((touchHolding && playerChecks.wallInRange)){
            //print("GRABBBBB");
            this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
            LPS.dashCount = LPS.maxDashCount;
        }else {
            this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

        }
    }
}
