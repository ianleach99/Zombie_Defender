using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject[] powerUps;
    public Vector2 spawnValues;
    public float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;
    public int startWait;
    public static bool stop;

    int randPowerUp;

    void Start()
    {
        stop = false;
        StartCoroutine(waitSpawner());
    }

    void Update()
    {
        spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
    }

    IEnumerator waitSpawner()
    {
        yield return new WaitForSeconds(startWait);

        while (!stop)
        {
            randPowerUp = Random.Range(0, powerUps.Length);

            Vector2 spawnPosition = new Vector2(Random.Range(-spawnValues.x, spawnValues.x), 4);

            GameObject enemyInstance = Instantiate(powerUps[randPowerUp], (Vector3)spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);

            yield return new WaitForSeconds(spawnWait);
        }
    }
}
