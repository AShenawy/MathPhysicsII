using UnityEngine;
using System.Collections;
using QuaternionScripts;
using VectorScripts;

public class TestQuats : MonoBehaviour
{
    [Header("Values")]
    public Quat quatA;
    public Quat quatB;
    public Vector vector;
    [Header("Results")]
    public Quat resultQuat;

    // Use this for initialization
    void Start()
    {
        resultQuat = Quat.RotateByVector(quatA, vector);
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
