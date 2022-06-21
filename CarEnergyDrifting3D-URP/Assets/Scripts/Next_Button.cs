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
                if (LevelController.currentLevel != 4)
                {
                    LevelController.currentLevel++;
                    pressControl = true;
                    sceneLoad();
                }
                else { }
            }     
        }
    }

    void sceneLoad()
    {
        Debug.Log("next level  | currentLevel : " + LevelController.currentLevel);

        switch (LevelController.currentLevel)
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
