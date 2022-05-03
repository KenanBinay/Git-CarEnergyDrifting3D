using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roadBlockerController : MonoBehaviour
{
    [SerializeField] private GameObject _blockers;
    float _distance,_dropPoint;
    private Vector3 downPos, upPos, endVelocity = Vector3.zero;

    void Start()
    {
        
        downPos = new Vector3(_blockers.transform.position.x, -2f, _blockers.transform.position.z);
        _dropPoint = transform.position.z - 35;
        _blockers.transform.position = downPos;
    }

    void Update()
    {
        _distance = CarController._carTransformZ;
        if (_distance > _dropPoint)
        {
            _blockers.transform.localPosition = Vector3.SmoothDamp(_blockers.transform.localPosition, upPos, ref endVelocity, 0.2f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    { 
        if (collision.gameObject.tag == "PlayerCar")
        {
            CarController._frontCollision = true;
            CarController.gameEnd = true;
        }
    }
}
