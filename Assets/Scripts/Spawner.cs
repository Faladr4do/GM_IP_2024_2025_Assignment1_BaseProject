using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject EnemyShip;

    [SerializeField]
    private GameObject Asteroid;

    [SerializeField]
    private Transform[] SpawnPoints;

    int spawn_index;
    bool asteroid_spawned = false;

    [SerializeField]
    private float waitTime = 2f;
    [SerializeField]
    private float obstacle_speed = 3f;

    [SerializeField]
    private float timed_shot = 2f;

    public List<GameObject> screen_enemies = new List<GameObject>();

    private void Start()
    {
        //StartCoroutine(TimedSpawn());
    }

    private void SpawnHandler()
    {
        //int obstacle_index = Random.Range(0, ObstaclePrefabs.Length);
        //print(obstacle_index);
        if (asteroid_spawned)
        {
            SpawnThree(EnemyShip);
        }
        else 
        {
            SpawnRandom(Asteroid);
        }
        //Instantiate(ObstaclePrefabs[obstacle_index], SpawnPoints[spawn_index].position, ObstaclePrefabs[obstacle_index].transform.rotation); // fix code


    }

    private void FixedUpdate()
    {
        if (screen_enemies.Count == 0)
        {
            SpawnHandler();
        }
    }

    private IEnumerator TimedShot()
    {
        WaitForSeconds waitForTime = new WaitForSeconds(timed_shot);
        while (true)
        {
            yield return waitForTime;
            int select_shooter = Random.Range(0, screen_enemies.Count);
            screen_enemies[select_shooter].GetComponent<EnemyShip>().Shoot();
        }
    }

    private void SpawnRandom(GameObject prefab)
    {
        int spawn_index = Random.Range(0, SpawnPoints.Length);
        Instantiate(prefab, SpawnPoints[spawn_index].position, prefab.transform.rotation);
        asteroid_spawned = true;
    }

    private void SpawnThree(GameObject prefab)
    {
        StopCoroutine(TimedShot());
        for (int index = 0; index < SpawnPoints.Length; index++)
        {
            GameObject enemy = Instantiate(prefab, SpawnPoints[index].position, prefab.transform.rotation);
            screen_enemies.Add(enemy);
            print(screen_enemies.Count);
            //enemy.GetComponent<EnemyShip>().Shoot();
        }
        StartCoroutine(TimedShot());
        asteroid_spawned = false;
    }
}
