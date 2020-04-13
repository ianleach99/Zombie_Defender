using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathTrigger : MonoBehaviour
{
    public GameObject particles;

    private void Start()
    {
        LifeText lives = GameObject.FindGameObjectWithTag("Lives").GetComponent<LifeText>();
        lives.UpdateLivesText();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //When the enemies invade the player territory
        if (other.gameObject.CompareTag("Enemy"))
        {
           if(GameObject.FindGameObjectWithTag("Player") != null)
            {
                Player.lives--; //Decrease the players lives
                LifeText lives = GameObject.FindGameObjectWithTag("Lives").GetComponent<LifeText>();
                lives.UpdateLivesText(); //Show the current lives
                GameObject instanceParticles = Instantiate(particles, new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z), Quaternion.identity); //Particles
                if (Player.lives > 0) //If the player isn't dead play the zombie blip sound
                {
                    Audio.PlaySound("enemyEnter");
                }
                Destroy(other.gameObject);

                if (Player.lives <= 0)
                {
                    Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
                    player.OnPlayerDeath();
                }
            }
        }
    }
}
