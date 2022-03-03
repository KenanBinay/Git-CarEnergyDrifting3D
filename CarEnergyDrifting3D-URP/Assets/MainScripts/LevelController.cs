using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
   [SerializeField] GameObject tutorial,level1, level2, level3, level4, level5, level6, level7, level8, level9, level10;
    public static float currentLevel, levelSave;

    void Start()
    {
        currentLevel = PlayerPrefs.GetFloat("level");
        Debug.Log("CurrentLevel: " + PlayerPrefs.GetFloat("level"));
    }

    
    void Update()
    {
      /*  if (currentLevel < 11)
        {
            
            if (currentLevel == 0) { tutorial.SetActive(true); }
            else { tutorial.SetActive(false); }
            if (currentLevel == 1) { level1.SetActive(true); }
            else { level1.SetActive(false); }
            if (currentLevel == 2) { level2.SetActive(true); }
            else { level2.SetActive(false); }
            if (currentLevel == 3) { level1.SetActive(true); }
            else { level3.SetActive(false); }
            if (currentLevel == 4) { level2.SetActive(true); }
            else { level4.SetActive(false); }
            if (currentLevel == 5) { level1.SetActive(true); }
            else { level5.SetActive(false); }
            if (currentLevel == 6) { level2.SetActive(true); }
            else { level6.SetActive(false); }
            if (currentLevel == 7) { level1.SetActive(true); }
            else { level7.SetActive(false); }
            if (currentLevel == 8) { level2.SetActive(true); }
            else { level8.SetActive(false); }
            if (currentLevel == 9) { level1.SetActive(true); }
            else { level9.SetActive(false); }
            if (currentLevel == 10) { level2.SetActive(true); }
            else { level10.SetActive(false); }
        }
       else if (currentLevel > 10)
        {
            int[] levels = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            float randomLevels = levels[Random.Range(0, levels.Length)];

            if (currentLevel == 1) { level1.SetActive(true); }
            else { level1.SetActive(false); }
            if (currentLevel == 2) { level2.SetActive(true); }
            else { level2.SetActive(false); }
            if (currentLevel == 3) { level1.SetActive(true); }
            else { level3.SetActive(false); }
            if (currentLevel == 4) { level2.SetActive(true); }
            else { level4.SetActive(false); }
            if (currentLevel == 5) { level1.SetActive(true); }
            else { level5.SetActive(false); }
            if (currentLevel == 6) { level2.SetActive(true); }
            else { level6.SetActive(false); }
            if (currentLevel == 7) { level1.SetActive(true); }
            else { level7.SetActive(false); }
            if (currentLevel == 8) { level2.SetActive(true); }
            else { level8.SetActive(false); }
            if (currentLevel == 9) { level1.SetActive(true); }
            else { level9.SetActive(false); }
            if (currentLevel == 10) { level2.SetActive(true); }
            else { level10.SetActive(false); }
        }
      */
    }
}
