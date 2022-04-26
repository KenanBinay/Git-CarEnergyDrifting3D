using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Next_Button : MonoBehaviour
{
    [SerializeField] GameObject _carMain, _skidMarks, _mainCam;
    public static bool nextLevel_Button;
    void Start()
    {
        
    }

    public void NextLevel_Button()
    {
        if (LevelController.currentLevel != 9) { LevelController.currentLevel++; }

        _carMain.transform.position = new Vector3(-0.25f, -1.55f, 1.69f);
        _mainCam.transform.position = new Vector3(0, 3.1f, -7.59f);
        _mainCam.transform.rotation = Quaternion.Euler(15, 0, 0);
        LevelEndController.endDriftCntrl = LevelEndController.lvlEndEnter = CarController.gameEnd = LevelEndUI_Controller.LevelEndUI_Delay = LevelEndUI_Controller.star_Delay = false;
        LevelEndController.clickCounter = 0;
        _skidMarks.SetActive(true);
        Debug.Log("next level  | currentLevel : " + LevelController.currentLevel);
    }

}
