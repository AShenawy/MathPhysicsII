using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PhysicsWorld : MonoBehaviour
{
    public static PhysicsWorld physW;

    public List<Particle> particles;
    
    void Awake()
    {
        physW = GetComponent<PhysicsWorld>();
    }

    // Update is called once per frame
    void Update()
    {
        //foreach(Particle particle in particles)
        //{
        //    particle.Integrate();
        //}
    }

    public void AddParticle(Particle particle)
    {
        particles.Add(particle);
    }
}
