using UnityEngine;
using System.Collections;
using VectorScripts;
using QuaternionScripts;

namespace MatrixScripts
{
    /// <summary>
    /// Representation of 3x3 Matrices.
    /// </summary>
    [System.Serializable]
    public struct Matrix3
    {
        public Vector u;
        public Vector v;
        public Vector w;

        public Matrix3(Vector u, Vector v, Vector w)
        {
            this.u = u;
            this.v = v;
            this.w = w;
        }

        /// <summary>
        /// Combine 3 vectors into a 3x3 matrix.
        /// </summary>
        /// <param name="column1">First column in 3x3 matrix.</param>
        /// <param name="column2">Second column in 3x3 matrix.</param>
        /// <param name="column3">Third column in 3x3 matrix.</param>
        /// <returns></returns>
        public static Matrix3 SetComponents(Vector column1, Vector column2, Vector column3)
        {
            return new Matrix3(column1, column2, column3);
        }

        /// <summary>
        /// Returns a diagonal matrix from 3 float values.
        /// </summary>
        /// <param name="x">UX (1,1) component of matrix.</param>
        /// <param name="y">VY (2,2) component of matrix.</param>
        /// <param name="z">WZ (3,3) component of matrix.</param>
        /// <returns></returns>
        public static Matrix3 SetDiagonal(float x, float y, float z)
        {
            Vector col1 = new Vector(x, 0, 0);
            Vector col2 = new Vector(0, y, 0);
            Vector col3 = new Vector(0, 0, z);

            return new Matrix3(col1, col2, col3);
        }

        /// <summary>
        /// Returns determinant of matrix.
        /// Cannot be zero. Used for Inverse.
        /// </summary>
        /// <param name="matrix3"></param>
        /// <returns></returns>
        public static float Determinant(Matrix3 matrix3)
        {
            // First set multiplications U.X * V.Y * W.Z and U.X * W.Y * V.Z
            float productUVW = matrix3.u.x * matrix3.v.y * matrix3.w.z;
            float productUWV = matrix3.u.x * matrix3.w.y * matrix3.v.z;

            // First step subtraction
            float subtraction1 = productUVW - productUWV;

            float productVUW = matrix3.v.x * matrix3.u.y * matrix3.w.z;

            // Second step subtraction
            float subtraction2 = subtraction1 - productVUW;

            float productWUV = matrix3.w.x * matrix3.u.y * matrix3.v.z;

            // Third step addition
            float addition1 = subtraction2 + productWUV;

            float productVWU = matrix3.v.x * matrix3.w.y * matrix3.u.z;

            // Fourth step addition
            float addition2 = addition1 + productVWU;

            float productWVU = matrix3.w.x * matrix3.v.y * matrix3.u.z;

            // Fifth step subtraction (determinant)
            float determinant = addition2 - productWVU;

            return determinant;
        }

        /// <summary>
        /// Returns the transpose of the matrix.
        /// </summary>
        /// <param name="matrix3"></param>
        /// <returns></returns>
        public static Matrix3 Transpose(Matrix3 matrix3)
        {
            Vector transU = new Vector(matrix3.u.x, matrix3.v.x, matrix3.w.x);
            Vector transV = new Vector(matrix3.u.y, matrix3.v.y, matrix3.w.y);
            Vector transW = new Vector(matrix3.u.z, matrix3.v.z, matrix3.w.z);

            return new Matrix3(transU, transV, transW);
        }

        /// <summary>
        /// Adds two matrices.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Matrix3 Add(Matrix3 a, Matrix3 b)
        {
            Vector addedU = Vector.Add(a.u, b.u);
            Vector addedV = Vector.Add(a.v, b.v);
            Vector addedW = Vector.Add(a.w, b.w);

            return new Matrix3(addedU, addedV, addedW);
        }

        /// <summary>
        /// Adds scalar value b to matrix3 a.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Matrix3 AddScalar(Matrix3 a, float b)
        {
            Vector scalarAddV = Vector.AddScalar(a.v, b);
            Vector scalarAddU = Vector.AddScalar(a.u, b);
            Vector scalarAddW = Vector.AddScalar(a.w, b);

            return new Matrix3(scalarAddU, scalarAddV, scalarAddW);
        }

