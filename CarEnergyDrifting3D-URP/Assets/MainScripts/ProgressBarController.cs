using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarController : MonoBehaviour
{
    [SerializeField] private Transform endLineTransform, carTransform, barPoint;
    [SerializeField] private Image fillForm;
    Vector3 endLinePos;
    float fullDistance, realtimeDistance;

    void Start()
    {
        endLinePos = endLineTransform.position;
        fullDistance = getDistance();
        Debug.Log("Distance: " + fullDistance);
    }

    void Update()
    {
        if (Glass.controlGlassSolid == 0 && LevelEndController.lvlEndEnter == false && RoadGlassController.roadGlassBroke == false)
        {
            realtimeDistance = getDistance();
            float progressValue = Mathf.InverseLerp(fullDistance, 0f, realtimeDistance);

            if (realtimeDistance > 10 && fullDistance >= 100 && transform.localPosition.x <= 480)
            {
                updateProgressBar(progressValue);
            }

        }
    }

    private float getDistance()
    {
        //  return Vector3.Distance(carTransform.position, endLinePos);
        return (endLinePos - carTransform.position).sqrMagnitude;
    }

    private void updateProgressBar(float value)
    {
    //    Debug.Log("ProgressValue: " + value);
        fillForm.fillAmount = value;

    }

}
