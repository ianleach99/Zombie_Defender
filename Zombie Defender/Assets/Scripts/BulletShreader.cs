using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShreader : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Destroy bullets when they leave screen
        if (other.gameObject.CompareTag("Projectile"))
        {
            Destroy(other.gameObject);
        }
    }
}
