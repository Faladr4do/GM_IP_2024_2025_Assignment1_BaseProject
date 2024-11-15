using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAsteroid : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D burger;

    [SerializeField]
    GameObject burger_explosion;

    [SerializeField]
    private float speed = 5f;

    private GameManager gameManager;

    private Spawner spawner;

    private void Start()
    {
        burger.velocity = Vector2.left * speed;
        gameManager = FindAnyObjectByType<GameManager>();
        spawner = FindAnyObjectByType<Spawner>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(burger_explosion, transform.position, transform.rotation);
        }
        print(other.gameObject);
        if (!other.CompareTag("Enemy"))
        {
            spawner.screen_enemies.Remove(gameObject);
            Destroy(gameObject);
        }
    }
}
