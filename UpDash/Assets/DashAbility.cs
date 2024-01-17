using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAbility : MonoBehaviour {
	
    [SerializeField] SwipeDetection swipeDetection;
	public DashState dashState;
	public float dashTimer;
	public float maxDash = 20f;
    public float DashPower = 5f;

	public Vector2 savedVelocity;
	
	void Update () 
	{
		switch (dashState) 
		{
		case DashState.Ready:
			var isDashKeyDown = swipeDetection.startDash;
			if(isDashKeyDown)
			{
				savedVelocity = this.GetComponent<Rigidbody2D>().velocity;
				this.GetComponent<Rigidbody2D>().velocity =  swipeDetection.dirDash * DashPower;
				dashState = DashState.Dashing;
			}
			break;
		case DashState.Dashing:
			dashTimer += Time.deltaTime * 3;
			if(dashTimer >= maxDash)
			{
				dashTimer = maxDash;
				this.GetComponent<Rigidbody2D>().velocity = savedVelocity;
				dashState = DashState.Cooldown;
			}
			break;
		case DashState.Cooldown:
			dashTimer -= Time.deltaTime;
			if(dashTimer <= 0)
			{
				dashTimer = 0;
				dashState = DashState.Ready;
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
