using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassParts : MonoBehaviour
{
   
    void Start()
    {
        StartCoroutine(DestroyGlassParts());
    }

   
    void Update()
    {
        
    }

    public IEnumerator DestroyGlassParts()
    {
        yield return new WaitForSeconds(5);
        Debug.Log("CleanedGlassParts");
        Destroy(gameObject);
    }
}
