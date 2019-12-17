using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VectorScripts
{
    /// <summary>
    /// Representation of 3 x 1 vectors.
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
        /// Add vector a to vector b.
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
        /// Add vector a to vector b.
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

            return new Vector(scaledAddition.x, scaledAddition.y, scaledAddition.z);
        }
    }
}
