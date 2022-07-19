using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f, followSpeed, lvlEndSmoothSpeed, CamZoomSmooth, boosts_smoothSpeed;
    public Vector3 offset, lvlEndOffset, lookLvlEnd, lvlEndDriftCamPos, lvlEndDriftCamRot, offset_speedUp;

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
         /*   if (CarController.MainSpeed <= 1 || CarController.MainCarWeight <= 1)
            {
                Vector3 desiredPosition = new Vector3(0, target.position.y + offset.y, target.position.z + offset.z);
                Vector3 SmoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

                transform.position = SmoothedPosition;
            }
         */
            if (CarController.MainSpeed >= 2)
            {
                Vector3 desiredPosition = new Vector3(0, target.position.y + offset_speedUp.y, target.position.z + offset_speedUp.z);
                Vector3 SmoothedPosition = Vector3.Lerp(transform.position, desiredPosition, boosts_smoothSpeed);

                transform.position = SmoothedPosition;
            }
            else
            {
                Vector3 desiredPosition = new Vector3(0, target.position.y + offset.y, target.position.z + offset.z);
                Vector3 SmoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

                transform.position = SmoothedPosition;
            }
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
                    Vector3 desiredPosition = new Vector3(lvlEndDriftCamPos.x, lvlEndDriftCamPos.y, transform.position.z);
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
