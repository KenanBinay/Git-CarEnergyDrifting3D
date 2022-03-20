using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public static float currentLevel, levelSave;

    void Start()
    {
        currentLevel = PlayerPrefs.GetFloat("level_main", 0);
        Debug.Log("CurrentLevel: " + PlayerPrefs.GetFloat("level_main"));
    }
    
    void Update()
    {

    }
}
