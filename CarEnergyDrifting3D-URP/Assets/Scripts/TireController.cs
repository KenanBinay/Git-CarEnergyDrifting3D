using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TireController : MonoBehaviour
{
    [SerializeField] Transform Lwheel_Car1, Rwheel_Car1, Lwheel_Car2, Rwheel_Car2, Lwheel_Car3, Rwheel_Car3;

    void Start()
    {
        
    }

    void Update()
    {
        #region carTurningL
        if (CarController.carTurningL)
        {
            if (PlayerPrefs.GetInt("selectedCar", 0) == 1)
            {
                Lwheel_Car1.transform.localRotation = Quaternion.Euler(0, -60f, 0);
                Rwheel_Car1.transform.localRotation = Quaternion.Euler(0, 120f, 0);

                Lwheel_Car1.localPosition = new Vector3(-0.47f, 0, -2.9f);
                Rwheel_Car1.localPosition = new Vector3(2f, 0, -1f);
            }
        }
        #endregion

        #region carTurningR
        if (CarController.carTurningR)
        {
            if (PlayerPrefs.GetInt("selectedCar", 0) == 1)
            {
                Lwheel_Car1.transform.localRotation = Quaternion.Euler(0, 60f, 0);
                Rwheel_Car1.transform.localRotation = Quaternion.Euler(0, 240f, 0);

                Lwheel_Car1.localPosition = new Vector3(2.8f, 0, 0.72f);
                Rwheel_Car1.localPosition = new Vector3(-1.23f, 0, -4.8f);
            }
        }
        #endregion

        #region carReturning
        if (CarController.carReturning)
        {
            if (PlayerPrefs.GetInt("selectedCar", 0) == 1)
            {

                if (transform.eulerAngles.y < 180) { transform.Rotate(Vector3.down * 90f * Time.deltaTime); }

                if (transform.eulerAngles.y > 180) { transform.Rotate(Vector3.up * 90f * Time.deltaTime); }

                Lwheel_Car1.transform.localRotation = Quaternion.Euler(0, 0f, 0);
                Rwheel_Car1.transform.localRotation = Quaternion.Euler(0, 180, 0);

                Lwheel_Car1.localPosition = new Vector3(0.05f, 0, 0f);
                Rwheel_Car1.localPosition = new Vector3(1.43f, 0, -3.732f);

            }
        }
        #endregion
    }
}
