using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassParts : MonoBehaviour
{
    AudioSource glassBreak;
    void Start()
    {
        glassBreak = GetComponent<AudioSource>();
        if (PlayerPrefs.GetString("sfx") == "on") { glassBreak.Play(); }
      
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
