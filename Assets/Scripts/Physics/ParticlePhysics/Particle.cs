using UnityEngine;
using System.Collections;

public class Particle : MonoBehaviour
{

    void Start()
    {
        if (PhysicsWorld.physW)
            PhysicsWorld.physW.AddParticle(this);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
