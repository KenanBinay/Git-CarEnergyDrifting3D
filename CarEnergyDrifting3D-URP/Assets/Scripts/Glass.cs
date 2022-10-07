using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glass : MonoBehaviour
{
    public GameObject GlassBreak;

    public static bool glassEnter;
    void Start()
    {     
        glassEnter = false;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "PlayerCar")
        {
            Debug.Log("GlassBreak!!");
            glassEnter = true;

            if (CarController.MainCarWeight > 1 || CarController.MainSpeed > 1)
            {
                CarController.gameEnd = false;
                Instantiate(GlassBreak, transform.position, transform.rotation);
                Destroy(gameObject);
            }
            else
            {
                CarController._frontCollision = true;
                CarController.gameEnd = true;
            }
        }
    }
}
