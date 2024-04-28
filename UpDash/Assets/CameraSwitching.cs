using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSwitching : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera gameCam;

    [SerializeField]
    private CinemachineVirtualCamera menuCam;

    [SerializeField]
    private CinemachineVirtualCamera towerCam;

    private int camIndex;
    //0 = game, 1 = menu

    public void SwitchPriority(int switchVal){
        if(switchVal == 0){
            gameCam.Priority = 1;
            menuCam.Priority = 0;
            towerCam.Priority = 0;
        }

        if(switchVal == 1){
            gameCam.Priority = 0;
            menuCam.Priority = 1;
            towerCam.Priority = 0;
        }
        if(switchVal == 2){
            gameCam.Priority = 0;
            menuCam.Priority = 0;
            towerCam.Priority = 1;
        }
    }


}
