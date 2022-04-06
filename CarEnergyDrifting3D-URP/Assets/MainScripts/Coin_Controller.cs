using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Controller : MonoBehaviour
{
    public static int coinCurrent;

    void Start()
    {
     //   coinCurrent = PlayerPrefs.GetInt("coin_main", 0);
        Debug.Log("CurrentCoin: " + PlayerPrefs.GetInt("coin_main"));
    }

    void Update()
    {     
        transform.Rotate(Vector3.forward * 50 * Time.deltaTime);

    }
}
