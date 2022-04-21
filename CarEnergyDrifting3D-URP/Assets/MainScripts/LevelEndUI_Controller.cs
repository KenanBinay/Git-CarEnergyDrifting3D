using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelEndUI_Controller : MonoBehaviour
{
    public Transform LevelEnd_UI;
    public TMPro.TextMeshProUGUI coinTxt_levelEndUI;
    bool LevelEndUI_Delay,star_Delay;
    Vector3 newPosUp = new Vector3(0, 114, 572);
    //  Vector3 newPosDown = new Vector3(0, -1200f, -2377f);
    private Vector3 endVelocity = Vector3.zero;
    public GameObject tireSkidMarks, _starLeft, _starMid, _starRight;
    int scoreTime;
    void Start()
    {
        LevelEndUI_Delay = star_Delay = false;
        _starLeft.SetActive(false);
        _starMid.SetActive(false);
        _starRight.SetActive(false);
        LevelEnd_UI.localPosition = new Vector3(0, -3000f, 572);
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

                if (LevelEnd_UI.localPosition.y > -300)
                {
                    tireSkidMarks.SetActive(false);
                }

                if (star_Delay == false)
                {
                    StartCoroutine(delayStarAnim());
                }
                else if (star_Delay)
                {
                    if (scoreTime != CarController.coinVal)
                    {
                        scoreTime++;
                        coinTxt_levelEndUI.text = scoreTime.ToString();
                    }
                }

            }
        }
    }

    public IEnumerator delayLevelEndUI()
    {
        yield return new WaitForSeconds(6.5f);
        LevelEndUI_Delay = true;
    }
    public IEnumerator delayStarAnim()
    {
        yield return new WaitForSeconds(1.5f);
        star_Delay = true;

        if (CarController.coinVal >= 4)
        {
            _starLeft.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            _starMid.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            _starRight.SetActive(true);
        }
        if (CarController.coinVal >= 2)
        {
            _starLeft.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            _starMid.SetActive(true);
        }
        if (CarController.coinVal >= 1)
        {
            _starLeft.SetActive(true);
        }
    }
}
