using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f, followSpeed, lvlEndSmoothSpeed, CamZoomSmooth;
    public Vector3 offset, lvlEndOffset, lookLvlEnd, lvlEndDriftCamPos,lvlEndDriftCamRot;

    public static bool camMovedFinish;
    bool delayWaited;

    private void Start()
    {
        camMovedFinish = false;    
    }

    void FixedUpdate()
    {
        if (LevelEndController.lvlEndEnter == false)
        {
            Vector3 desiredPosition = new Vector3(0, target.position.y + offset.y, target.position.z + offset.z);
            Vector3 SmoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            transform.position = SmoothedPosition;
        }
        else if (LevelEndController.lvlEndEnter)
        {
            if (LevelEndController.clickCounter < 6)
            {
                Vector3 desiredPosition = new Vector3(target.position.x + lvlEndOffset.x, target.position.y + lvlEndOffset.y, target.position.z + lvlEndOffset.z);
                Vector3 desiredLook = new Vector3(target.position.x + lookLvlEnd.x, target.position.y + lookLvlEnd.y, 0);
                Vector3 SmoothedPosition = Vector3.Lerp(transform.position, desiredPosition, lvlEndSmoothSpeed);
                Quaternion smoothedRot = Quaternion.Euler(desiredLook);

                transform.position = SmoothedPosition;
                transform.rotation = Quaternion.Slerp(transform.rotation, smoothedRot, CamZoomSmooth * Time.deltaTime);
            }
            else if (LevelEndController.clickCounter == 6)
            {
                if (delayWaited == false)
                { StartCoroutine(DelayForLvlEndCam()); }
                else if (delayWaited)
                {
                    camMovedFinish = true;
                    Vector3 desiredPosition = new Vector3(lvlEndDriftCamPos.x, lvlEndDriftCamPos.y, lvlEndDriftCamPos.z);
                    Vector3 desiredLook = new Vector3(lvlEndDriftCamRot.x, lvlEndDriftCamRot.y, 0);
                    Vector3 SmoothedPosition = Vector3.Lerp(transform.position, desiredPosition, lvlEndSmoothSpeed);
                    Quaternion smoothedRot = Quaternion.Euler(desiredLook);

                    transform.position = SmoothedPosition;
                    transform.rotation = Quaternion.Slerp(transform.rotation, smoothedRot, CamZoomSmooth * Time.deltaTime);
                }
            }
        }
    }

    public IEnumerator DelayForLvlEndCam()
    {
        yield return new WaitForSeconds(0.5f);

        delayWaited = true;
    }

}
