using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public float maxLifetime;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, maxLifetime);   
    }
}
