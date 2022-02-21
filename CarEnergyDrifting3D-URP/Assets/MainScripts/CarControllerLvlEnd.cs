using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControllerLvlEnd : MonoBehaviour
{
   
    void Start()
    {
     
    }
    
    void FixedUpdate()
    {
        if (LevelEndController.clickCounter >= 10)
        {
            
            
        }

    }

    public IEnumerator DelayCarBody()
    {
        yield return new WaitForSeconds(0.2f);
        
    }
}

