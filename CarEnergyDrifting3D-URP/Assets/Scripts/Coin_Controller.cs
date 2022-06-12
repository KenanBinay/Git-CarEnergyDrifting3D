using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Controller : MonoBehaviour
{
    public static int coinCurrent;
    float posX;
    void Start()
    {
        //   coinCurrent = PlayerPrefs.GetInt("coin_main", 0);
        //   Debug.Log("CurrentCoin: " + PlayerPrefs.GetInt("coin_main"));
        if (GlassSpawner.sceneName == "levelMap_4")
        {
            posX = Random.Range(-1.5f, 2.4f);
            transform.position = new Vector3(posX, transform.position.y, transform.position.z);
        }
        else
        {
            posX = Random.Range(-3.3f, 3.1f);
            transform.localPosition = new Vector3(posX, transform.localPosition.y, transform.localPosition.z);
        }
    }

    void Update()
    {     
        transform.Rotate(Vector3.forward * 50 * Time.deltaTime);

    }
}
