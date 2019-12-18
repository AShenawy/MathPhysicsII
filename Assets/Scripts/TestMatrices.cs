using UnityEngine;
using System.Collections;
using MatrixScripts;
using VectorScripts;

public class TestMatrices : MonoBehaviour
{
    [Header("Vector Group 1")]
    public Vector U1;
    public Vector V1;
    public Vector W1;
    [Header("Vector Group 2")]
    public Vector U2;
    public Vector V2;
    public Vector W2;
    [Header("Matrices")]
    public Matrix3x3 matrix1;
    public Matrix3x3 matrix2;
    [Header("Results View")]
    public Matrix3x3 resultMatrix;
    public Vector resultVector;

    // Use this for initialization
    void Start()
    {
        matrix1 = Matrix3x3.SetComponents(U1, V1, W1);
        matrix2 = Matrix3x3.SetComponents(U2, V2, W2);

        //float resFloat = Matrix3x3.Determinant(matrix1);
        //print(resFloat);

        resultMatrix = Matrix3x3.MultiplyScalar(matrix2, 2);
        //print(resultMatrix);

        //resultVector = Matrix3x3.Transform(matrix1, U2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
