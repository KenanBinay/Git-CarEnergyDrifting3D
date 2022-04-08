using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlassSpawner : MonoBehaviour
{
    [SerializeField] Vector3 originPos;
    public float pos1, pos2, pos3, pos4;
    public GameObject GlassPrefab, BoostsPrefab, GlassRoad1, GlassRoad2, Road1, Road2, dubaS, stopSign;
    public static int coinCount;
    public static float desiredPos;
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        int[] GlassPos = { 1, 2, 3, 4 };
        desiredPos = GlassPos[Random.Range(0, GlassPos.Length)];

        int[] coinAmounts = { 3, 4, 5, 6 };
        coinCount = coinAmounts[Random.Range(0, coinAmounts.Length)];

        //   if (sceneName == "level1")
        if (LevelController.currentLevel == 0)
        {
            Debug.Log("level1 Loaded");

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
                    Debug.Log("Glass, boosts, glassRoad inserted pos 1");
                    break;

                case 2:
                    Instantiate(GlassPrefab, new Vector3(0, 0, pos4), transform.rotation);
                    Instantiate(GlassPrefab, new Vector3(0, 0, pos1), transform.rotation);
                    Instantiate(BoostsPrefab, new Vector3(-2.23f, 2.35f, pos4 - 65), transform.rotation);
                    Instantiate(BoostsPrefab, new Vector3(-2.23f, 2.35f, pos1 - 65), transform.rotation);
              //      Instantiate(coin, new Vector3(0, -1.1f, pos4 - 65), transform.rotation = Quaternion.Euler(90, -40, 0));
                    Instantiate(dubaS, new Vector3(4.89f, -1.608f, pos1), transform.rotation = Quaternion.Euler(0, 90, 0));
                    Instantiate(dubaS, new Vector3(4.89f, -1.608f, pos4), transform.rotation = Quaternion.Euler(0, 90, 0));
                    Instantiate(stopSign, new Vector3(3.2f, -0.97524f, pos1 - 6f), transform.rotation = Quaternion.Euler(0, -90, 0));
                    Instantiate(stopSign, new Vector3(3.2f, -0.97524f, pos4 - 6f), transform.rotation = Quaternion.Euler(0, -90, 0));

                    Instantiate(stopSign, new Vector3(3.2f, -0.97524f, 299.6f), transform.rotation = Quaternion.Euler(0, -90, 0));
                    GlassRoad2.SetActive(true);
                    Road2.SetActive(false);
                    Debug.Log("Glass, boosts, glassRoad inserted pos 1");
                    break;

                case 3:
                    Instantiate(GlassPrefab, new Vector3(0, 0, pos3), transform.rotation);
                    Instantiate(GlassPrefab, new Vector3(0, 0, pos4), transform.rotation);
                    Instantiate(BoostsPrefab, new Vector3(-2.23f, 2.35f, pos3 - 65), transform.rotation);
                    Instantiate(BoostsPrefab, new Vector3(-2.23f, 2.35f, pos4 - 65), transform.rotation);
                //    Instantiate(coin, new Vector3(0, -1.1f, pos3 - 65), transform.rotation = Quaternion.Euler(90, -40, 0));
                    Instantiate(dubaS, new Vector3(4.89f, -1.608f, pos3), transform.rotation = Quaternion.Euler(0, 90, 0));
                    Instantiate(dubaS, new Vector3(4.89f, -1.608f, pos4), transform.rotation = Quaternion.Euler(0, 90, 0));
                    Instantiate(stopSign, new Vector3(3.2f, -0.97524f, pos3 - 6f), transform.rotation = Quaternion.Euler(0, -90, 0));
                    Instantiate(stopSign, new Vector3(3.2f, -0.97524f, pos4 - 6f), transform.rotation = Quaternion.Euler(0, -90, 0));

                    Debug.Log("Glass, boosts inserted pos 3");
                    break;

                case 4:
                    Instantiate(GlassPrefab, new Vector3(0, 0, pos2), transform.rotation);
                    Instantiate(GlassPrefab, new Vector3(0, 0, pos4), transform.rotation);
                    Instantiate(BoostsPrefab, new Vector3(-2.23f, 2.35f, pos2 - 65), transform.rotation);
                    Instantiate(BoostsPrefab, new Vector3(-2.23f, 2.35f, pos4 - 65), transform.rotation);
                  //  Instantiate(coin, new Vector3(0, -1.1f, pos2 - 65), transform.rotation = Quaternion.Euler(90, -40, 0));
                    Instantiate(dubaS, new Vector3(4.89f, -1.608f, pos2), transform.rotation = Quaternion.Euler(0, 90, 0));
                    Instantiate(dubaS, new Vector3(4.89f, -1.608f, pos4), transform.rotation = Quaternion.Euler(0, 90, 0));
                    Instantiate(stopSign, new Vector3(3.2f, -0.97524f, pos2 - 6f), transform.rotation = Quaternion.Euler(0, -90, 0));
                    Instantiate(stopSign, new Vector3(3.2f, -0.97524f, pos4 - 6f), transform.rotation = Quaternion.Euler(0, -90, 0));

                    Instantiate(stopSign, new Vector3(3.2f, -0.97524f, 299.6f), transform.rotation = Quaternion.Euler(0, -90, 0));
                    GlassRoad2.SetActive(true);
                    Road2.SetActive(false);
                    Debug.Log("Glass, boosts, FullGlassRoad inserted pos 4");
                    break;
            }
        }

    }
}
