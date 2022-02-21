using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glass : MonoBehaviour
{
    public GameObject GlassBreak;
    public static float controlGlassSolid;
    public static bool glassEnter;
    void Start()
    {
        controlGlassSolid = 0;
        glassEnter = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PlayerCar")
        {
            Debug.Log("GlassBreak!!");
            glassEnter = true;

            if (CarController.MainCarWeight > 1 || CarController.MainSpeed > 1)
            {
                controlGlassSolid = 0;    
                Instantiate(GlassBreak, transform.position, transform.rotation);
                Destroy(gameObject);
            }
            else
            {
                controlGlassSolid = 1;
            }
        }
    }
}
