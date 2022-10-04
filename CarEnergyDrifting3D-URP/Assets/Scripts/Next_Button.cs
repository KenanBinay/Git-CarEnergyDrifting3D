using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Next_Button : MonoBehaviour
{
    [SerializeField] private Image _img;
    [SerializeField] private Sprite _default, _pressed;
    public static bool nextLevel_Button;
    bool _buttonClick, pressControl;
    private int[] levelRand = { 1, 2, 3, 4 };
    int levelNumber;
    void Start()
    {
        pressControl = false;
        _img.sprite = _default;
        _buttonClick = false;
    }

    public void NextLevel()
    {
        if (_buttonClick == false)
        {
            if (pressControl == false)
            {
                _img.sprite = _pressed;
                StartCoroutine(nextButtonDelay());
            }
        }
        else
        {
            if (pressControl == false)
            {
                if (PlayerPrefs.GetInt("randomLoader") == 1)
                {
                    levelNumber = levelRand[Random.Range(0, levelRand.Length)];
                    LevelController.currentLevel = levelNumber;
                    pressControl = true;
                    sceneLoad();
                }
                else
                {
                    if (LevelController.currentLevel != 4)
                    {
                        LevelController.currentLevel++;
                        levelNumber = LevelController.currentLevel;
                        pressControl = true;
                        sceneLoad();
                    }
                    else if (LevelController.currentLevel >= 4) { PlayerPrefs.SetInt("randomLoader", 1); }
                }
            }     
        }
    }

    void sceneLoad()
    {
        Debug.Log("next level  | currentLevel : " + LevelController.currentLevel);
        PlayerPrefs.SetInt("level_main", LevelController.currentLevel);

        switch (levelNumber)
        {
            case 1:
                SceneManager.LoadScene("levelMap_1");
                break;
            case 2:
                SceneManager.LoadScene("levelMap_2");
                break;
            case 3:
                SceneManager.LoadScene("levelMap_3");
                break;
            case 4:
                SceneManager.LoadScene("levelMap_4");
                break;
        }
    }

    IEnumerator nextButtonDelay()
    {
        yield return new WaitForSeconds(0.5f);
        _buttonClick = true;
        NextLevel();
    }
}
