using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostTakenParticle : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(DelayForParticleBoost());
    }

    public IEnumerator DelayForParticleBoost()
    {
        yield return new WaitForSeconds(3f);

        Destroy(gameObject);
    }
}
