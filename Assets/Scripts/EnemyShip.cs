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
    private float speed = 5f;

    [SerializeField]
    private float projectile_speed = 3;

    private void Awake()
    {
        doner.velocity = Vector2.left * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }

    private void Shoot()
    {
        GameObject laser = Instantiate(projectile, spit_point.position, transform.rotation);
        laser.GetComponent<Rigidbody2D>().velocity = Vector2.left * (speed +3);
    }
}
