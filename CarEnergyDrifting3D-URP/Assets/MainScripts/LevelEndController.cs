using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndController : MonoBehaviour
{
    public GameObject carBodyM, flameM, flameL, smoke, GreenLight, RedLight, YellowLight, TxtTap, handIconTap,textTap;
    public static bool lvlEndEnter, delayedClick, endDriftCntrl;
    public static float clickCounter;

    public float CarRotSmooth;
    public Vector3 CarRot, HandRot;
    float carRx;

    void Start()
    {
        RedLight.SetActive(true);
        YellowLight.SetActive(false);
        GreenLight.SetActive(false);
        clickCounter = 0;
        lvlEndEnter = delayedClick = endDriftCntrl = false;
        HandRot.x = 40;
    }

    public void FixedUpdate()
    {
        if (lvlEndEnter)
        {
            if (CarController.carStopped && clickCounter < 6)
            {
                TxtTap.SetActive(true);

            }

            if (carRx == 2)
            {
                flameM.SetActive(false);
                CarRot.x = 0;
            }

            if (delayedClick == false)
            {
                StartCoroutine(DelayForClickCounter());
            }
            else if (delayedClick)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    ClickCount();
                }
            }
         
            carRx = carBodyM.transform.rotation.eulerAngles.x;

            Vector3 desiredRot = new Vector3(CarRot.x, CarRot.y, CarRot.z);
            Quaternion smoothedRot = Quaternion.Euler(desiredRot);

            carBodyM.transform.rotation = Quaternion.Slerp(carBodyM.transform.rotation, smoothedRot, CarRotSmooth * Time.deltaTime);

        }
    }

    void ClickCount()
    {
        if (clickCounter >= 3)
        {
            RedLight.SetActive(false);
            YellowLight.SetActive(true);
        }
        if (clickCounter >= 6)
        {
            Debug.Log("ClickDone EXECUTE DRIFTT!!");

            TxtTap.SetActive(false);
            YellowLight.SetActive(false);
            GreenLight.SetActive(true);
            flameL.SetActive(true);
            endDriftCntrl = true;
            CarRot.x = 4;
        }
        else
        {
            if (CarRot.x == 0)
            {             
                CarRot.x = 2;
            }
            else { CarRot.x = 0; }

            Instantiate(smoke, smoke.transform.position, smoke.transform.rotation);
            smoke.SetActive(true);
            clickCounter += 1;
            Debug.Log("Click: " + clickCounter + " || carRot.z: " + CarRot.z);

        }

    }
    
    public IEnumerator DelayForClickCounter()
    {
        yield return new WaitForSeconds(2.7f);
        delayedClick = true;
    }
}
