using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VectorScripts
{
    /// <summary>
    /// Creates a new 3 x 1 Vector.
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
        public Vector(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        
        /// <summary>
        /// Add vector a to vector b. Order is irrelevant.
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
    }
}
