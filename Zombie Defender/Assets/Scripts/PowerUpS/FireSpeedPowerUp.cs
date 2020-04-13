using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpeedPowerUp : MonoBehaviour
{
    public static bool inAction = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Audio.PlaySound("playerCollect");
            StartCoroutine(GiveFireSpeedUpgrade(5.0f, 0f));
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    IEnumerator GiveFireSpeedUpgrade(float time, float newSpeed)
    {
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        float playerFireDelayOriginal = player.fireDelay;
        player.fireDelay = newSpeed;
        yield return new WaitForSeconds(time);
        player.fireDelay = playerFireDelayOriginal;
        Destroy(gameObject);
    }
}
