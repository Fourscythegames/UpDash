using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChecks : MonoBehaviour
{
    public bool grounded;

    public LayerMask groundLayer;

    public bool wallInRange;
    public bool wallAlmostInRange;

    private LivePlayerStats LPS;

    
    void Start()
    {
        
        LPS = this.GetComponent<LivePlayerStats>();
    }
    
    void FixedUpdate()
    {
        if(LPS.dashing == false){
            grounded = IsGrounded();
        }

        
        wallInRange = IsWall();
        
    }
    bool IsWall(){
        Vector2 position = transform.position;
        Vector2 direction = Vector2.right;
        Vector2 direction2 = Vector2.left;
        float distance = 0.75f;

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        //Debug.DrawRay(position, direction,Color.green, distance);

        RaycastHit2D hit2 = Physics2D.Raycast(position, direction2, distance, groundLayer);
        //Debug.DrawRay(position, direction2,Color.green, distance); 

        if (hit.collider != null || hit2.collider != null) {
            
            return true;
        }
        return false;
    }

    
    bool IsGrounded() {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 1f;
        
        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        //Debug.DrawRay(position, direction,Color.green, distance);
        if (hit.collider != null) {
            LPS.dashCount = LPS.maxDashCount;
            
            
            return true;
        }
        
        return false;
    }  

    // void OnCollisionEnter2D(Collision2D col)
    // {
    //     if(col.gameObject.layer == 6){
    //         wallInRange = true;
    //         print("GEHEHE");
    //     }
    // }     
    // void OnCollisionExit2D(Collision2D col)
    // {
    //     if(col.gameObject.layer == 6){
    //         wallInRange = false;
    //     }
    // }     
}
