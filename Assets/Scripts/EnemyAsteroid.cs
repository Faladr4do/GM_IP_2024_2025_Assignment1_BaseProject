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

    private void Awake()
    {
        burger.velocity = Vector2.left * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
    private void OnDestroy()
    {
        Instantiate(burger_explosion, transform.position, transform.rotation);
    }
}
