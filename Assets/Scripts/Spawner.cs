using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] ObstaclePrefabs;

    [SerializeField]
    private Transform[] SpawnPoints;

    int spawn_index;
    bool asteroid_spawned;

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

    private void TimedSpawn()
    {
        if (asteroid_spawned)
        {
            print("ffj");
        }

        int obstacle_index = Random.Range(0, ObstaclePrefabs.Length);
        switch (obstacle_index)
        {
            case 0:
                SpawnThree(obstacle_index);
                asteroid_spawned = false;
                break;
            case 1:
                SpawnRandom(obstacle_index);
                asteroid_spawned = true;
                break;
            default:
                SpawnRandom(obstacle_index);
                break;
        }
        //Instantiate(ObstaclePrefabs[obstacle_index], SpawnPoints[spawn_index].position, ObstaclePrefabs[obstacle_index].transform.rotation); // fix code
            
      
    }

    private void FixedUpdate()
    {
        if (screen_enemies.Count == 0)
        {
            TimedSpawn();
        }
    }

    private IEnumerator TimedShot()
    {
        WaitForSeconds waitForTime = new WaitForSeconds(timed_shot);
        while (true)
        {
            yield return waitForTime;
            int select_shooter = Random.Range(0, screen_enemies.Count);
            //screen_enemies[select_shooter].Shoot();
        }
    }

    private void SpawnRandom(int prefab)
    {
        int spawn_index = Random.Range(0, SpawnPoints.Length);
        Instantiate(ObstaclePrefabs[prefab], SpawnPoints[spawn_index].position, ObstaclePrefabs[prefab].transform.rotation);
    }

    private void SpawnThree(int prefab)
    {
        for (int index = 0; index < SpawnPoints.Length; index++)
        {
            GameObject enemy = Instantiate(ObstaclePrefabs[prefab], SpawnPoints[index].position, ObstaclePrefabs[prefab].transform.rotation);
            screen_enemies.Add(enemy);
            print(screen_enemies.Count);
            enemy.GetComponent<EnemyShip>().Shoot();
        }
    }
    public void RemoveList(GameObject gameObject)
    {
        screen_enemies.Remove(gameObject);
    }
}
