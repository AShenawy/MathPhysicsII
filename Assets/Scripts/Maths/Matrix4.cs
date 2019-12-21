using UnityEngine;
using System.Collections;
using VectorScripts;

namespace MatrixScripts
{
    /// <summary>
    /// Representation of 4x4 Matrices.
    /// </summary>
    [System.Serializable]
    public struct Matrix4
    {
        public Matrix3 m;
        public Vector t;
    
        public Matrix4(Matrix3 matrix, Vector t)
        {
            m = matrix;
            this.t = t;
        }

        /// <summary>
        /// Creates a diagonal 4x4 matrix.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public static Matrix4 SetDiagonal(float x, float y, float z)
        {
            Matrix3 matrix = Matrix3.SetDiagonal(x, y, z);
            Vector t = new Vector();

            return new Matrix4(matrix, t);
        }

        public static Vector TransformDirection(Matrix4 matrix4, Vector vector)
        {
            Matrix3 matrixTrans = Matrix3.Transpose(matrix4.m);
            float dotX = Vector.Dot(vector, matrixTrans.u);
            float dotY = Vector.Dot(vector, matrixTrans.v);
            float dotZ = Vector.Dot(vector, matrixTrans.w);

            return new Vector(dotX, dotY, dotZ);
        }

        public static Vector Transform(Matrix4 matrix4, Vector vector)
        {
            Vector vectorTransformDirection4 = TransformDirection(matrix4, vector);
            Vector vectorAddition = Vector.Add(vectorTransformDirection4, matrix4.t);

            return vectorAddition;
        }

        public static Matrix4 Multiply(Matrix4 a, Matrix4 b)
        {
            Matrix3 matrixMultiply = Matrix3.Multiply(b.m, a.m);
            Vector vectorTransform = Transform(a, b.t);

            return new Matrix4(matrixMultiply, vectorTransform);
        }

        /// <summary>
        /// Returns the determinant of the matrix component of a matrix4.
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static float Determinant(Matrix3 matrix)
        {
            float multiplyZYX = matrix.u.z * matrix.v.y * matrix.w.x;
            float multiplyYZX = matrix.u.y * matrix.v.z * matrix.w.x;
            float multiplyZXY = matrix.u.z * matrix.v.x * matrix.w.y;
            float multiplyXZY = matrix.u.x * matrix.v.z * matrix.w.y;
            float multiplyYXZ = matrix.u.y * matrix.v.x * matrix.w.z;
            float multiplyXYZ = matrix.u.x * matrix.v.y * matrix.w.z;
            float summation = ((((0 - multiplyZYX) + (multiplyYZX + multiplyZXY)) - multiplyXZY) - multiplyYXZ) + multiplyXYZ;

            return summation;
        }

        /// <summary>
        /// Returns the inverse of a matrix4.
        /// </summary>
        /// <param name="matrix4"></param>
        /// <returns></returns>
        public static Matrix4 Inverse(Matrix4 matrix4)
        {
            float determinant = Determinant(matrix4.m);
            
            // check if inverse determinant will yield infinity.
            if (determinant == 0)
            {
                Debug.Log("Determinant = 0, cannot inverse");
                return new Matrix4();
            }

            // Matrix calculations
            Vector multDivVW = MultiplyDivideDeterminantColumn(matrix4.m.v, matrix4.m.w, determinant);
            float yInverseVW = multDivVW.y * -1;
            Vector vectorU = new Vector(multDivVW.x, yInverseVW, multDivVW.z);

            Vector multiDivUW = MultiplyDivideDeterminantColumn(matrix4.m.u, matrix4.m.w, determinant);
            float xInverseUW = multiDivUW.x * -1;
            float zInverseUW = multiDivUW.z * -1;
            Vector vectorV = new Vector(xInverseUW, multiDivUW.y, zInverseUW);

            Vector multiDivUV = MultiplyDivideDeterminantColumn(matrix4.m.u, matrix4.m.v, determinant);
            float yInverseUV = multiDivUV.y * -1;
            Vector vectorW = new Vector(multiDivUV.x, yInverseUV, multiDivUV.z);

            Matrix3 matrixTransposed = Matrix3.Transpose(new Matrix3(vectorU, vectorV, vectorW));

            // T calculations
            float xT = CalculateTX(matrix4.m.u, matrix4.m.v, matrix4.m.w, matrix4.t);
            float yT = CalculateTY(matrix4.m.u, matrix4.m.v, matrix4.m.w, matrix4.t);
            float zT = CalculateTZ(matrix4.m.u, matrix4.m.v, matrix4.m.w, matrix4.t);

            float xTDetermin = xT * (1 / determinant);
            float yTDetermin = yT * (1 / determinant);
            float zTDetermin = zT * (1 / determinant);

            Vector inverseT = new Vector(xTDetermin, yTDetermin, zTDetermin);

            return new Matrix4(matrixTransposed, inverseT);
        }

        // Helper calculation for Inverse method.
        private static float CalculateTX(Vector u, Vector v, Vector w, Vector t)
        {
            float vZwY = v.z * w.y * t.x;
            float vYwZ = v.y * w.z * t.x;
            float vZwX = v.z * w.x * t.y;
            float vXwZ = v.x * w.z * t.y;
            float vYwX = v.y * w.x * t.z;
            float vXwY = v.x * w.y * t.z;
            float sum = (((vZwY - vYwZ) - vZwX) + vXwZ + vYwX) - vXwY;

            return sum;
        }

        // Helper calculation for Inverse method.
        private static float CalculateTY(Vector u, Vector v, Vector w, Vector t)
        {
            float uZwY = u.z * w.y * t.x;
            float uYwZ = u.y * w.z * t.x;
            float uZwX = u.z * w.x * t.y;
            float uXwZ = u.x * w.z * t.y;
            float uYwX = u.y * w.x * t.z;
            float uXwY = u.x * w.y * t.z;
            float sum = ((((0 - uZwY) + uYwZ + uZwX) - uXwZ) - uYwX) + uXwY;

            return sum;
        }

        // Helper calculation for Inverse method.
        private static float CalculateTZ(Vector u, Vector v, Vector w, Vector t)
        {
            float uZvY = u.z * v.y * t.x;
            float uYvZ = u.y * v.z * t.x;
            float uZvX = u.z * v.x * t.y;
            float uXvZ = u.x * v.z * t.y;
            float uYvX = u.y * v.x * t.z;
            float uXvY = u.x * v.y * t.z;
            float sum = (((uZvY - uYvZ) - uZvX) + uXvZ + uYvX) - uXvY;

            return sum;
        }

        // Helper calculation for MultiplyDivideDeterminantColumn method.
        private static float MultiplyDivideDeterminant(float a, float b, float c, float d, float det)
        {
            float multSubInputs = (a * d) - (b * c);
            float multiDivideDet = multSubInputs * (1 / det);

            return multiDivideDet;
        }

        // Helper calculation for Inverse method.
        private static Vector MultiplyDivideDeterminantColumn(Vector a, Vector b, float det)
        {
            float x = MultiplyDivideDeterminant(a.y, b.z, b.y, a.z, det);
            float y = MultiplyDivideDeterminant(a.x, b.z, a.z, b.x, det);
            float z = MultiplyDivideDeterminant(a.x, b.y, a.y, b.x, det);

            return new Vector(x, y, z);
        }
    }

}
