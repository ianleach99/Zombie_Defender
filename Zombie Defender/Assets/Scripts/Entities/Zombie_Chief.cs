using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Chief : Zombie
{
    // Start is called before the first frame update
    void Start()
    {
        scorePoints = 20;
        speed = 1.7f;
        zombieHealth = 2;
        myRigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        ps = particles.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveZombie();
    }

    new void MoveZombie()
    {
        velocity.y = -1;
        myRigidbody2D.MovePosition(myRigidbody2D.position + velocity * speed * Time.fixedDeltaTime);
    }
}
