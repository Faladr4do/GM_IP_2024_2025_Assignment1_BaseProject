using System;
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
    private GameObject BossEnemy;

    [SerializeField]
    private Transform[] SpawnPoints;

    [SerializeField]
    private Transform boss_point;

    int spawn_index;
    bool asteroid_spawned = false;

    [SerializeField]
    private float waitTime = 2f;

    [SerializeField]
    public float projectile_speed = 3f;

    [SerializeField]
    private float timed_shot = 2f;

    public List<GameObject> screen_enemies = new List<GameObject>();

    private void Start()
    {
        SpawnRandom(Asteroid);
    }

    private void SpawnHandler()
    {
        if (asteroid_spawned)
        {
            SpawnThree(EnemyShip);
        }
        else 
        {
            SpawnRandom(Asteroid);
        }
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
        yield return new WaitForSeconds(timed_shot);
        int select_shooter = UnityEngine.Random.Range(0, screen_enemies.Count);
        screen_enemies[select_shooter].GetComponent<EnemyShip>().Shoot();
    }

    private void SpawnRandom(GameObject prefab)
    {
        asteroid_spawned = true;
        int spawn_index = UnityEngine.Random.Range(0, SpawnPoints.Length);
        GameObject obstacle = Instantiate(prefab, SpawnPoints[spawn_index].position, prefab.transform.rotation);
        screen_enemies.Add(obstacle);

    }

    private void SpawnThree(GameObject prefab)
    {
        StopCoroutine(TimedShot());
        for (int index = 0; index < SpawnPoints.Length; index++)
        {
            GameObject enemy = Instantiate(prefab, SpawnPoints[index].position, prefab.transform.rotation);
            screen_enemies.Add(enemy);
        }
        StartCoroutine(TimedShot());
        asteroid_spawned = false;
    }

    private void SpawnBoss()
    {
        Instantiate(BossEnemy, boss_point.position, BossEnemy.transform.rotation);
    }

    public void DestroyAll()
    {
        for (int i = 0; i < screen_enemies.Count; i++)
        {
            Destroy(screen_enemies[i]);
        }
        SpawnBoss();
    }
}
