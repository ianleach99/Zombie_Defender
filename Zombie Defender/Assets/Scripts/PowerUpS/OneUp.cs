using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Audio.PlaySound("playerCollect");
            Player.lives++;
            LifeText lives = GameObject.FindGameObjectWithTag("Lives").GetComponent<LifeText>();
            lives.UpdateLivesText(); //Show the current lives
            Destroy(gameObject);
        }
    }
}
