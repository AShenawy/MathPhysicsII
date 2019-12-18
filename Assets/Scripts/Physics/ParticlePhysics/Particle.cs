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

    void Start()
    {
        if (PhysicsWorld.physW)
            PhysicsWorld.physW.AddParticle(this);


        // Set initial values
        ammoScript = GetComponent<Ammo>();
        inverseMass = ammoScript.inverseMass;
        damping = ammoScript.damping;
        acceleration = ammoScript.gravityAcceleration;
        velocity = ammoScript.initialVelocity;
    }

    // Update is called once per frame
    void Update()
    {

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
        if(HasFiniteMass() ==  true)
        {
            
        }
    }

    private bool HasFiniteMass()
    {
        if (inverseMass > 0)
            return true;
        else
            return false;
    }
}
