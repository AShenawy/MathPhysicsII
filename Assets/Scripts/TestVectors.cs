using UnityEngine;
using System.Collections;
using VectorScripts;

public class TestVectors : MonoBehaviour
{
    public Vector vectorA;
    public Vector vectorB;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector result = Vector.Subtract(vectorA, vectorB);
        print($"({result.x}, {result.y}, {result.z})");
        
    }
}
