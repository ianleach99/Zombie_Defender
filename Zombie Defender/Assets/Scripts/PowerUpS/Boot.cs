using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boot : MonoBehaviour
{

    public static bool inAction = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Audio.PlaySound("playerCollect");
            StartCoroutine(GiveSpeedBoost(5.0f, 6f));
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    IEnumerator GiveSpeedBoost(float time, float newSpeed)
    {
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        float playerSpeedOriginal = player.speed;
        player.speed = newSpeed;
        yield return new WaitForSeconds(time);
        player.speed = playerSpeedOriginal;
        Destroy(gameObject);
    }

}
