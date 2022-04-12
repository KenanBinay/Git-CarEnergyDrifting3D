using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class coinSpawnerController : MonoBehaviour
{
    [Header("Pos1")]
    public float Min_RandomPos1, Max_RandomPos1;
    [Header("Pos2")]
    public float Min_RandomPos2, Max_RandomPos2;
    [Header("Pos3")]
    public float Min_RandomPos3, Max_RandomPos3;
    [Header("Pos4")]
    public float Min_RandomPos4, Max_RandomPos4;

    public GameObject coin;
    float zPosCoin;
    void Start()
    { 
        for (int coinCount = 0; coinCount <= GlassSpawner.coinAmount; coinCount++)
        {
            if (GlassSpawner.desiredPos == 1) { zPosCoin = Random.Range(Min_RandomPos1, Max_RandomPos1); }
            if (GlassSpawner.desiredPos == 2) { zPosCoin = Random.Range(Min_RandomPos2, Max_RandomPos2); }
            if (GlassSpawner.desiredPos == 3) { zPosCoin = Random.Range(Min_RandomPos3, Max_RandomPos3); }
            if (GlassSpawner.desiredPos == 4) { zPosCoin = Random.Range(Min_RandomPos4, Max_RandomPos4); }

            Vector3 spawnPointZ = new Vector3(0, -1.1f, zPosCoin);

            if (zPosCoin != 0)
            {
                Instantiate(coin, spawnPointZ, transform.rotation = Quaternion.Euler(90, -40, 0));
                coinCount++;
            }
            else { return; }
        }

    }
}
