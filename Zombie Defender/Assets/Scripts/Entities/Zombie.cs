using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public GameObject particles;
    public float zombieHealth;

    protected int scorePoints;
    protected float speed;
    protected Vector2 velocity = new Vector2();
    protected Rigidbody2D myRigidbody2D;
    protected ParticleSystem ps;

    // Start is called before the first frame update
    void Start()
    {
        scorePoints = 10;
        speed = 1.5f;
        zombieHealth = 1;
        myRigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        ps = particles.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveZombie();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Projectile"))
        {
            Destroy(other.gameObject);
            zombieHealth -= 1;
            //Hit an enemy
            if (zombieHealth <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                Audio.PlaySound("hurtSound");
            }
        }
    }

    //When the zombie is dead
    private void OnDestroy()
    {
        OnZombieDeath();
    }

    protected virtual void OnZombieDeath()
    {

        if (zombieHealth <= 0)
        {
            Audio.PlaySound("enemyDeath");
            GameObject instanceParticles = Instantiate(particles, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            Player.score += scorePoints;
            Score score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
            score.UpdateScoreText();
        }
    }

    protected virtual void MoveZombie()
    {
        velocity.y = -1;
        myRigidbody2D.MovePosition(myRigidbody2D.position + velocity * speed * Time.fixedDeltaTime);
    }

}
