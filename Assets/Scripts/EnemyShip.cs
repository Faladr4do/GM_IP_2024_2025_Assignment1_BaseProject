using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D doner;

    [SerializeField]
    GameObject projectile;

    [SerializeField]
    private Transform spit_point;

    [SerializeField]
    private int score = 1;

    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private float projectile_speed = 3;

    private GameManager gameManager;

    private Spawner spawner;

    private void Start()
    {
        doner.velocity = Vector2.left * speed;
        gameManager = FindAnyObjectByType<GameManager>();
        spawner = FindAnyObjectByType<Spawner>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.AddScore(score);
        }
        Destroy(gameObject);
    }

    public void Shoot()
    {
        GameObject laser = Instantiate(projectile, spit_point.position, transform.rotation);
        laser.GetComponent<Rigidbody2D>().velocity = Vector2.left * (speed +3);
    }
    private void OnDestroy()
    {
        spawner.screen_enemies.Remove(gameObject);
    }
}
