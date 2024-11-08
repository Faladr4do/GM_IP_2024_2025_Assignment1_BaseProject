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

    [SerializeField]
    private float waitTime = 3f;
    [SerializeField]
    private float obstacle_speed = 3f;

    private void Start()
    {
        StartCoroutine(TimedSpawn());
    }

    private IEnumerator TimedSpawn()
    {
        WaitForSeconds waitForTime = new WaitForSeconds(waitTime);
        while (true)
        {
            yield return waitForTime;
            int obstacle_index = Random.Range(0, ObstaclePrefabs.Length);
            int spawn_index = Random.Range(0, SpawnPoints.Length);
            Instantiate(ObstaclePrefabs[obstacle_index], SpawnPoints[spawn_index].position, ObstaclePrefabs[obstacle_index].transform.rotation); // fix code
            
        }
    }
}
