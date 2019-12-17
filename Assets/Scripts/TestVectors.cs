using UnityEngine;
using System.Collections;
using VectorScripts;

public class TestVectors : MonoBehaviour
{
    public Vector vectorA;
    public Vector vectorB;
    public float scalar;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector result = Vector.DivideVectorScalar(vectorA, scalar);
        print($"({result.x}, {result.y}, {result.z})");
    }
}
