using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDoubleClickListener : MonoBehaviour
{
    [Tooltip("Max duration between 2 clicks in seconds")]
    [Range(0.01f, 0.5f)] public float doubleClickDuration = 0.4f;

    private int clicks = 0;
    private float elapsedTime = 0f;
    public static bool doubleClick;

    private void Update()
    {
        if (clicks == 1 && clicks > 1)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime > doubleClickDuration)
            {
                clicks = 0;
                elapsedTime = 0f;
                doubleClick = false;
            }
        }
    }

    public void OnDoubleClick()
    {
        clicks++;

        if (clicks > 1)
        {
            clicks = 0;
            elapsedTime = 0f;
            doubleClick = true;         
        }
        else { elapsedTime = 0f; }
    }
}
