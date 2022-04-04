using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndUI_Controller : MonoBehaviour
{
    public Transform LevelEnd_UI;
    bool LevelEndUI_Delay;
    Vector3 newPosUp = new Vector3(0, 65f, 215);
    //  Vector3 newPosDown = new Vector3(0, -1200f, -2377f);
    private Vector3 endVelocity = Vector3.zero;

    void Start()
    {
        LevelEndUI_Delay = false;
        LevelEnd_UI.localPosition = new Vector3(0, -3000f, 215);
    }

    void Update()
    {
        if (LevelEndController.endDriftCntrl)
        {
            if (LevelEndUI_Delay == false)
            {
                StartCoroutine(delayLevelEndUI());
            }
            else if (LevelEndUI_Delay)
            {
                LevelEnd_UI.localPosition = Vector3.SmoothDamp(LevelEnd_UI.localPosition, newPosUp, ref endVelocity, 0.2f);
            }
            
        }
    }

    public IEnumerator delayLevelEndUI()
    {
        yield return new WaitForSeconds(6.5f);
        LevelEndUI_Delay = true;
    }
}
