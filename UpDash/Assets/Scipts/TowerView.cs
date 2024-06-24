using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerView : MonoBehaviour
{
    public List<GameObject> allButtons = new List<GameObject>();
    public List<GameObject> allLevels = new List<GameObject>();
    public GameObject path;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < allButtons.Count; i++)
            {
                allButtons[i].transform.position = new Vector2(path.transform.position.x, allLevels[i].transform.position.y);
            }

    }

    
}
