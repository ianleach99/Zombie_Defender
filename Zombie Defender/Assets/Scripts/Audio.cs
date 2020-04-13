using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public static AudioClip enemyDeathSound, playerFireSound, playerCollectSound, gameOverSound, enemyEnterSound, selectSound, hurtSound, evilLaughterSound;

    static AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        enemyDeathSound = Resources.Load<AudioClip>("enemyDeath");
        playerFireSound = Resources.Load<AudioClip>("fireSound");
        playerCollectSound = Resources.Load<AudioClip>("collectSound");
        gameOverSound = Resources.Load<AudioClip>("gameOver");
        enemyEnterSound = Resources.Load<AudioClip>("enemyEnter");
        selectSound = Resources.Load<AudioClip>("selectSound");
        hurtSound = Resources.Load<AudioClip>("hurtSound");
        evilLaughterSound = Resources.Load<AudioClip>("evilLaughterSound");

        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch(clip)
        {
            case "enemyDeath":
                audioSource.PlayOneShot(enemyDeathSound);
                break;
            case "playerFire":
                audioSource.PlayOneShot(playerFireSound);
                break;
            case "playerCollect":
                audioSource.PlayOneShot(playerCollectSound);
                break;
            case "gameOver":
                audioSource.PlayOneShot(gameOverSound);
                break;
            case "enemyEnter":
                audioSource.PlayOneShot(enemyEnterSound);
                break;
            case "selectSound":
                audioSource.PlayOneShot(selectSound);
                break;
            case "hurtSound":
                audioSource.PlayOneShot(hurtSound);
                break;
            case "evilLaughterSound":
                audioSource.PlayOneShot(evilLaughterSound);
                break;
        }
    }


}
