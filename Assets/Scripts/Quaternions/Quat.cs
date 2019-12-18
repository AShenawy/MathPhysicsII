using UnityEngine;
using System.Collections;
using VectorScripts;

namespace QuaternionScripts
{
    /// <summary>
    /// Representation of Quaternion rotations.
    /// </summary>
    [System.Serializable]
    public struct Quat
    {
        public float r;
        public float i;
        public float j;
        public float k;

        public Quat(float r, float i, float j, float k)
        {
            this.r = r;
            this.i = i;
            this.j = j;
            this.k = k;
        }
        
        /// <summary>
        /// Returns normalized quaternion.
        /// </summary>
        /// <param name="quat"></param>
        /// <returns></returns>
        public static Quat Normalize(Quat quat)
        {
            float squareMag = SqrMagnitude(quat.r, quat.i, quat.j, quat.k);

            // if square magnitude is less than 0
            if (squareMag < 0.000001)
                return new Quat(1, quat.i, quat.j, quat.k);

            float inverseSqrMag = 1 / Mathf.Sqrt(squareMag);
            float normalR = quat.r * inverseSqrMag;
            float normalI = quat.i * inverseSqrMag;
            float normalJ = quat.j * inverseSqrMag;
            float normalK = quat.k * inverseSqrMag;

            return new Quat(normalR, normalI, normalJ, normalK);
        }

        // Used for Normalize method
        private static float SqrMagnitude(float r, float i, float j, float k)
        {
            float rSqr = r * r;
            float iSqr = i * i;
            float jSqr = j * j;
            float kSqr = k * k;
            float sum = rSqr + iSqr + jSqr + kSqr;

            return sum;
        }

        /// <summary>
        /// Multiplies quaternion a by quaternion b. Order is important.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Quat Multiply(Quat a, Quat b)
        {
            float rMultiplied = (a.r * b.r) - (a.i * b.i) - (a.j * b.j) - (a.k * b.k);
            float iMultiplied = (a.r * b.i) + (a.i * b.r) + (a.j * b.k) - (a.k * b.j);
            float jMultiplied = (a.r * b.j) + (a.j * b.r) + (a.k * b.i) - (a.i * b.k);
            float kMultiplied = (a.r * b.k) + (a.k * b.r) + (a.i * b.j) - (a.j * b.i);

            return new Quat(rMultiplied, iMultiplied, jMultiplied, kMultiplied);
        }

        /// <summary>
        /// Adds a scaled vector to a quaternion.
        /// </summary>
        /// <param name="quat"></param>
        /// <param name="vector"></param>
        /// <param name="scale"></param>
        /// <returns></returns>
        public static Quat AddScaledVector(Quat quat, Vector vector, float scale)
        {
            // Scale vector using scale value.
            Vector vectorScaled = Vector.MultiplyScalar(vector, scale);
            
            // Create a quaternion from scaled vector with r = 0.
            Quat quatScaled = new Quat(0, vectorScaled.x, vectorScaled.y, vectorScaled.z);

            // Multiply quat with scaled quaternion
            Quat quatMultiplied = Multiply(quat, quatScaled);

            // Multiply-Add all quaternion components with original quat
            float rMultAdd = MultiplyAdd(quatMultiplied.r, quat.r);
            float iMultAdd = MultiplyAdd(quatMultiplied.i, quat.i);
            float jMultAdd = MultiplyAdd(quatMultiplied.j, quat.j);
            float kMultAdd = MultiplyAdd(quatMultiplied.k, quat.k);

            return new Quat(rMultAdd, iMultAdd, jMultAdd, kMultAdd);
        }
        
        // Used for AddScaledVector method.
        private static float MultiplyAdd(float valueMultiplied, float valueAdded)
        {
            return (valueMultiplied * 0.5f) + valueAdded;
        }

        /// <summary>
        /// Rotate quaternion using a vector value.
        /// </summary>
        /// <param name="quat"></param>
        /// <param name="vector"></param>
        /// <returns></returns>
        public  static Quat RotateByVector(Quat quat, Vector vector)
        {
            // Create a quaternion from vector with r = 0.
            Quat vectorQuat = new Quat(0, vector.x, vector.y, vector.z);
            Quat rotatedQuat = Multiply(quat, vectorQuat);

            return rotatedQuat;
        }

        /// <summary>
        /// Converts QuaternionScripts quat into Unity's quaternion.
        /// </summary>
        /// <param name="quat"></param>
        /// <returns></returns>
        public static Quaternion CastToUnityQuaternion(Quat quat)
        {
            return new Quaternion(quat.r, quat.i, quat.j, quat.k);
        }

        /// <summary>
        /// Converts Unity's quaternion into QuaternionScripts quat.
        /// </summary>
        /// <param name="quaternion"></param>
        /// <returns></returns>
        public static Quat CastToQuaternionScript(Quaternion quaternion)
        {
            return new Quat(quaternion.x, quaternion.y, quaternion.z, quaternion.w);
        }
    }
}
