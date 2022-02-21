using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopSignSolid : MonoBehaviour
{
    [SerializeField] GameObject stopSignRB;
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayerCar"))
        {
            Instantiate(stopSignRB,transform.position,transform.rotation);
            Destroy(gameObject);
        }
    }
}
