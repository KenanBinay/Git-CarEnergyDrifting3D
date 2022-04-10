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
        coinTime = 0;
    }

    void Update()
    {
        if (LevelEndController.endDriftCntrl == false && Glass.controlGlassSolid != 1)
        {
            if (coinTime <= GlassSpawner.coinCount)
            {
                if (GlassSpawner.desiredPos == 1) { zPosCoin = Random.Range(65, 350); }

              //  Debug.Log("zPosCoin: " + zPosCoin);

                Vector3 spawnPointZ = new Vector3(0, -1.1f, zPosCoin);

                if (zPosCoin != 0)
                {
                    Instantiate(coin, spawnPointZ, transform.rotation = Quaternion.Euler(90, -40, 0));
                    coinTime++;
                }
                else { return; }
            }
        }
                           
    }
}
