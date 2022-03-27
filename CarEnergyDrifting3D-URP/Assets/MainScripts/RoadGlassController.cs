using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGlassController : MonoBehaviour
{
    public GameObject solidGlass1, HalfBroken, GlassBrokenParts, Boosts;
    float broke,crack;
    public static bool roadGlassBroke;
    void Start()
    {
        broke = crack = 0f;

        roadGlassBroke = false;
        Boosts.SetActive(true);
        solidGlass1.SetActive(true);
        HalfBroken.SetActive(false);

    }

    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayerCar"))
        {
           // Debug.Log("GlassRoad!");
            if (CarController.MainCarWeight > 2)
            {
                Debug.Log("Destroying GlassRoad!!");
                StartCoroutine(BrokeDelay());
               
            }
            else if (CarController.MainCarWeight >= 1)
            {
                StartCoroutine(CrackDelay());
            }
        }
    }

    void CrackSpawn()
    {
        if (crack <= 0f)
        {
            Debug.Log("Crack GlassRoad!!");
            HalfBroken.SetActive(true);
            solidGlass1.SetActive(false);
            crack = 1f;
        }
    }
    
    void BrokeGlassPartSpawn()
    {
        if (broke <= 0f)
        {
           
            Instantiate(GlassBrokenParts,transform.position,transform.rotation);
            solidGlass1.SetActive(false);
            Destroy(gameObject);
            roadGlassBroke = true;
            broke = 1f;
        }
    }

    public IEnumerator CrackDelay()
    {
        yield return new WaitForSeconds(1);
        CrackSpawn();
    }

    public IEnumerator BrokeDelay()
    {
        yield return new WaitForSeconds(1);
        BrokeGlassPartSpawn();
    }
}
