using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBarController : MonoBehaviour
{
    public Transform BarRect;
    Vector3 scaleRect;
    void Start()
    {
        scaleRect = BarRect.localScale;
    }

    void Update()
    {
        if (Glass.controlGlassSolid == 0 && LevelEndController.lvlEndEnter == false)
        {
            switch (LevelController.currentLevel)
            {
                case 0:
                    if (transform.localPosition.x < 480)
                    {
                        transform.position += new Vector3(0.0014f, 0, 0);
                        BarRect.position -= new Vector3(0.0007f, 0, 0);
                        BarRect.localScale += Vector3.right * Time.deltaTime * 1.401f;
                    }
                    break;
            }

        }
        else if (Glass.controlGlassSolid == 1)
        {
           
          //  BarRect.localPosition.Set(-0.116f, 0, 0);
            BarRect.localScale = scaleRect;
        }
    }
}
