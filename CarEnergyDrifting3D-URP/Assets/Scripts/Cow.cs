using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : MonoBehaviour
{
    public float degreesPerSecond;

    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0f, 0f, 1f) * degreesPerSecond * Time.deltaTime);
    }
}
