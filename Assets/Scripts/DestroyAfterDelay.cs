using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterDelay : MonoBehaviour
{

    public float delay;
    
    void Update()
    {
        delay -= Time.deltaTime;

        if (delay < 0)
        {
            Destroy(gameObject);
        }
    }
}
