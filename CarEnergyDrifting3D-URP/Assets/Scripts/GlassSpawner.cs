using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlassSpawner : MonoBehaviour
{
    [SerializeField] Vector3 originPos;
    public float pos1, pos2, pos3, pos4;
    public GameObject GlassPrefab, BoostsPrefab, GlassRoad1, GlassRoad2, Road1, Road2, dubaS, stopSign, roadBlocker;
    public static int coinAmount;
    public static float desiredPos;
    public static string sceneName;

    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;

        int[] GlassPos = { 1, 2, 3, 4 };
        desiredPos = GlassPos[Random.Range(0, GlassPos.Length)];

        int[] coinAmounts = { 6, 7, 8, 9, 10 };
        coinAmount = coinAmounts[Random.Range(3, coinAmounts.Length)];

        //   if (sceneName == "level1")
        if (sceneName == "levelMap_1")
        {
            switch (desiredPos)
            {
                case 1:
                    Instantiate(GlassPrefab, new Vector3(0, 0, pos1), transform.rotation);
                    Instantiate(GlassPrefab, new Vector3(0, 0, pos3), transform.rotation);
                    Instantiate(BoostsPrefab, new Vector3(-2.23f, 2.35f, pos1 - 65), transform.rotation);
                    Instantiate(BoostsPrefab, new Vector3(-2.23f, 2.3f, pos3 - 65), transform.rotation);
                    Instantiate(dubaS, new Vector3(4.89f, -1.608f, pos1), transform.rotation = Quaternion.Euler(0, 90, 0));
                    Instantiate(dubaS, new Vector3(4.89f, -1.608f, pos3), transform.rotation = Quaternion.Euler(0, 90, 0));
                    Instantiate(stopSign, new Vector3(3.2f, -0.97524f, pos1 - 6f), transform.rotation = Quaternion.Euler(0, -90, 0));
                    Instantiate(stopSign, new Vector3(3.2f, -0.97524f, pos3 - 6f), transform.rotation = Quaternion.Euler(0, -90, 0));

                    Instantiate(stopSign, new Vector3(3.2f, -0.97524f, 167), transform.rotation = Quaternion.Euler(0, -90, 0));
                    GlassRoad1.SetActive(true);
                    Road1.SetActive(false);
                    Debug.Log("Level 1 | desiredPos " + desiredPos + " | Spawned Coins " + coinAmount);
                    break;

                case 2:
                    Instantiate(GlassPrefab, new Vector3(0, 0, pos4), transform.rotation);
                    Instantiate(GlassPrefab, new Vector3(0, 0, pos1), transform.rotation);
                    Instantiate(BoostsPrefab, new Vector3(-2.23f, 2.35f, pos4 - 65), transform.rotation);
                    Instantiate(BoostsPrefab, new Vector3(-2.23f, 2.35f, pos1 - 65), transform.rotation);
                    Instantiate(dubaS, new Vector3(4.89f, -1.608f, pos1), transform.rotation = Quaternion.Euler(0, 90, 0));
                    Instantiate(dubaS, new Vector3(4.89f, -1.608f, pos4), transform.rotation = Quaternion.Euler(0, 90, 0));
                    Instantiate(stopSign, new Vector3(3.2f, -0.97524f, pos1 - 6f), transform.rotation = Quaternion.Euler(0, -90, 0));
                    Instantiate(stopSign, new Vector3(3.2f, -0.97524f, pos4 - 6f), transform.rotation = Quaternion.Euler(0, -90, 0));

                    Instantiate(stopSign, new Vector3(3.2f, -0.97524f, 299.6f), transform.rotation = Quaternion.Euler(0, -90, 0));
                    GlassRoad2.SetActive(true);
                    Road2.SetActive(false);
                    Debug.Log("Level 1 | desiredPos " + desiredPos + " | Spawned Coins " + coinAmount);
                    break;

                case 3:
                    Instantiate(GlassPrefab, new Vector3(0, 0, pos3), transform.rotation);
                    Instantiate(GlassPrefab, new Vector3(0, 0, pos4), transform.rotation);
                    Instantiate(BoostsPrefab, new Vector3(-2.23f, 2.35f, pos3 - 65), transform.rotation);
                    Instantiate(BoostsPrefab, new Vector3(-2.23f, 2.35f, pos4 - 65), transform.rotation);
                    Instantiate(dubaS, new Vector3(4.89f, -1.608f, pos3), transform.rotation = Quaternion.Euler(0, 90, 0));
                    Instantiate(dubaS, new Vector3(4.89f, -1.608f, pos4), transform.rotation = Quaternion.Euler(0, 90, 0));
                    Instantiate(stopSign, new Vector3(3.2f, -0.97524f, pos3 - 6f), transform.rotation = Quaternion.Euler(0, -90, 0));
                    Instantiate(stopSign, new Vector3(3.2f, -0.97524f, pos4 - 6f), transform.rotation = Quaternion.Euler(0, -90, 0));

                    Debug.Log("Level 1 | desiredPos " + desiredPos + " | Spawned Coins " + coinAmount);
                    break;

                case 4:
                    Instantiate(GlassPrefab, new Vector3(0, 0, pos2), transform.rotation);
                    Instantiate(GlassPrefab, new Vector3(0, 0, pos4), transform.rotation);
                    Instantiate(BoostsPrefab, new Vector3(-2.23f, 2.35f, pos2 - 65), transform.rotation);
                    Instantiate(BoostsPrefab, new Vector3(-2.23f, 2.35f, pos4 - 65), transform.rotation);
                    Instantiate(dubaS, new Vector3(4.89f, -1.608f, pos2), transform.rotation = Quaternion.Euler(0, 90, 0));
                    Instantiate(dubaS, new Vector3(4.89f, -1.608f, pos4), transform.rotation = Quaternion.Euler(0, 90, 0));
                    Instantiate(stopSign, new Vector3(3.2f, -0.97524f, pos2 - 6f), transform.rotation = Quaternion.Euler(0, -90, 0));
                    Instantiate(stopSign, new Vector3(3.2f, -0.97524f, pos4 - 6f), transform.rotation = Quaternion.Euler(0, -90, 0));

                    Instantiate(stopSign, new Vector3(3.2f, -0.97524f, 299.6f), transform.rotation = Quaternion.Euler(0, -90, 0));
                    GlassRoad2.SetActive(true);
                    Road2.SetActive(false);
                    Debug.Log("Level 1 | desiredPos " + desiredPos + " | Spawned Coins " + coinAmount);
                    break;
            }
        }

        if (sceneName == "levelMap_2")
        {
            switch (desiredPos)
            {
                case 1:
                    Instantiate(GlassPrefab, new Vector3(0, 0, pos1), transform.rotation);
                    Instantiate(GlassPrefab, new Vector3(0, 0, pos4), transform.rotation);
                    Instantiate(roadBlocker, new Vector3(0, -0.937f, 85), roadBlocker.transform.rotation);
                    Instantiate(roadBlocker, new Vector3(-4.3f, -0.937f, 250), roadBlocker.transform.rotation);
                    Instantiate(BoostsPrefab, new Vector3(-2.23f, 2.35f, pos1 - 65), transform.rotation);
                    Instantiate(BoostsPrefab, new Vector3(-2.23f, 2.3f, pos4 - 65), transform.rotation);
                    Instantiate(dubaS, new Vector3(4.89f, -1.608f, pos1), transform.rotation = Quaternion.Euler(0, 90, 0));
                    Instantiate(dubaS, new Vector3(4.89f, -1.608f, pos4), transform.rotation = Quaternion.Euler(0, 90, 0));
                    Instantiate(stopSign, new Vector3(3.2f, -0.97524f, pos1 - 6f), transform.rotation = Quaternion.Euler(0, -90, 0));
                    Instantiate(stopSign, new Vector3(3.2f, -0.97524f, pos4 - 6f), transform.rotation = Quaternion.Euler(0, -90, 0));

                    Instantiate(stopSign, new Vector3(3.2f, -0.97524f, 167), transform.rotation = Quaternion.Euler(0, -90, 0));
                    GlassRoad2.SetActive(true);
                    Road2.SetActive(false);
                    Debug.Log("Level 2 | desiredPos " + desiredPos + " | Spawned Coins " + coinAmount);
                    break;

                case 2:
                    Instantiate(GlassPrefab, new Vector3(0, 0, pos3), transform.rotation);
                    Instantiate(GlassPrefab, new Vector3(0, 0, pos4), transform.rotation);
                    Instantiate(roadBlocker, new Vector3(-4.3f, -0.937f, 111), roadBlocker.transform.rotation);
                    Instantiate(BoostsPrefab, new Vector3(-2.23f, 2.35f, pos3 - 65), transform.rotation);
                    Instantiate(BoostsPrefab, new Vector3(-2.23f, 2.3f, pos4 - 65), transform.rotation);
                    Instantiate(dubaS, new Vector3(4.89f, -1.608f, pos3), transform.rotation = Quaternion.Euler(0, 90, 0));
                    Instantiate(dubaS, new Vector3(4.89f, -1.608f, pos4), transform.rotation = Quaternion.Euler(0, 90, 0));
                    Instantiate(stopSign, new Vector3(3.2f, -0.97524f, pos3 - 6f), transform.rotation = Quaternion.Euler(0, -90, 0));
                    Instantiate(stopSign, new Vector3(3.2f, -0.97524f, pos4 - 6f), transform.rotation = Quaternion.Euler(0, -90, 0));

                    Instantiate(stopSign, new Vector3(3.2f, -0.97524f, 167), transform.rotation = Quaternion.Euler(0, -90, 0));
                    GlassRoad1.SetActive(true);
                    Road1.SetActive(false);
                    Debug.Log("Level 2 | desiredPos " + desiredPos + " | Spawned Coins " + coinAmount);
                    break;

                case 3:
                    Instantiate(GlassPrefab, new Vector3(0, 0, pos2), transform.rotation);
                    Instantiate(GlassPrefab, new Vector3(0, 0, pos4), transform.rotation);
                    Instantiate(roadBlocker, new Vector3(-4.3f, -0.937f, 330), roadBlocker.transform.rotation);
                    Instantiate(roadBlocker, new Vector3(0, -0.937f, 220), roadBlocker.transform.rotation);
                    Instantiate(BoostsPrefab, new Vector3(-2.23f, 2.35f, pos2 - 65), transform.rotation);
                    Instantiate(BoostsPrefab, new Vector3(-2.23f, 2.3f, pos4 - 65), transform.rotation);
                    Instantiate(dubaS, new Vector3(4.89f, -1.608f, pos2), transform.rotation = Quaternion.Euler(0, 90, 0));
                    Instantiate(dubaS, new Vector3(4.89f, -1.608f, pos4), transform.rotation = Quaternion.Euler(0, 90, 0));
                    Instantiate(stopSign, new Vector3(3.2f, -0.97524f, pos2 - 6f), transform.rotation = Quaternion.Euler(0, -90, 0));
                    Instantiate(stopSign, new Vector3(3.2f, -0.97524f, pos4 - 6f), transform.rotation = Quaternion.Euler(0, -90, 0));

                    Instantiate(stopSign, new Vector3(3.2f, -0.97524f, 167), transform.rotation = Quaternion.Euler(0, -90, 0));
                    GlassRoad1.SetActive(true);
                    GlassRoad2.SetActive(true);
                    Road1.SetActive(false);
                    Road2.SetActive(false);
                    Debug.Log("Level 2 | desiredPos " + desiredPos + " | Spawned Coins " + coinAmount);
                    break;

                case 4:
                    Instantiate(GlassPrefab, new Vector3(0, 0, pos1), transform.rotation);
                    Instantiate(GlassPrefab, new Vector3(0, 0, pos2), transform.rotation);
                    Instantiate(GlassPrefab, new Vector3(0, 0, pos4), transform.rotation);
                    Instantiate(roadBlocker, new Vector3(0, -0.937f, 266), roadBlocker.transform.rotation);
                    Instantiate(roadBlocker, new Vector3(0, -0.937f, 334), roadBlocker.transform.rotation);
                    Instantiate(roadBlocker, new Vector3(-4.3f, -0.937f, 68), roadBlocker.transform.rotation);
                    Instantiate(BoostsPrefab, new Vector3(-2.23f, 2.35f, pos1 - 65), transform.rotation);
                    Instantiate(BoostsPrefab, new Vector3(-2.23f, 2.35f, pos2 - 65), transform.rotation);
                    Instantiate(BoostsPrefab, new Vector3(-2.23f, 2.3f, pos4 - 65), transform.rotation);
                    Instantiate(dubaS, new Vector3(4.89f, -1.608f, pos1), transform.rotation = Quaternion.Euler(0, 90, 0));
                    Instantiate(dubaS, new Vector3(4.89f, -1.608f, pos2), transform.rotation = Quaternion.Euler(0, 90, 0));
                    Instantiate(dubaS, new Vector3(4.89f, -1.608f, pos4), transform.rotation = Quaternion.Euler(0, 90, 0));
                    Instantiate(stopSign, new Vector3(3.2f, -0.97524f, pos1 - 6f), transform.rotation = Quaternion.Euler(0, -90, 0));
                    Instantiate(stopSign, new Vector3(3.2f, -0.97524f, pos2 - 6f), transform.rotation = Quaternion.Euler(0, -90, 0));
                    Instantiate(stopSign, new Vector3(3.2f, -0.97524f, pos4 - 6f), transform.rotation = Quaternion.Euler(0, -90, 0));

                    Instantiate(stopSign, new Vector3(3.2f, -0.97524f, 167), transform.rotation = Quaternion.Euler(0, -90, 0));
                    GlassRoad2.SetActive(true);
                    Road2.SetActive(false);
                    Debug.Log("Level 2 | desiredPos " + desiredPos + " | Spawned Coins " + coinAmount);
                    break;
            }

        }

        if (sceneName == "levelMap_3")
        {
            switch (desiredPos)
            {
                case 1:
                    Instantiate(GlassPrefab, new Vector3(0, 0, pos1), transform.rotation);
                    Instantiate(GlassPrefab, new Vector3(0, 0, pos3), transform.rotation);
                    Instantiate(roadBlocker, new Vector3(-4.3f, -0.937f, 123), roadBlocker.transform.rotation);
                    Instantiate(roadBlocker, new Vector3(0, -0.937f, 190), roadBlocker.transform.rotation);
                    Instantiate(roadBlocker, new Vector3(-4.3f, -0.937f, 312), roadBlocker.transform.rotation);
                    Instantiate(BoostsPrefab, new Vector3(-2.23f, 2.3f, pos1 - 65), transform.rotation);
                    Instantiate(BoostsPrefab, new Vector3(-2.23f, 2.3f, pos3 - 65), transform.rotation);
                    Instantiate(dubaS, new Vector3(4.89f, -1.608f, pos1), transform.rotation = Quaternion.Euler(0, 90, 0));
                    Instantiate(dubaS, new Vector3(4.89f, -1.608f, pos3), transform.rotation = Quaternion.Euler(0, 90, 0));
                    Instantiate(stopSign, new Vector3(3.2f, -0.97524f, pos1 - 6f), transform.rotation = Quaternion.Euler(0, -90, 0));
                    Instantiate(stopSign, new Vector3(3.2f, -0.97524f, pos3 - 6f), transform.rotation = Quaternion.Euler(0, -90, 0));

                    Debug.Log("Level 3 | desiredPos " + desiredPos + " | Spawned Coins " + coinAmount);
                    break;

                case 2:
                    Instantiate(GlassPrefab, new Vector3(0, 0, pos1), transform.rotation);
                    Instantiate(GlassPrefab, new Vector3(0, 0, pos2), transform.rotation);
                    Instantiate(GlassPrefab, new Vector3(0, 0, pos4), transform.rotation);
                    Instantiate(roadBlocker, new Vector3(-4.3f, -0.937f, 60), roadBlocker.transform.rotation);
                    Instantiate(roadBlocker, new Vector3(0, -0.937f, 224), roadBlocker.transform.rotation);
                    Instantiate(roadBlocker, new Vector3(-4.3f, -0.937f, 308), roadBlocker.transform.rotation);
                    Instantiate(BoostsPrefab, new Vector3(-2.23f, 2.3f, pos1 - 65), transform.rotation);
                    Instantiate(BoostsPrefab, new Vector3(-2.23f, 2.3f, pos2 - 65), transform.rotation);
                    Instantiate(BoostsPrefab, new Vector3(-2.23f, 2.3f, pos4 - 65), transform.rotation);
                    Instantiate(dubaS, new Vector3(4.89f, -1.608f, pos1), transform.rotation = Quaternion.Euler(0, 90, 0));
                    Instantiate(dubaS, new Vector3(4.89f, -1.608f, pos2), transform.rotation = Quaternion.Euler(0, 90, 0));
                    Instantiate(dubaS, new Vector3(4.89f, -1.608f, pos4), transform.rotation = Quaternion.Euler(0, 90, 0));
                    Instantiate(stopSign, new Vector3(3.2f, -0.97524f, pos1 - 6f), transform.rotation = Quaternion.Euler(0, -90, 0));
                    Instantiate(stopSign, new Vector3(3.2f, -0.97524f, pos2 - 6f), transform.rotation = Quaternion.Euler(0, -90, 0));
                    Instantiate(stopSign, new Vector3(3.2f, -0.97524f, pos4 - 6f), transform.rotation = Quaternion.Euler(0, -90, 0));

                    Debug.Log("Level 3 | desiredPos " + desiredPos + " | Spawned Coins " + coinAmount);
                    break;

                case 3:
                    Instantiate(GlassPrefab, new Vector3(0, 0, pos2), transform.rotation);
                    Instantiate(GlassPrefab, new Vector3(0, 0, pos4), transform.rotation);
                    Instantiate(roadBlocker, new Vector3(0, -0.937f, 65), roadBlocker.transform.rotation);
                    Instantiate(roadBlocker, new Vector3(-4.3f, -0.937f, 110), roadBlocker.transform.rotation);
                    Instantiate(roadBlocker, new Vector3(-4.3f, -0.937f, 230), roadBlocker.transform.rotation);
                    Instantiate(BoostsPrefab, new Vector3(-2.23f, 2.3f, pos2 - 65), transform.rotation);
                    Instantiate(BoostsPrefab, new Vector3(-2.23f, 2.3f, pos4 - 65), transform.rotation);
                    Instantiate(dubaS, new Vector3(4.89f, -1.608f, pos2), transform.rotation = Quaternion.Euler(0, 90, 0));
                    Instantiate(dubaS, new Vector3(4.89f, -1.608f, pos4), transform.rotation = Quaternion.Euler(0, 90, 0));
                    Instantiate(stopSign, new Vector3(3.2f, -0.97524f, pos2 - 6f), transform.rotation = Quaternion.Euler(0, -90, 0));
                    Instantiate(stopSign, new Vector3(3.2f, -0.97524f, pos4 - 6f), transform.rotation = Quaternion.Euler(0, -90, 0));

                    Debug.Log("Level 3 | desiredPos " + desiredPos + " | Spawned Coins " + coinAmount);
                    break;

                case 4:
                    Instantiate(GlassPrefab, new Vector3(0, 0, pos1), transform.rotation);
                    Instantiate(GlassPrefab, new Vector3(0, 0, pos3), transform.rotation);
                    Instantiate(GlassPrefab, new Vector3(0, 0, pos4), transform.rotation);
                    Instantiate(roadBlocker, new Vector3(-4.3f, -0.937f, 180), roadBlocker.transform.rotation);
                    Instantiate(roadBlocker, new Vector3(0, -0.937f, 290), roadBlocker.transform.rotation);
                    Instantiate(BoostsPrefab, new Vector3(-2.23f, 2.3f, pos1 - 65), transform.rotation);
                    Instantiate(BoostsPrefab, new Vector3(-2.23f, 2.3f, pos3 - 65), transform.rotation);
                    Instantiate(BoostsPrefab, new Vector3(-2.23f, 2.3f, pos4 - 65), transform.rotation);
                    Instantiate(dubaS, new Vector3(4.89f, -1.608f, pos1), transform.rotation = Quaternion.Euler(0, 90, 0));
                    Instantiate(dubaS, new Vector3(4.89f, -1.608f, pos3), transform.rotation = Quaternion.Euler(0, 90, 0));
                    Instantiate(dubaS, new Vector3(4.89f, -1.608f, pos4), transform.rotation = Quaternion.Euler(0, 90, 0));
                    Instantiate(stopSign, new Vector3(3.2f, -0.97524f, pos1 - 6f), transform.rotation = Quaternion.Euler(0, -90, 0));
                    Instantiate(stopSign, new Vector3(3.2f, -0.97524f, pos3 - 6f), transform.rotation = Quaternion.Euler(0, -90, 0));
                    Instantiate(stopSign, new Vector3(3.2f, -0.97524f, pos4 - 6f), transform.rotation = Quaternion.Euler(0, -90, 0));

                    Debug.Log("Level 3 | desiredPos " + desiredPos + " | Spawned Coins " + coinAmount);
                    break;
            }
        }

        if (sceneName == "levelMap_4")
        {
            switch (desiredPos)
            {
                case 1:
                    Instantiate(GlassPrefab, new Vector3(0, 0, pos1), transform.rotation);
                    Instantiate(GlassPrefab, new Vector3(0, 0, pos3), transform.rotation);
                    Instantiate(BoostsPrefab, new Vector3(-2.23f, 2.3f, pos1 - 65), transform.rotation);
                    Instantiate(BoostsPrefab, new Vector3(-2.23f, 2.3f, pos3 - 65), transform.rotation);
                    Instantiate(roadBlocker, new Vector3(0, -0.937f, 118), roadBlocker.transform.rotation);
                    Instantiate(roadBlocker, new Vector3(-4.3f, -0.937f, 245), roadBlocker.transform.rotation);
                    Debug.Log("Level 4 | desiredPos " + desiredPos + " | Spawned Coins " + coinAmount);
                    break;

                case 2:
                    Instantiate(GlassPrefab, new Vector3(0, 0, pos2), transform.rotation);
                    Instantiate(GlassPrefab, new Vector3(0, 0, pos4), transform.rotation);
                    Instantiate(BoostsPrefab, new Vector3(-2.23f, 2.3f, pos2 - 65), transform.rotation);
                    Instantiate(BoostsPrefab, new Vector3(-2.23f, 2.3f, pos4 - 65), transform.rotation);
                    Instantiate(roadBlocker, new Vector3(-4.3f, -0.937f, 60), roadBlocker.transform.rotation);
                    Instantiate(roadBlocker, new Vector3(0, -0.937f, 185), roadBlocker.transform.rotation);
                    Debug.Log("Level 4 | desiredPos " + desiredPos + " | Spawned Coins " + coinAmount);
                    break;

                case 3:
                    Instantiate(GlassPrefab, new Vector3(0, 0, pos2), transform.rotation);
                    Instantiate(GlassPrefab, new Vector3(0, 0, pos3), transform.rotation);
                    Instantiate(BoostsPrefab, new Vector3(-2.23f, 2.3f, pos2 - 65), transform.rotation);
                    Instantiate(BoostsPrefab, new Vector3(-2.23f, 2.3f, pos3 - 65), transform.rotation);
                    Instantiate(roadBlocker, new Vector3(0, -0.937f, 65), roadBlocker.transform.rotation);
                    Instantiate(roadBlocker, new Vector3(-4.3f, -0.937f, 170), roadBlocker.transform.rotation);
                    Instantiate(roadBlocker, new Vector3(0, -0.937f, 230), roadBlocker.transform.rotation);
                    Debug.Log("Level 4 | desiredPos " + desiredPos + " | Spawned Coins " + coinAmount);
                    break;

                case 4:
                    Instantiate(GlassPrefab, new Vector3(0, 0, pos1), transform.rotation);
                    Instantiate(GlassPrefab, new Vector3(0, 0, pos4), transform.rotation);
                    Instantiate(BoostsPrefab, new Vector3(-2.23f, 2.3f, pos1 - 65), transform.rotation);
                    Instantiate(BoostsPrefab, new Vector3(-2.23f, 2.3f, pos4 - 65), transform.rotation);
                    Instantiate(roadBlocker, new Vector3(0, -0.937f, 80), roadBlocker.transform.rotation);
                    Instantiate(roadBlocker, new Vector3(-4.3f, -0.937f, 130), roadBlocker.transform.rotation);
                    Instantiate(roadBlocker, new Vector3(0, -0.937f, 165), roadBlocker.transform.rotation);
                    Instantiate(roadBlocker, new Vector3(-4.3f, -0.937f, 215), roadBlocker.transform.rotation);
                    Debug.Log("Level 4 | desiredPos " + desiredPos + " | Spawned Coins " + coinAmount);
                    break;
            }
        }
    }
}
