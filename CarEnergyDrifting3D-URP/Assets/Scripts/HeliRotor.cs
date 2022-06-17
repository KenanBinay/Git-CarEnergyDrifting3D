using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeliRotor : MonoBehaviour
{
    public float speed,X_rotation, Y_rotation, Z_rotation;

    void Start()
    {
        
    }
    void Update()
    {
        transform.Rotate(new Vector3(X_rotation, Y_rotation, Z_rotation) * speed * Time.deltaTime);
    }
}
