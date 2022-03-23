using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBarController : MonoBehaviour
{
   
    void Start()
    {
        
    }

    void Update()
    {
        if (Glass.controlGlassSolid == 0 && LevelEndController.lvlEndEnter == false)
        {
            transform.position += new Vector3(0.002f, 0, 0);
        }
    }
}
