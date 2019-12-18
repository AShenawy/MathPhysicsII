using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VectorScripts
{
    /// <summary>
    /// Representation of 3x1 vectors.
    /// </summary>
    [System.Serializable]
    public struct Vector
    {
        public float x;
        public float y;
        public float z;
        
        public Vector(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        
        /// <summary>
        /// Add two vectors.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector Add(Vector a, Vector b)
        {
            float addX = a.x + b.x;
            float addY = a.y + b.y;
            float addZ = a.z + b.z;
    
            return new Vector(addX, addY, addZ);
        }

        /// <summary>
        /// Add two vectors.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector Add(float aX, float aY, float aZ, float bX, float bY, float bZ)
        {
            float addX = aX + bX;
            float addY = aY + bY;
            float addZ = aZ + bZ;

            return new Vector(addX, addY, addZ);
        }

        /// <summary>
        /// Subtract vector b from vector a. Order is important.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector Subtract(Vector a, Vector b)
        {
            float subX = a.x - b.x;
            float subY = a.y - b.y;
            float subZ = a.z - b.z;

            return new Vector(subX, subY, subZ);
        }

        /// <summary>
        /// Hadamard Product. Also known as Compound Product.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector HadamardProduct(Vector a, Vector b)
        {
            float hadX = a.x * b.x;
            float hadY = a.y * b.y;
            float hadZ = a.z * b.z;

            return new Vector(hadX, hadY, hadZ);
        }

        /// <summary>
        /// Hadamard Division. Divides vector a by vector b. Order is important.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector HadamardDivision(Vector a, Vector b)
        {
            float hadX = a.x / b.x;
            float hadY = a.y / b.y;
            float hadZ = a.z / b.z;

            return new Vector(hadX, hadY, hadZ);
        }

        /// <summary>
        /// Add scalar value b to vector a.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector AddScalar(Vector a, float b)
        {
            float scalX = a.x + b;
            float scalY = a.y + b;
            float scalZ = a.z + b;

            return new Vector(scalX, scalY, scalZ);
        }

        /// <summary>
        /// Subtract scalar value b from vector a. Order is important.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector SubtractScalar(Vector a, float b)
        {
            float scalX = a.x - b;
            float scalY = a.y - b;
            float scalz = a.z - b;

            return new Vector(scalX, scalY, scalz);
        }

        /// <summary>
        /// Multiply scalar value b by vector a.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector MultiplyScalar(Vector a, float b)
        {
            float scalX = a.x * b;
            float scalY = a.y * b;
            float scalZ = a.z * b;

            return new Vector(scalX, scalY, scalZ);
        }

        /// <summary>
        /// Divide vector a by scalar value b. Order is important.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector DivideVectorScalar(Vector a, float b)
        {
            float scalX = a.x / b;
            float scalY = a.y / b;
            float scalZ = a.z / b;

            return new Vector(scalX, scalY, scalZ);
        }

        /// <summary>
        /// Divide scalar value a by vector b. Order is important.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector DivideScalarVector(float a, Vector b)
        {
            float scalX = a / b.x;
            float scalY = a / b.y;
            float scalZ = a / b.z;

            return new Vector(scalX, scalY, scalZ);
        }
        
        /// <summary>
        /// Scale vector b by scalar value c, then add it to vector a.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static Vector AddScaledVector(Vector a, Vector b, float c)
        {
            Vector scaledVector = MultiplyScalar(b, c);
            Vector scaledAddition = Add(a, scaledVector);
            
            return scaledAddition;
        }
        
        /// <summary>
        /// Dot product of two vectors.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static float Dot(Vector a, Vector b)
        {
            Vector productVector = HadamardProduct(a, b);
            float componentSum = productVector.x + productVector.y + productVector.z;
            
            return componentSum;
        }

        /// <summary>
        /// Returns the square magnitude of vector.
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static float SqrMagnitude(Vector vector)
        {
            float productDot = Dot(vector, vector);
            
            return productDot;
        }

        /// <summary>
        /// Returns the magnitude/norm/scale/length of vector.
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public static float Magnitude(Vector vector)
        {
            float sqrMag = SqrMagnitude(vector);
            float magnitude = Mathf.Sqrt(sqrMag);
            
            return magnitude;
        }

        /// <summary>
        /// Returns the normal or the direction of vector.
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public static Vector Normalize(Vector vector)
        {
            float vectorMagnitude = Magnitude(vector);
            Vector vectorNormal = DivideVectorScalar(vector, vectorMagnitude);
            
            return vectorNormal;
        }

        /// <summary>
        /// Returns the invert of vector.
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public static Vector Invert(Vector vector)
        {
            Vector vectorInvert = MultiplyScalar(vector, -1);

            return vectorInvert;
        }

        /// <summary>
        /// Converts from VectorScript vector to Unity's Vector3.
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public static Vector3 CastToUnityVector(Vector vector)
        {
            return new Vector3(vector.x, vector.y, vector.z);
        }

        /// <summary>
        /// Converts from Unity's Vector3 to VectorScript vector.
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public static Vector CastToVectorScript(Vector3 vector)
        {
            return new Vector(vector.x, vector.y, vector.z);
        }
    }
}