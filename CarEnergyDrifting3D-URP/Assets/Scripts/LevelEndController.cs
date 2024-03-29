using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndController : MonoBehaviour
{
    public AudioSource tapTap_sfx;
    public GameObject carBody, flameM, flameL, smoke, GreenLight, RedLight, YellowLight, TxtTap, textTap, flameLooped;
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
        flameLooped.SetActive(false);
        clickCounter = 0;
        lvlEndEnter = delayedClick = endDriftCntrl = false;
        HandRot.x = 40;
    }

    public void Update()
    {
        if (lvlEndEnter)
        {
            if (clickCounter == 6 && endDriftCntrl == false)
            {
                TxtTap.SetActive(false);
                YellowLight.SetActive(false);
                GreenLight.SetActive(true);
                flameLooped.SetActive(true);
                endDriftCntrl = true;
                CarRot.x = 4;
            }

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

            if (clickCounter != 6)
            {
                carRx = carBody.transform.rotation.eulerAngles.x;

                Vector3 desiredRot = new Vector3(CarRot.x, CarRot.y, CarRot.z);
                Quaternion smoothedRot = Quaternion.Euler(desiredRot);

                carBody.transform.rotation = Quaternion.Slerp(carBody.transform.rotation, smoothedRot, CarRotSmooth * Time.deltaTime);
            }
    
        }
        else
        {
            RedLight.SetActive(true);
            YellowLight.SetActive(false);
            GreenLight.SetActive(false);
            flameLooped.SetActive(false);
            TxtTap.SetActive(false);
        }
    }

    void ClickCount()
    {
        if (clickCounter == 3)
        {
            RedLight.SetActive(false);
            YellowLight.SetActive(true);
        }
        if (clickCounter == 6)
        {
            TxtTap.SetActive(false);
            YellowLight.SetActive(false);
            GreenLight.SetActive(true);
            flameLooped.SetActive(true);
            endDriftCntrl = true;
            CarRot.x = 4;
        }
        if (clickCounter < 6)
        {
            if (CarRot.x == 0)
            {
                CarRot.x = 2;
            }
            else { CarRot.x = 0; }

            Instantiate(smoke, smoke.transform.position, smoke.transform.rotation);
            smoke.SetActive(true);
            clickCounter += 1;

            if (PlayerPrefs.GetString("sfx") == "on") { tapTap_sfx.Play(); }
            Debug.Log("Click: " + clickCounter + " || carRot.z: " + CarRot.z);
        }
    }

    public IEnumerator DelayForClickCounter()
    {
        yield return new WaitForSeconds(2.7f);
        delayedClick = true;
    }
}
