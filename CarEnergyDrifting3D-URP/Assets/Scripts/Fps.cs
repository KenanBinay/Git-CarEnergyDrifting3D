using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Fps : MonoBehaviour
{
    public Text fpsText;
    private float deltaTime;

    void Awake()
    {
        // Make the game run as fast as possible in Windows
        Application.targetFrameRate = 60;
    }

    void Update()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        fpsText.text = Mathf.Ceil(fps).ToString();
    }
}
