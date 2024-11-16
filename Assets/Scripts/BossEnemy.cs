using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D boss_rigid;

    [SerializeField]
    private GameObject[] projectiles;

    [SerializeField]
    private Transform[] spit_points;

    [SerializeField]
    private int hit_points = 10;

    [SerializeField]
    public float speed = 0.5f;
    
    private void Start()
    {
        do
        {
            speed = speed * Random.Range(-1, 2);
        } while (speed == 0);
        print(speed);
        boss_rigid.velocity = Vector2.up * speed;
    }

    private void FixedUpdate()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EditorOnly"))
        {
            speed = speed * -1;
        }      
    }
}
