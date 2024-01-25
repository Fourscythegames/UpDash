using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowSystem : MonoBehaviour
{

    public GameObject player;
    
    public float cameraXPos;
    
    void LateUpdate()
    {
        transform.position = new Vector2(cameraXPos,player.transform.position.y);
    }
}
