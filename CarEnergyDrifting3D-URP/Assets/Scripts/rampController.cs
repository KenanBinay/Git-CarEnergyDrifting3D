using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rampController : MonoBehaviour
{
    public GameObject car1, car2, car3, car4;
    private int[] carRand = { 1, 2, 3, 4 };

    void Start()
    {
        float carNum = carRand[Random.Range(0, carRand.Length)];

        if (carNum == 1)
        {
            car1.SetActive(true);
            car3.SetActive(true);
            car2.SetActive(false);
            car4.SetActive(false);
        }
        if (carNum == 2)
        {
            car1.SetActive(true);
            car4.SetActive(true);
            car2.SetActive(false);
            car3.SetActive(false);
        }
        if (carNum == 3)
        {         
            car2.SetActive(true);
            car3.SetActive(true);
            car1.SetActive(false);
            car4.SetActive(false);
        }
        if (carNum == 4)
        {
            car2.SetActive(true);
            car4.SetActive(true);
            car1.SetActive(false);
            car3.SetActive(false);
        }
    }
}
