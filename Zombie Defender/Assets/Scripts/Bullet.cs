using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject enemyKillParticles;       //Particle to spawn when kill a zombie

    private Vector2 velocity = new Vector2();   //The speed and direction of the bullet
    private float speed = 7;                    //The speed of the bullet
    private Rigidbody2D myRigidbody2D;

    private void Start()
    {
        myRigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        velocity.y = 1;
    }

    private void FixedUpdate()
    {
        //Move the bullet
        myRigidbody2D.MovePosition(myRigidbody2D.position + velocity * speed * Time.fixedDeltaTime);
    }
}
