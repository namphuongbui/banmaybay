using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2 : MonoBehaviour
{
   
    private Rigidbody2D _rigidbody2D;

    private float speed = 8f;

    private Collider2D _collider2D;
    public Vector2 force;


    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _collider2D = GetComponent<Collider2D>();
        gameObject.SetActive(false);
    }

    public void Activate()
    {
        _rigidbody2D.velocity = force.normalized * speed;
    }

    private void OnTriggerEnter2D(Collider2D enemy)
    {
        if (enemy.CompareTag("Player"))
        {
            enemy.GetComponent<PlayerTouchControl>().DecreaHealth(20);
            Transform vfx = ObjectPutter.Instance.PutObject(SpawnerType.VFXSpark);
            vfx.position = transform.position;
            gameObject.SetActive(false);
           
        }
    }
}