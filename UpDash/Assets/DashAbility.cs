using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAbility : MonoBehaviour {
	
    [SerializeField] SwipeDetection swipeDetection;
	public DashState dashState;
	public float dashTimer;
	public float maxDash = 20f;
    public float DashPower = 5f;
	private float oldGravity;
	private Vector2 dashDirection;

	public Vector2 savedVelocity;
	private void Start()
	{
		oldGravity = this.GetComponent<Rigidbody2D>().gravityScale;
	}
	void Update () 
	{
		switch (dashState) 
		{
		case DashState.Ready:
			var isDashKeyDown = swipeDetection.startDash;
			if(isDashKeyDown)
			{
				savedVelocity = this.GetComponent<Rigidbody2D>().velocity;
				if(swipeDetection.outPutDirection == 0 || swipeDetection.outPutDirection == 360){
					dashDirection = new Vector2(1f,0f);
				}
				if(swipeDetection.outPutDirection == 45){
					dashDirection = new Vector2(0.707106f,0.707106f);
				}
				if(swipeDetection.outPutDirection == 90){
					dashDirection = new Vector2(0f,1f);
				}
				if(swipeDetection.outPutDirection == 135){
					dashDirection = new Vector2(-0.707106f,0.707106f);
				}
				if(swipeDetection.outPutDirection == 180){
					dashDirection = new Vector2(-1f,0f);
				}
				if(swipeDetection.outPutDirection == 225){
					dashDirection = new Vector2(-0.707106f,-0.707106f);
				}
				if(swipeDetection.outPutDirection == 270){
					dashDirection = new Vector2(0f,-1f);
				}
				if(swipeDetection.outPutDirection == 315){
					dashDirection = new Vector2(0.707106f,-0.707106f);
				}
				
				this.GetComponent<Rigidbody2D>().velocity =  dashDirection * DashPower;
				this.GetComponent<Rigidbody2D>().gravityScale = 0f;
				dashState = DashState.Dashing;
			}
			break;
		case DashState.Dashing:
			dashTimer += Time.deltaTime * 3;
			if(dashTimer >= maxDash)
			{
				dashTimer = maxDash;
				//this.GetComponent<Rigidbody2D>().velocity = savedVelocity;
				dashState = DashState.Cooldown;
			}
			break;
		case DashState.Cooldown:
			dashTimer -= Time.deltaTime;
			if(dashTimer <= 0)
			{
				dashTimer = 0;
				dashState = DashState.Ready;
				this.GetComponent<Rigidbody2D>().gravityScale = oldGravity;
			} 
			break;
		}
	}
}

public enum DashState 
{
	Ready,
	Dashing,
	Cooldown
}