        /// <summary>
        /// Returns the transform transpose vector of matrix3 multiplied by vector. Step for traditional transform.
        /// </summary>
        /// <param name="matrix3"></param>
        /// <param name="vector"></param>
        /// <returns></returns>
        public static Vector TransformTranspose(Matrix3 matrix3, Vector vector)
        {
            float dotX = Vector.Dot(matrix3.u, vector);
            float dotY = Vector.Dot(matrix3.v, vector);
            float dotZ = Vector.Dot(matrix3.w, vector);

            return new Vector(dotX, dotY, dotZ);
        }

        /// <summary>
        /// Returns vector transformation by matrix3.
        /// </summary>
        /// <param name="matrix3"></param>
        /// <param name="vector"></param>
        /// <returns></returns>
        public static Vector Transform(Matrix3 matrix3, Vector vector)
        {
            Matrix3 transMatrix = Transpose(matrix3);
            Vector transformVector = TransformTranspose(transMatrix, vector);

            return transformVector;
        }

        /// <summary>
        /// Multiply two matrices. Order is important.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Matrix3 Multiply(Matrix3 a, Matrix3 b)
        {
            Matrix3 transposeA = Transpose(a);
            Vector multiplyU = TransformTranspose(b, transposeA.u);
            Vector multiplyV = TransformTranspose(b, transposeA.v);
            Vector multiplyW = TransformTranspose(b, transposeA.w);

            return new Matrix3(multiplyU, multiplyV, multiplyW);
        }

        /// <summary>
        /// Multiply matrix3 be scalar value.
        /// </summary>
        /// <param name="matrix3"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Matrix3 MultiplyScalar(Matrix3 matrix3, float value)
        {
            Vector scaledU = Vector.MultiplyScalar(matrix3.u, value);
            Vector scaledV = Vector.MultiplyScalar(matrix3.v, value);
            Vector scaledW = Vector.MultiplyScalar(matrix3.w, value);

            return new Matrix3(scaledU, scaledV, scaledW);
        }

        /// <summary>
        /// Converts a QuaternionScripts quat into a rotational matrix3.
        /// </summary>
        /// <param name="quat"></param>
        /// <returns></returns>
        public static Matrix3 SetOrientation(Quat quat)
        {
            float uX = 1 - ((quat.j * quat.j * 2) + (quat.k * quat.k * 2));
            float uY = (quat.i * quat.j * 2) - (quat.k * quat.r * 2);
            float uZ = (quat.i * quat.k * 2) + (quat.j * quat.r * 2);
            float vX = (quat.i * quat.j * 2) + (quat.k * quat.r * 2);
            float vY = 1 - ((quat.j * quat.j * 2) + (quat.k * quat.k * 2));
            float vZ = (quat.j * quat.k * 2) - (quat.i * quat.r * 2);
            float wX = (quat.i * quat.k * 2) - (quat.j * quat.r * 2);
            float wY = (quat.j * quat.k * 2) + (quat.i * quat.r * 2);
            float wZ = 1 - ((quat.i * quat.i * 2) + (quat.j * quat.j * 2));
            Vector colU = new Vector(uX, uY, uZ);
            Vector colV = new Vector(vX, vY, vZ);
            Vector colW = new Vector(wX, wY, wZ);

            return new Matrix3(colU, colV, colW);
        }

        /// <summary>
        /// Returns the inverse of matrix3.
        /// </summary>
        /// <param name="matrix3"></param>
        /// <returns></returns>
        public static Matrix3 Inverse(Matrix3 matrix3)
        {
            float determinant = Determinant(matrix3);

            // check if inverse determinant will yield infinity.
            if(determinant == 0)
            {
                Debug.Log("Determinant = 0, cannot inverse");
                return new Matrix3();
            }

            Vector inverseU = MultiplyDivideDeterminantColumn(matrix3.v, matrix3.w, determinant);
            Vector inverseV = MultiplyDivideDeterminantColumn(matrix3.u, matrix3.w, determinant);
            Vector inverseW = MultiplyDivideDeterminantColumn(matrix3.u, matrix3.v, determinant);

            return new Matrix3(inverseU, inverseV, inverseW);
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
