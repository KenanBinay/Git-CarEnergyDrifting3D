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
            if (PlayerPrefs.GetInt("selectedCar", 0) == 2)
            {
                Lwheel_Car2.transform.localRotation = Quaternion.Euler(0, -60f, 0);
                Rwheel_Car2.transform.localRotation = Quaternion.Euler(0, 120f, 0);

                Lwheel_Car2.localPosition = new Vector3(-1.32f, 0, -4.75f);
                Rwheel_Car2.localPosition = new Vector3(2.7f, 0, 0.6f);
            }
            if (PlayerPrefs.GetInt("selectedCar", 0) == 3)
            {
                Lwheel_Car3.transform.localRotation = Quaternion.Euler(0, -60f, 0);
                Rwheel_Car3.transform.localRotation = Quaternion.Euler(0, 120f, 0);

                Lwheel_Car3.localPosition = new Vector3(2f, 0, 3.62f);
                Rwheel_Car3.localPosition = new Vector3(-2.2f, 0, 3f);
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
            if (PlayerPrefs.GetInt("selectedCar", 0) == 2)
            {
                Lwheel_Car2.transform.localRotation = Quaternion.Euler(0, 60f, 0);
                Rwheel_Car2.transform.localRotation = Quaternion.Euler(0, 240f, 0);

                Lwheel_Car2.localPosition = new Vector3(2.1f, 0, 2.54f);
                Rwheel_Car2.localPosition = new Vector3(-0.68f, 0, -6.7f);
            }
            if (PlayerPrefs.GetInt("selectedCar", 0) == 3)
            {
                Lwheel_Car3.transform.localRotation = Quaternion.Euler(0, 60f, 0);
                Rwheel_Car3.transform.localRotation = Quaternion.Euler(0, 240f, 0);

                Lwheel_Car3.localPosition = new Vector3(-2.2f, 0, -1.35f);
                Rwheel_Car3.localPosition = new Vector3(2.2f, 0, 6f);
            }
        }
        #endregion

        #region carReturning
        if (CarController.carReturning)
        {
            if (transform.eulerAngles.y < 180) { transform.Rotate(Vector3.down * 90f * Time.deltaTime); }

            if (transform.eulerAngles.y > 180) { transform.Rotate(Vector3.up * 90f * Time.deltaTime); }

            if (PlayerPrefs.GetInt("selectedCar", 0) == 1)
            {
                Lwheel_Car1.transform.localRotation = Quaternion.Euler(0, 0, 0);
                Rwheel_Car1.transform.localRotation = Quaternion.Euler(0, 180, 0);

                Lwheel_Car1.localPosition = new Vector3(0.05f, 0, 0f);
                Rwheel_Car1.localPosition = new Vector3(1.43f, 0, -3.732f);
            }
            if (PlayerPrefs.GetInt("selectedCar", 0) == 2)
            {
                Lwheel_Car2.transform.localRotation = Quaternion.Euler(0, 0, 0);
                Rwheel_Car2.transform.localRotation = Quaternion.Euler(0, 180, 0);

                Lwheel_Car2.localPosition = new Vector3(-1.93f, 0, -0.1f);
                Rwheel_Car2.localPosition = new Vector3(3.28f, 0, -4f);
            }
            if (PlayerPrefs.GetInt("selectedCar", 0) == 3)
            {
                Lwheel_Car3.transform.localRotation = Quaternion.Euler(0, 0, 0);
                Rwheel_Car3.transform.localRotation = Quaternion.Euler(0, 180, 0);

                Lwheel_Car3.localPosition = new Vector3(1.448f, 0, 0f);
                Rwheel_Car3.localPosition = new Vector3(-1.449f, 0, 4.8f);
            }
        }
        #endregion
    }
}
