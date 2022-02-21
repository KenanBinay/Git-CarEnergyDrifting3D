using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostsController : MonoBehaviour
{
    [SerializeField] Vector3 OriginPos;
    public GameObject particle;
    void Start()
    {
        if (gameObject.CompareTag("SpeedBoost"))
        {       
            OriginPos = new Vector3(transform.localPosition.x, -4.5f, transform.localPosition.z);
            float PosX = Random.Range(-0.63f, 5.56f);

            transform.localPosition = new Vector3(PosX, OriginPos.y, OriginPos.z);
        }
        else if (gameObject.CompareTag("WeightBoost"))
        {
            OriginPos = new Vector3(transform.localPosition.x, -3.8f, transform.localPosition.z);
            float PosX = Random.Range(-0.63f, 5.56f);

            transform.localPosition = new Vector3(PosX, OriginPos.y, OriginPos.z);
        }
       
    }
/*
    public void OnCollisionEnter(Collision collision)
    {
        if (gameObject.CompareTag("PlayerCar"))
        {
            Quaternion posParticle = Quaternion.Euler(OriginPos);
            Instantiate(particle, OriginPos, transform.rotation);

        }
    }
*/
}
