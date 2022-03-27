using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBarController : MonoBehaviour
{
    [SerializeField] private Transform filForm, endLineTransform, carTransform;
    Vector3 fillBar, endLinePos;
    float fullDistance, realtimeDistance;

    void Start()
    {
        endLinePos = endLineTransform.position;
        fillBar = filForm.localScale;
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
        else if (Glass.controlGlassSolid == 1)
        {
            filForm.localScale = fillBar;
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
        transform.position += new Vector3(value, 0, 0) * Time.deltaTime / 8.4f;
    }

}
