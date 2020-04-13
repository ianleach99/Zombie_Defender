using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemies;
    public Vector2 spawnValues;
    public float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;
    public int startWait;
    public static bool stop;

    int randEnemy;

    // Start is called before the first frame update
    void Start()
    {
        stop = false;
        StartCoroutine(waitSpawner());
    }

    // Update is called once per frame
    void Update()
    {
        spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
    }

    IEnumerator waitSpawner()
    {
        yield return new WaitForSeconds(startWait);

        while (!stop)
        {
            randEnemy = Random.Range(0, enemies.Length);

            Vector2 spawnPosition = new Vector2(Random.Range(-spawnValues.x, spawnValues.x), 4);

            GameObject enemyInstance = Instantiate(enemies[randEnemy], (Vector3)spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);

            yield return new WaitForSeconds(spawnWait);
        }
    }
}
