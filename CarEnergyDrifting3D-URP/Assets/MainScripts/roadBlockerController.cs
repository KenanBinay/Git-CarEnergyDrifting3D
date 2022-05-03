using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roadBlockerController : MonoBehaviour
{
    [SerializeField] private GameObject _blockers,_playerCar;
    float _distance,_dropPoint;
    void Start()
    {
        _dropPoint = transform.position.z - 40;
    }

    void Update()
    {
        _distance = _playerCar.transform.position.z;
        if (_distance > _dropPoint)
        {
            Debug.Log("RoadBlocker Expand");
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
