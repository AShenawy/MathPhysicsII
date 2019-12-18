using UnityEngine;
using System.Collections;
using VectorScripts;

public class Particle : MonoBehaviour
{
    public Ammo ammoScript;

    private float inverseMass;
    private float damping;
    private Vector velocity;
    private Vector acceleration;
    private Vector forceAccum;

    void Start()
    {
        if (PhysicsWorld.physW)
            PhysicsWorld.physW.AddParticle(this);


        // Set initial values
        ammoScript = GetComponent<Ammo>();
        inverseMass = ammoScript.inverseMass;
        damping = ammoScript.damping;
        acceleration = ammoScript.gravityAcceleration;
        velocity = SetVelocityForward();
    }

    // Update is called once per frame
    void Update()
    {
        Integrate();
    }

    private Vector SetVelocityForward()
    {
        Vector initVelocity = ammoScript.initialVelocity;
        float velocityMag = Vector.Magnitude(initVelocity);

        // Shoot forward
        Vector forwardVector = Vector.CastToVectorScript(Vector3.forward);
        Vector forwardVelocity = Vector.MultiplyScalar(forwardVector, velocityMag);
        
        return forwardVelocity;
    }

    public void Integrate()
    {
        // if mass is 0 or less then exit method.
        if (HasFiniteMass() == false)
            return;

        // Add force to acceleration.
        Vector accelerationForce = Vector.AddScaledVector(acceleration, forceAccum, Time.deltaTime);
        acceleration = accelerationForce;

        // Add acceleration to velocity
        Vector accelerationVelocity = Vector.AddScaledVector(velocity, acceleration, Time.deltaTime);

        // Add dampening to velocity
        float dampingImpact = Mathf.Pow(damping, Time.deltaTime);
        Vector dampenedVelocity = Vector.MultiplyScalar(accelerationVelocity, dampingImpact);

        velocity = dampenedVelocity;

        // Add velocity to location
        if(gameObject != null)  // if particle still exists
        {
            Vector particlePos = Vector.CastToVectorScript(transform.position);
            Vector motionVelocity = Vector.AddScaledVector(particlePos, dampenedVelocity, Time.deltaTime);
            transform.position = Vector.CastToUnityVector(motionVelocity);
        }

    }

    public bool HasFiniteMass()
    {
        if (inverseMass > 0)
            return true;
        else
            return false;
    }

    public void AddForce(Vector force)
    {
        forceAccum = Vector.Add(force, forceAccum);
    }

    public float GetMass()
    {
        return Mathf.Pow(inverseMass, -1);
    }
}
