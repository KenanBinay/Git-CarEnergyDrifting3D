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
                if (LevelController.currentLevel != 9)
                {
                    LevelController.currentLevel++;
                    pressControl = true;
                }
            }

            Debug.Log("next level  | currentLevel : " + LevelController.currentLevel);

            /*  switch (LevelController.currentLevel)
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
                  case 5:
                      SceneManager.LoadScene("levelMap_5");
                      break;
                  case 6:
                      SceneManager.LoadScene("levelMap_6");
                      break;
                  case 7:
                      SceneManager.LoadScene("levelMap_7");
                      break;
                  case 8:
                      SceneManager.LoadScene("levelMap_8");
                      break;
                  case 9:
                      SceneManager.LoadScene("levelMap_9");
                      break;
              }
            */
        }
    }

    IEnumerator nextButtonDelay()
    {
        yield return new WaitForSeconds(0.5f);
        _buttonClick = true;
        NextLevel();
    }
}
