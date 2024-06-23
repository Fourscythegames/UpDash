using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirControl : MonoBehaviour
{
    public PlayerChecks playerChecks;
    public GameObject lilGuide;
    public GameObject bigGuide;

    public float airControlForce;

    void Update()
    {
        if(LivePlayerStats.livePlayerStats.dashing == true && playerChecks.inAir == true){
            if(lilGuide.transform.position.x > bigGuide.transform.position.x){
                var vel = this.GetComponent<Rigidbody2D>().velocity;
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(vel.x + airControlForce, vel.y);
            }else{
                var vel = this.GetComponent<Rigidbody2D>().velocity;
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(vel.x - airControlForce, vel.y);
            }
            if(lilGuide.transform.position.y < bigGuide.transform.position.y){
                var vel = this.GetComponent<Rigidbody2D>().velocity;
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(vel.x, vel.y - airControlForce);
            }
            
        }
    }
}
