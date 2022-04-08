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

        float posX = Random.Range(-3.3f, 3.1f);
        transform.localPosition = new Vector3(posX, -1.1f, transform.localPosition.z);
    }

    void Update()
    {     
        transform.Rotate(Vector3.forward * 50 * Time.deltaTime);

    }
}
