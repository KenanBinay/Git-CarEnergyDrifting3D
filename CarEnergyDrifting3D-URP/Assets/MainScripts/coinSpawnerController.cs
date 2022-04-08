using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinSpawnerController : MonoBehaviour
{
    public GameObject coin;
    int coinTime;
    private float zPosCoin;
    void Start()
    {
       // for(int load=0;load<= GlassSpawner.coinCount; load++) { }
    }

    void Update()
    {
        if (coinTime <= GlassSpawner.coinCount)
        {
            if (GlassSpawner.desiredPos == 1) { zPosCoin = Random.Range(65, 350); }
           
            Vector3 spawnPointZ = new Vector3(0, -1.1f, zPosCoin);

            Instantiate(coin, spawnPointZ, transform.rotation = Quaternion.Euler(90, -40, 0));
            coinTime++;
        }
                           
    }
}
